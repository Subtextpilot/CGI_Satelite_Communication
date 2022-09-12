using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace CGI_Satelite_Communication
{
    internal class TimeSpot
    {
        private List<Satellite> maxSatellitesSameTime;
        private DateTime startTimePeriod;
        private DateTime endTimePeriod;
        private int maxSatellite;

        internal List<Satellite> MaxSatellitesSameTime { get => maxSatellitesSameTime; set => maxSatellitesSameTime = value; }

        public TimeSpot(List<Satellite> maxSatellitesSameTime)
        {
            this.MaxSatellitesSameTime = maxSatellitesSameTime;
            CalculateStartTimePeriod();
            CalculateEndTimePeriod();
            CalculateMaxSatellite();
        }   


        private void CalculateStartTimePeriod()
        {
            if (maxSatellitesSameTime.Count>0)
            {
            startTimePeriod = MaxSatellitesSameTime.Select(s => s.StartCommunication).Max();
            }
        }

        private void CalculateEndTimePeriod()
        {
            if (maxSatellitesSameTime.Count > 0)
            {
                endTimePeriod = MaxSatellitesSameTime.Select(s => s.EndCommunication).Min();
            }
        }
            
        private void CalculateMaxSatellite()
        {
            if (maxSatellitesSameTime.Count > 0)
            {
                maxSatellite = MaxSatellitesSameTime.Count();
            }
        }
        
        public string TimeSpotToString()
        {           

            return startTimePeriod.ToString("HH:mm:ss.fff")+"-"+ endTimePeriod.ToString("HH:mm:ss.fff") +  ";" + maxSatellite;
        }


    }
}
