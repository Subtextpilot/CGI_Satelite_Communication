using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;

namespace CGI_Satelite_Communication
{
    internal class Program
    {     

        static void Main(string[] args)
        {            

            if (args.Length == 0)
            {
                Console.WriteLine("Missing File Path");
                return;
            }

            GroundStation groundStation = new GroundStation();

            groundStation.InputSatelliteData(args[0]);
            groundStation.SetSatellitesMaxTimeSlots();
            groundStation.Output();
            


        }
    }
}

            
            
                

