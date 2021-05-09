using ForecastApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForecastApp.Tests
{
    [TestClass]
    public class ForecastVMTests
    {
        [TestMethod]
        public void ValidLocation()
        {
            var vm = new ForecastVM();
            vm.GetForecast("London", 44418);

            Assert.IsTrue(vm.Forecast.Consolidated_Weather != null);
            Assert.IsTrue(vm.Forecast.Consolidated_Weather.Count > 0);
            Assert.IsTrue(vm.Forecast.Consolidated_Weather[0].Location == "London");
        }

        [TestMethod]
        public void InvalidLocation()
        {
            var vm = new ForecastVM();
            vm.GetForecast("No where", 0);

            Assert.IsTrue(vm.Forecast.Consolidated_Weather != null);
            Assert.IsTrue(vm.Forecast.Consolidated_Weather.Count == 1);
            Assert.IsTrue(vm.Forecast.Consolidated_Weather[0].Weather_State_Abbr == "err");
        }
    }
}
