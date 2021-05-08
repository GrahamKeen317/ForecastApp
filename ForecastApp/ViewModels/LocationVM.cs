using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.ViewModels
{
    public class LocationVM : INotifyPropertyChanged
    {
        private Dictionary<string, int> _locations;
        public Dictionary<string, int> Locations { get => _locations; set { _locations = value; OnPropertyChanged("Locations"); } }

        private Dictionary<string, int> _locationsMaster;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public LocationVM()
        {
            BuildMasterList();
            Filter(null);
        }

        private void BuildMasterList()
        {
            //Create base list of locations to filter from
            _locationsMaster = new Dictionary<string, int>
            {
                {"London", 44418 },
                {"Swansea", 36758 },
                {"Madrid", 766273 },
                {"Athens", 946738 },
                {"New Delhi", 2295019 },
                {"Ottawa", 3369 },
                {"Cape Town", 1591691 },
                {"Sydney", 1105779 },
                {"San Francisco", 44418 },
                {"Edinburgh", 19344 },
                {"Cardiff", 15127 },
                {"Birmingham", 12723 },
                {"Manchester", 28218 },
                {"Inverness", 24502 },
                {"Dublin", 560743 },
                {"Paris", 615702 },
                {"New York", 2459115 },
                {"Washington D.C.", 2514815 },
                {"Berlin", 638243 }
            };
        }

        public void Filter (string filter)
        {
            //If no filter is set, return the entire list. Otherwise return every location that returns a partial match
            if (string.IsNullOrWhiteSpace(filter))
                Locations = _locationsMaster;
            else
                Locations = _locationsMaster.Where(l => l.Key.ToUpper().Contains(filter.ToUpper())).ToDictionary(l => l.Key, l => l.Value);
        }
    }
}
