using ForecastApp.Models;
using ForecastApp.ViewModels;
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
    /// Interaction logic for ForecastDetailControl.xaml
    /// </summary>
    public partial class ForecastDetailControl : UserControl
    {
        public delegate void DetailCloseHandler(object sender, EventArgs e);
        public event DetailCloseHandler OnDetailClosed;

        public ForecastDetailControl()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            //Tell the parent to hide the control
            OnDetailClosed(this, new EventArgs());
        }
    }
}
