using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Events
{
    public class SearchEventArgs : EventArgs
    {
        public string SearchText { get; set; }

        public SearchEventArgs(string searchText)
        {
            SearchText = searchText;
        }
    }
}
