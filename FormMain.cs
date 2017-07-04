using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        // Log Files
        StreamWriter telitLogger;
        StreamWriter ubloxLogger;

        int TivaDataSent = 0;
        int TivaLastSentFrequency = 0;

        public FormADR()
        {
            InitializeComponent();

            // fill commports
            string[] ports = SerialPort.GetPortNames();
            comboBoxComPortListTelit.Items.AddRange(ports);
            comboBoxComPortListuBlox.Items.AddRange(ports);
            comboBoxComPortListTiva.Items.AddRange(ports);

            // select second
            if (comboBoxComPortListTelit.Items.Count >= 2)
            {
                comboBoxComPortListTelit.SelectedIndex = 1;
            }
            // select third
            if (comboBoxComPortListTelit.Items.Count >= 3)
            {
                comboBoxComPortListuBlox.SelectedIndex = 2;
            }
            // select Tiva
            if (comboBoxComPortListTiva.Items.Count >= 3)
            {
                comboBoxComPortListTiva.SelectedIndex = 1;
            }

            // Open Log Files
            telitLogger = File.CreateText("Telit.txt");
            ubloxLogger = File.CreateText("UBlox.txt");
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
                    int frequency = (int)(nmeaParserTelit.SpeedMps * 10000); // convert to cm/s->frequency
                    if (frequency < 100) frequency = 0;
                    SendSpeedToTiva(frequency);
                }
            }

            // get data from uBlox
            if (serialPortuBlox.IsOpen)
            {
                string newData = serialPortuBlox.ReadExisting();
                nmeaParserUBlox.NewData(newData);

                // Log Data
                if (newData.Length > 0) ubloxLogger.Write(newData);
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
            textBoxTivaDataSentFreq.Text = TivaLastSentFrequency.ToString();
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

        private void buttonCommConnectTiva_Click(object sender, EventArgs e)
        {
            if (comboBoxComPortListTiva.SelectedIndex >= 0)
            {
                serialPortTiva.PortName = (string)comboBoxComPortListTiva.SelectedItem;
                serialPortTiva.BaudRate = 115200;
                serialPortTiva.Open();

                buttonCommConnectTiva.Enabled = false;
            }
        }

        private void SendSpeedToTiva(int speed)
        {
            if (serialPortTiva.IsOpen)
            {
                TivaLastSentFrequency = speed;
                byte[] data = BitConverter.GetBytes(speed);
                byte[] dataToSend = new byte[5];
                dataToSend[0] = 0x24;
                Array.Copy(data, 0, dataToSend, 1, 4);

                // send to serial port
                serialPortTiva.Write(dataToSend, 0, 5);

                TivaDataSent++;
            }
        }
    }
}
