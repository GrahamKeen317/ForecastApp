using ForecastApp.Events;
using ForecastApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ForecastApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ForecastVM _forecastVM;
        public ForecastVM ForecastVM { get => _forecastVM; set { _forecastVM = value; OnPropertyChanged("ForecastVM"); } }

        private LocationVM _locationVM;
        public LocationVM LocationVM { get => _locationVM; set { _locationVM = value; OnPropertyChanged("LocationVM"); } }

        private ForecastDetailVM _forecastDetailVM;
        public ForecastDetailVM ForecastDetailVM { get => _forecastDetailVM; set { _forecastDetailVM = value; OnPropertyChanged("ForecastDetailVM"); } }

        private string _time;
        public string Time { get => _time; set { _time = value; OnPropertyChanged("Time"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindow()
        {
            ForecastVM = new ForecastVM();
            LocationVM = new LocationVM();
            ForecastDetailVM = new ForecastDetailVM();
            InitializeComponent();

            //Timer to update date/time display
            DispatcherTimer liveTime = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            liveTime.Tick += Timer_Tick;
            liveTime.Start();
        }

        private void SideBar_SearchTextChanged(object sender, SearchEventArgs e)
        {
            //Filter locations based on received text
            LocationVM.Filter(e.SearchText);
        }

        private void SideBar_OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            //Load weather forecast for the provided location
            Cursor = Cursors.Wait;
            ForecastVM.GetForecast(e.Location, e.WOEID);
            //Empty and hide the daily forecast detail
            ForecastDetailVM.LoadForecast(null);
            Cursor = Cursors.Arrow;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Update time string to current value
            Time = string.Format(CultureInfo.InvariantCulture, "{0:dd/MM/yyyy  HH:mm:ss}", DateTime.Now);
        }

        private void LocationForecast_OnForecastSelected(object sender, SelectedForecastEventArgs e)
        {
            //Hide the list of forecasts and show more detail on selected day
            ForecastDetailVM.LoadForecast(e.ForecastDay);
            ForecastVM.Visibility = Visibility.Collapsed;
        }

        private void ForecastDetailControl_OnDetailClosed(object sender, EventArgs e)
        {
            //Empty and hide the forecast day detail and show the list
            ForecastDetailVM.LoadForecast(null);
            ForecastVM.Visibility = Visibility.Visible;
        }
    }
}
