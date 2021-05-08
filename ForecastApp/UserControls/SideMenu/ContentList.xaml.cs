using ForecastApp.Events;
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

namespace ForecastApp.UserControls.SideMenu
{
    /// <summary>
    /// Interaction logic for ContentList.xaml
    /// </summary>
    public partial class ContentList : UserControl
    {
        public delegate void LocationChangedEventHandler(object sender, LocationChangedEventArgs e);
        public event LocationChangedEventHandler OnLocationChanged;

        public ContentList()
        {
            InitializeComponent();
        }

        private void Location_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {                
            var item = (sender as Label).DataContext;
            if (item is KeyValuePair<string, int> location)
            {
                //Change the colour of text so the selected location is highlighted
                foreach (KeyValuePair<string, int> locationItem in LocationList.Items)
                {
                    var label = VisualTreeHelper.GetChild(LocationList.ItemContainerGenerator.ContainerFromItem(locationItem), 0) as Label;

                    if (locationItem.Key == location.Key)
                        label.Foreground = Brushes.DarkCyan;
                    else
                        label.Foreground = Brushes.WhiteSmoke;
                }
                //Tell the parent a location has been selected
                OnLocationChanged(this, new LocationChangedEventArgs(location.Key, location.Value));
            }
        }
    }
}
