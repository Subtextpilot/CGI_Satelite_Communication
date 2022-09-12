using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace CGI_Satelite_Communication
{
    internal class GroundStation
    {
        private List<Satellite> allSatellites;
        private List<TimeSpot> timeSpots;

        public GroundStation()
        {
            allSatellites = new List<Satellite>();            
            timeSpots = new List<TimeSpot> { new TimeSpot(new List<Satellite>()) };  //requires empty list for comparison in the method FindSatellitesMaxTimeSlots      
        }
         // Comment    
        
        public void InputSatelliteData(string path)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] inputTimes = streamReader.ReadLine().Split(",");
                        Satellite satellite = new Satellite(inputTimes[0], inputTimes[1]);
                        allSatellites.Add(satellite);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        public List<Satellite> SatellitesAtTheSameTime(Satellite satellite)
        {
            // return all satellites wich have connection at the same time 
            return allSatellites.Where(s => satellite.StartCommunication >= s.StartCommunication && satellite.StartCommunication <= s.EndCommunication).ToList();
        }                
            
         

        public void FindSatellitesMaxTimeSlots()
        {        

            foreach (Satellite satellite in allSatellites)
            {
                List<Satellite> satellitesSameTime = SatellitesAtTheSameTime(satellite);                

                // if list is bigger create new TimeSlot
                if (satellitesSameTime.Count > timeSpots[0].MaxSatellitesSameTime.Count())
                {
                    TimeSpot timeSpot = new TimeSpot(satellitesSameTime);
                    timeSpots = new List<TimeSpot> { timeSpot };
                }
                // else add List to TimSlot
                else if (satellitesSameTime.Count == timeSpots[0].MaxSatellitesSameTime.Count())
                {
                    TimeSpot timeSpot = new TimeSpot(satellitesSameTime);
                    timeSpots.Add(timeSpot);
                }
            }            
        }
        
       
        public void Output()
        {
            foreach (TimeSpot t in timeSpots)
            {
                Console.WriteLine(t.TimeSpotToString());
            }
        }       
       
    }
}

               


           
            


