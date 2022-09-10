using System;
using System.Collections.Generic;
using System.Text;

namespace CGI_Satelite_Communication
{
    internal class Satellite
    {
        public DateTime StartCommunication { get; set; }
        public DateTime EndCommunication { get; set; }

        public Satellite (string Start, string End)
        {
            StartCommunication = DateTime.Parse (Start);
            EndCommunication = DateTime.Parse (End);
        }
    }
}
