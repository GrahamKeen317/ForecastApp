using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Models.Forecast
{
    public class ForecastSet
    {
        public List<ForecastDay> Consolidated_Weather { get; set; }

        public ForecastSet()
        {
            Consolidated_Weather = new List<ForecastDay>();
        }
    }
}
