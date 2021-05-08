using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Models
{
    public class ForecastDay
    {
        public long ID { get; set; }
        public string Location { get; set; }
        public string Weather_State_Name { get; set; }
        public string Weather_State_Abbr { get; set; }
        public string Wind_Direction_Compass { get; set; }
        public decimal Wind_Speed { get; set; }
        public DateTime Applicable_Date { get; set; }
        public decimal Min_Temp { get; set; }
        public decimal Max_Temp { get; set; }
        public decimal Humidity { get; set; }
        public string Weather_State_Image { get => GetImagePath(); }

        private string GetImagePath()
        {
            //Get weather icon from api, return error image if no data was recieved
            if (string.IsNullOrWhiteSpace(Weather_State_Abbr))
                return "";
            else if (Weather_State_Abbr == "err")
                return @"/Images/ErrorImage.png";
            else
                return $"https://www.metaweather.com/static/img/weather/png/{Weather_State_Abbr}.png";
        }
    }
}
