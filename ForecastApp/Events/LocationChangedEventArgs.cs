using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Events
{
    public class LocationChangedEventArgs : EventArgs
    {
        public string Location { get; set; }
        public int WOEID { get; set; }

        public LocationChangedEventArgs(string location, int woeid)
        {
            Location = location;
            WOEID = woeid;
        }
    }
}
