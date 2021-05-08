using ForecastApp.Events;
using ForecastApp.Models;
using System;
using System.Collections.Generic;
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

namespace ForecastApp.UserControls.Forecast
{
    /// <summary>
    /// Interaction logic for LocationForecast.xaml
    /// </summary>
    public partial class LocationForecast : UserControl
    {
        public delegate void ForecastSelectedHandler(object sender, SelectedForecastEventArgs e);
        public event ForecastSelectedHandler OnForecastSelected;

        public LocationForecast()
        {
            InitializeComponent();
        }

        private void ForecastListItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Tell the parent a particular day has been selected
            var forecast = (sender as Control).DataContext as ForecastDay;
            OnForecastSelected(this, new SelectedForecastEventArgs(forecast));
        }
    }
}
