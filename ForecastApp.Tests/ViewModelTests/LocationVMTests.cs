using ForecastApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForecastApp.Tests
{
    [TestClass]
    public class LocationVMTests
    {
        [TestMethod]
        public void NullFilter()
        {
            var vm = new LocationVM();
            vm.Filter(null);

            Assert.IsTrue(vm.Locations != null);
            Assert.IsTrue(vm.Locations.Count > 0);
        }

        [TestMethod]
        public void EmptryFilter()
        {
            var vm = new LocationVM();
            vm.Filter("");

            Assert.IsTrue(vm.Locations != null);
            Assert.IsTrue(vm.Locations.Count > 0);
        }

        [TestMethod]
        public void AllCapsFilter()
        {
            var vm = new LocationVM();
            vm.Filter("LONDON");

            Assert.IsTrue(vm.Locations != null);
            Assert.IsTrue(vm.Locations.ContainsKey("London"));
        }

        [TestMethod]
        public void AllLowerFilter()
        {
            var vm = new LocationVM();
            vm.Filter("london");

            Assert.IsTrue(vm.Locations != null);
            Assert.IsTrue(vm.Locations.ContainsKey("London"));
        }

        [TestMethod]
        public void MixedCaseFilter()
        {
            var vm = new LocationVM();
            vm.Filter("LoNDon");

            Assert.IsTrue(vm.Locations != null);
            Assert.IsTrue(vm.Locations.ContainsKey("London"));
        }
    }
}
