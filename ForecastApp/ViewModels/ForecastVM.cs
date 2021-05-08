using ForecastApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForecastApp.ViewModels
{
    public class ForecastVM : INotifyPropertyChanged
    {
        private string _location;
        public string Location { get => _location; set { _location = value; OnPropertyChanged("Location"); } }

        private ForecastSet _forecast;
        public ForecastSet Forecast { get => _forecast; set { _forecast = value; OnPropertyChanged("Forecast"); } }

        private Visibility _visibility = Visibility.Visible;
        public Visibility Visibility { get => _visibility; set { _visibility = value; OnPropertyChanged("Visibility"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void GetForecast(string location, int woeid)
        {
            Forecast = new ForecastSet();

            using (HttpClient client = new HttpClient())
            {
                //Build api call
                client.BaseAddress = new Uri($"https://www.metaweather.com/api/location/{woeid}/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get result from api
                var response = client.GetAsync(client.BaseAddress).Result;
                //Set location name
                Location = location;
                
                //If call was successful, use result to populate. Otherwise create default forecast to inform user nothing was available
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var set = JsonConvert.DeserializeObject<ForecastSet>(result);
                    foreach (var day in set.Consolidated_Weather)
                        day.Location = location;
                    Forecast = set;
                }
                else
                {
                    ForecastSet set = new ForecastSet();
                    set.Consolidated_Weather.Add(new ForecastDay
                    {
                        Weather_State_Abbr = "err",
                        Weather_State_Name = "No data available"
                    });

                    Forecast = set;
                }
            }

            //Make sure the forecast list is visible
            Visibility = Visibility.Visible;
        }
    }
}
