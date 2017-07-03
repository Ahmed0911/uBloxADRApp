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

        public FormADR()
        {
            InitializeComponent();

            // fill commports
            string[] ports = SerialPort.GetPortNames();
            comboBoxComPortListTelit.Items.AddRange(ports);
            comboBoxComPortListuBlox.Items.AddRange(ports);

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
                nmeaParserTelit.NewData(newData);

                // Log Data
                if( newData.Length > 0) telitLogger.Write(newData);
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
    }
}
