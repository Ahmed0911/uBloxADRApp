﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uBloxADRTester
{
    class NMEAParser
    {
        string remainingData = "";

        public int SatNr = 0;
        public double Time = 0;
        public double SpeedMps = 0;
        public double Heading = 0;

        public bool NewData(string data)
        {
            bool newDataReceived = false;
            string totalData = remainingData + data; // concatenate data

            if (totalData.Length > 0)
            {
                // split commands
                string[] commands = totalData.Split('\n');

                if (commands.Length > 0)
                {
                    for (int i = 0; i != commands.Length - 1; i++)
                    {
                        // parse command
                        if( ParseCommand(commands[i]) )
                        {
                            newDataReceived = true;
                        }
                    }

                    // set remaining
                    remainingData = commands[commands.Length - 1];
                }
            }

            return newDataReceived;
        }

        private bool ParseCommand(string cmd)
        {
            bool newDataReceived = false;

            if( cmd[0] == '$') // check if valid
            {
                if( cmd.Contains("$GPRMC") || cmd.Contains("$GNRMC"))
                {
                    // RMC command, parse
                    string[] tokens = cmd.Split(',');
                    double time = 0;
                    double.TryParse(tokens[1], out time);
                    //double latitude = double.Parse(tokens[3]);
                    //double longitude = double.Parse(tokens[5]);
                    double speedmeterspersec = 0;
                    double.TryParse(tokens[7], out speedmeterspersec);
                    speedmeterspersec = speedmeterspersec / 1.943844;
                    double cog = 0;
                    double.TryParse(tokens[8], out cog);

                    Time = time;
                    SpeedMps = speedmeterspersec;
                    Heading = cog;

                    newDataReceived = true;
                }
                if (cmd.Contains("$GPGGA") || cmd.Contains("$GNGGA"))
                {
                    // RMC command, parse
                    string[] tokens = cmd.Split(',');
                    double satNum = 0;
                    double.TryParse(tokens[7], out satNum);

                    SatNr = (int)satNum;
                }
            }

            return newDataReceived;
        }
    }
}
