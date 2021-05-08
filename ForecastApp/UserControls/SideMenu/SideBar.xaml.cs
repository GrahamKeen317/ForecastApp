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
    /// Interaction logic for SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        public delegate void SearchTextChangedEventHandler(object sender, SearchEventArgs e);
        public event SearchTextChangedEventHandler SearchTextChanged;

        public delegate void LocationChangedEventHandler(object sender, LocationChangedEventArgs e);
        public event LocationChangedEventHandler OnLocationChanged;

        public SideBar()
        {
            InitializeComponent();
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            //Tell the parent to filter locations based on text entered
            var text = (sender as TextBox).Text ?? "";
            SearchTextChanged(this, new SearchEventArgs(text.Trim()));
        }

        private void ContentList_OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            //Relay location change to parent
            OnLocationChanged(sender, e);
        }
    }
}
