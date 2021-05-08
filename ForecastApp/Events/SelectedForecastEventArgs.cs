using ForecastApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Events
{
    public class SelectedForecastEventArgs : EventArgs
    {
        public ForecastDay ForecastDay { get; set; }

        public SelectedForecastEventArgs(ForecastDay forecastDay)
        {
            ForecastDay = forecastDay;
        }
    }
}
