using ForecastApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForecastApp.ViewModels
{
    public class ForecastDetailVM : INotifyPropertyChanged
    {
        private ForecastDay _forecast;
        public ForecastDay Forecast { get => _forecast; set { _forecast = value; OnPropertyChanged("Forecast"); } }

        private Visibility _visibility = Visibility.Collapsed;
        public Visibility Visibility { get => _visibility; set { _visibility = value; OnPropertyChanged("Visibility"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadForecast(ForecastDay forecast)
        {
            Forecast = forecast;
            if (forecast != null)
                Visibility = Visibility.Visible;
            else
                Visibility = Visibility.Collapsed;
        }
    }
}
