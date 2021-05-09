using ForecastApp.Models;
using ForecastApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForecastApp.Tests
{
    [TestClass]
    public class ForecastDetailVMTests
    {
        [TestMethod]
        public void NullForecast()
        {
            var vm = new ForecastDetailVM();
            vm.LoadForecast(null);

            Assert.IsTrue(vm.Forecast == null);
            Assert.IsTrue(vm.Visibility == System.Windows.Visibility.Collapsed);
        }

        [TestMethod]
        public void NonNullForecast()
        {
            var forecast = new ForecastDay
            {
                Weather_State_Abbr = "err",
                Weather_State_Name = "No data available"
            };
            var vm = new ForecastDetailVM();
            vm.LoadForecast(forecast);

            Assert.IsTrue(vm.Forecast != null);
            Assert.IsTrue(vm.Visibility == System.Windows.Visibility.Visible);
        }
    }
}
