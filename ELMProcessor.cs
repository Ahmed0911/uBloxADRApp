using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uBloxADRTester
{
    class ELMProcessor
    {
        public enum EELMState { NONE, INIT, ID_CHECK, BATT_CHECK, BATT_CHECK_RESPONSE, REQUEST, RESPONSE, FAIL };
        public EELMState elmState;
        SerialPort serialPort;
        RichTextBox richTextBox;
        string responseLine = "";

        public int SpeedKph = 0;

        public void Init(SerialPort serialPortObj, RichTextBox richTextBoxObj)
        {
            elmState = EELMState.NONE;
            serialPort = serialPortObj;
            richTextBox = richTextBoxObj;
        }

        public void Start()
        {
            elmState = EELMState.INIT;
        }

        public void Process(bool log)
        {
            // read all data from serial
            if (serialPort != null && serialPort.IsOpen)
            {
                string newData = serialPort.ReadExisting();
                if(log)richTextBox.AppendText(newData);

                responseLine += newData;
            }

            switch (elmState)
            {          
                case EELMState.NONE:
                    break;

                case EELMState.INIT:
                    // Send init ('ATI');
                    SendCmd("ATI");
                    elmState = EELMState.ID_CHECK;
                    break;

                case EELMState.ID_CHECK:
                    // get response
                    if( responseLine.Contains("\r"))
                    {
                        // check string
                        string[] toks = responseLine.Split('\r');
                        if( toks.Length >= 2)
                        {
                            if (toks[1].Contains("ELM327"))
                            {
                                // DONE, go config
                                elmState = EELMState.BATT_CHECK;
                                richTextBox.AppendText("ELM Found...");
                            }
                            else
                            {
                                richTextBox.AppendText("FAIL!!");
                                elmState = EELMState.FAIL;
                            }
                        }
                    }
                    break;

                case EELMState.BATT_CHECK:
                    // send battery request (check)
                    SendCmd("01 0D"); //???
                    elmState = EELMState.BATT_CHECK_RESPONSE;
                    break;

                case EELMState.BATT_CHECK_RESPONSE:
                    // get response
                    if (responseLine.Contains("\r"))
                    {
                        // check string
                        string[] toks = responseLine.Split('\r');
                        if (toks.Length >= 2)
                        {
                            // check all responses
                            for(int i=0; i!=toks.Length; i++)
                            {
                                if( toks[i].Contains("41 0D"))
                                {
                                    elmState = EELMState.REQUEST; // response received, proceed
                                }
                            }
                        }
                    }
                    break;

                case EELMState.REQUEST:
                    // send speed request
                    SendCmd("01 0D");
                    //SendCmd("01 0D 01");
                    elmState = EELMState.RESPONSE;
                    break;

                case EELMState.RESPONSE:
                    // get response
                    if (responseLine.Contains("\r"))
                    {
                        // check string
                        string[] toks = responseLine.Split('\r');
                        if (toks.Length >= 2)
                        {
                            // check all responses
                            for (int i = 0; i != toks.Length; i++)
                            {
                                if (toks[i].Contains("41 0D"))
                                {
                                    try
                                    {
                                        // parse data
                                        string data = toks[i].Substring(toks[i].LastIndexOf("41 0D") + 6, 2);
                                        int speed;
                                        bool result = Int32.TryParse(data, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out speed);

                                        if (result)
                                        {
                                            SpeedKph = speed;
                                            elmState = EELMState.REQUEST; // response received, repeat
                                        }
                                    } catch { };
                                }
                            }
                        }
                    }
                    break;

                case EELMState.FAIL:
                    break;
            }
        }

        private void SendCmd(string str)
        {
            string toSend = str + "\r";
            serialPort.Write(toSend);
            //richTextBox.AppendText(toSend); // local echo is enabled!
            
            // clear response line
            responseLine = "";
        }
    }
}
