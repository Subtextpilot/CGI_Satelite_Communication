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
        }   


        private void SetStartTimePeriod()
        {
            startTimePeriod = MaxSatellitesSameTime.Select(s => s.StartCommunication).Max();
        }
        public void SetEndTimePeriod()
        {
            endTimePeriod = MaxSatellitesSameTime.Select(s => s.EndCommunication).Min();
        }
            
        public void SetMaxSatellite()
        {
            maxSatellite = MaxSatellitesSameTime.Count();
        }
        
        public string TimeSpotToString()
        {
            SetStartTimePeriod();
            SetEndTimePeriod();
            SetMaxSatellite();

            return startTimePeriod.ToString("HH:mm:ss.fff")+"-"+ endTimePeriod.ToString("HH:mm:ss.fff") +  ";" + maxSatellite;
        }


    }
}
