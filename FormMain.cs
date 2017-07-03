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
        NMEAParser nmeaParser = new NMEAParser();

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
                nmeaParser.NewData(newData);

                // Log Data
                if( newData.Length > 0) telitLogger.Write(newData);
            }


            // update data
            textBoxTelitSatNr.Text = nmeaParser.SatNr.ToString();
            textBoxTelitTime.Text = nmeaParser.Time.ToString();
            textBoxTelitSpeed.Text = nmeaParser.SpeedMps.ToString("0.00 m/s");
            textBoxTelitHeading.Text = nmeaParser.Heading.ToString();
        }

        private void FormADR_FormClosed(object sender, FormClosedEventArgs e)
        {
            telitLogger.Close();
            ubloxLogger.Close();
        }
    }
}
