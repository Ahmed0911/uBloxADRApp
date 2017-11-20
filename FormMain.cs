using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uBloxADRTester
{
    public partial class FormADR : Form
    {
        NMEAParser nmeaParserTelit = new NMEAParser();
        NMEAParser nmeaParserUBlox = new NMEAParser();

        // ELM Processor
        ELMProcessor elmProc = new ELMProcessor();

        // Log Files
        StreamWriter telitLogger;
        StreamWriter ubloxLogger;

        int TivaDataSent = 0;
        double TivaLastSentKph = 0;

        double TelitSpeedMPS = 0;
        double TelitTimeStampSec = 0;

        public FormADR()
        {
            InitializeComponent();

            // fill commports
            string[] ports = SerialPort.GetPortNames();
            comboBoxComPortListTelit.Items.AddRange(ports);
            comboBoxComPortListuBlox.Items.AddRange(ports);
            comboBoxComPortListELM.Items.AddRange(ports);

            // select second
            //if (comboBoxComPortListTelit.Items.Count >= 2)
            //{
            //   comboBoxComPortListTelit.SelectedIndex = 1;
            //}
            // select third
            if (comboBoxComPortListuBlox.Items.Count >= 5)
            {
                comboBoxComPortListuBlox.SelectedIndex = 4;
            }
            // select Tiva
            if (comboBoxComPortListELM.Items.Count >= 3)
            {
                comboBoxComPortListELM.SelectedIndex = 2;
            }

            elmProc.Init(serialPortELM, richTextBoxELMTerminal);

            // Open Log Files
            telitLogger = File.CreateText("Telit.txt");
            ubloxLogger = File.CreateText("UBlox.txt");

            stw.Start();
        }

        private void buttonCommConnectTelit_Click(object sender, EventArgs e)
        {
            if (comboBoxComPortListTelit.SelectedIndex >= 0)
            {
                serialPortTelit.PortName = (string)comboBoxComPortListTelit.SelectedItem;
                serialPortTelit.BaudRate = 115200;
                serialPortTelit.Open();

                buttonCommConnectTelit.Enabled = false;
            }
        }

        Stopwatch stw = new Stopwatch();

        private void timerMain_Tick(object sender, EventArgs e)
        {
            // get data from Telit
            if( serialPortTelit.IsOpen)
            {
                string newData = serialPortTelit.ReadExisting();
                bool dataReceived = nmeaParserTelit.NewData(newData);

                // Log Data
                if( newData.Length > 0) telitLogger.Write(newData);

                if(dataReceived)
                {
                    // send data to uBlox
                    // convert speed
                    //int frequency = (int)(nmeaParserTelit.SpeedMps * 100); // convert to cm/s->frequency
                    //if (frequency < 100) frequency = 0;
                    //SendSpeedToTiva(frequency);

                    TelitSpeedMPS = nmeaParserTelit.SpeedMps;
                    TelitTimeStampSec = nmeaParserTelit.Time;

                    //TelitSpeedMPS = 12.5;
                }
            }

            // Process ELM Sensor
            elmProc.Process(checkBoxELMLog.Checked);

            // calculate Speed
            TelitSpeedMPS = (double)elmProc.SpeedKph / 3.6;

            // get data from uBlox
            if (serialPortuBlox.IsOpen)
            {
                string newData = serialPortuBlox.ReadExisting();
                nmeaParserUBlox.NewData(newData);

                // Log Data
                if (newData.Length > 0) ubloxLogger.Write(newData);

                // Send Data to uBlox
                if (TelitSpeedMPS < 0.2) TelitSpeedMPS = 0;
                TelitTimeStampSec = stw.ElapsedMilliseconds / 1000.0;
                SendSpeedTouBlox(TelitTimeStampSec, TelitSpeedMPS);

                TivaLastSentKph = TelitSpeedMPS * 3.6;
                TivaDataSent++;
            }

            // update data
            textBoxTelitSatNr.Text = nmeaParserTelit.SatNr.ToString();
            textBoxTelitTime.Text = nmeaParserTelit.Time.ToString();
            textBoxTelitSpeed.Text = nmeaParserTelit.SpeedMps.ToString("0.00 m/s");
            textBoxTelitHeading.Text = nmeaParserTelit.Heading.ToString();

            textBoxuBloxSatNr.Text = nmeaParserUBlox.SatNr.ToString();
            textBoxuBloxTime.Text = nmeaParserUBlox.Time.ToString();
            textBoxuBloxSpeed.Text = nmeaParserUBlox.SpeedMps.ToString("0.00 m/s");
            textBoxuBloxHeading.Text = nmeaParserUBlox.Heading.ToString();

            textBoxTivaDataSent.Text = TivaDataSent.ToString();
            textBoxTivaDataSentFreq.Text = TivaLastSentKph.ToString("0.0 km/h");

            textBoxELMState.Text = elmProc.elmState.ToString();
        }

        private void SendSpeedTouBlox(double telitTimeSec, double telitSpeedMPS)
        {
            if (serialPortuBlox.IsOpen)
            {
                byte[] dataToSend = GenerateESFMeasMSG((uint)(telitTimeSec*1000), 11, (uint)(telitSpeedMPS * 1e3));
                
                // send to serial port
                serialPortuBlox.Write(dataToSend, 0, dataToSend.Length);
            }
        }

        private byte[] GenerateUbloxTXPacket(byte classID, byte id, byte[] data, int length)
        {
            byte[] packet = new byte[length + 8];
            // assemble header
            packet[0] = 0xB5; // SYNC1
            packet[1] = 0x62; // SYNC2
            packet[2] = classID; // CLASS
            packet[3] = id; // ID
            packet[4] = (byte)(length % 256);
            packet[5] = (byte)(length / 256);

            // copy payload
            data.CopyTo(packet, 6);

            // add checksum
            CHKSUM chk = CalculateCheckSum(packet, length);
            packet[length + 6] = chk.CK_A;
            packet[length + 7] = chk.CK_B;

            return packet; // return total packet, length: (2xSYNC + CLASS + ID + 2xLEN + 2xCHKSUM + LENGTH) (data+8)
        }

        private struct CHKSUM
        {
            public byte CK_A;
            public byte CK_B;
        };

        // packet is whole packet (starts with SYNC1), chk "data" is 4 bytes longer
        CHKSUM CalculateCheckSum(byte[] packet, int length)
        {
            byte ck_A = 0;
            byte ck_B = 0;

            for (int i = 2; i != length + 4 + 2; i++)
            {
                ck_A = (byte)(ck_A + packet[i]);
                ck_B = (byte)(ck_B + ck_A);
            }

            CHKSUM chk;
            chk.CK_A = ck_A;
            chk.CK_B = ck_B;

            return chk;
        }

        // Custom TX Messages
        byte[] GenerateESFMeasMSG(uint timetag, byte dataTypeID, uint providerData)
        {
            byte[] localBuffer = new byte[12];

            // add data type to data
            providerData = (providerData & 0x00FFFFFF) + (uint)(dataTypeID << 24);

            byte[] timeTagArr = BitConverter.GetBytes(timetag);
            byte[] providerDataArr = BitConverter.GetBytes(providerData);

            timeTagArr.CopyTo(localBuffer, 0);
            localBuffer[4] = 0; // flags = 0
            localBuffer[5] = 0; // flags = 0
            localBuffer[6] = 0; // Data Provider = 0
            localBuffer[7] = 0; // Data Provider = 0
            
            providerDataArr.CopyTo(localBuffer, 8); // data (speed)

            return GenerateUbloxTXPacket(0x10, 0x02, localBuffer, 12);
        }

        private void FormADR_FormClosed(object sender, FormClosedEventArgs e)
        {
            telitLogger.Close();
            ubloxLogger.Close();
        }

        private void buttonCommConnectuBlox_Click(object sender, EventArgs e)
        {
            if (comboBoxComPortListuBlox.SelectedIndex >= 0)
            {
                serialPortuBlox.PortName = (string)comboBoxComPortListuBlox.SelectedItem;
                serialPortuBlox.BaudRate = 115200;
                serialPortuBlox.Open();

                buttonCommConnectuBlox.Enabled = false;
            }
        }

        private void SendSpeedToTiva(int speed)
        {
            if (serialPortELM.IsOpen)
            {
                TivaLastSentKph = speed;
                byte[] data = BitConverter.GetBytes(speed);
                byte[] dataToSend = new byte[5];
                dataToSend[0] = 0x24;
                Array.Copy(data, 0, dataToSend, 1, 4);

                // send to serial port
                serialPortELM.Write(dataToSend, 0, 5);

                TivaDataSent++;
            }
        }

        private void buttonCommConnectELM_Click(object sender, EventArgs e)
        {
            if (comboBoxComPortListELM.SelectedIndex >= 0)
            {
                serialPortELM.PortName = (string)comboBoxComPortListELM.SelectedItem;
                serialPortELM.BaudRate = 115200;
                serialPortELM.Open();

                buttonCommConnectELM.Enabled = false;

                elmProc.Start();
            }
        }        
    }
}
