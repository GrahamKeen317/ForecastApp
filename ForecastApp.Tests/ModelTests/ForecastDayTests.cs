using ForecastApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ForecastApp.Tests.ModelTests
{
    [TestClass]
    public class ForecastDayTests
    {
        [TestMethod]
        public void NullStateImagePath()
        {
            var model = new ForecastDay
            {
                Weather_State_Abbr = null
            };

            Assert.IsTrue(model.Weather_State_Image == "");
        }

        [TestMethod]
        public void EmptyStateImagePath()
        {
            var model = new ForecastDay
            {
                Weather_State_Abbr = ""
            };

            Assert.IsTrue(model.Weather_State_Image == "");
        }

        [TestMethod]
        public void ErrorStateImagePath()
        {
            var model = new ForecastDay
            {
                Weather_State_Abbr = "err"
            };

            Assert.IsTrue(model.Weather_State_Image == @"/Images/ErrorImage.png");
        }

        [TestMethod]
        public void ValidStateImagePath()
        {
            var model = new ForecastDay
            {
                Weather_State_Abbr = "lr"
            };

            Assert.IsTrue(model.Weather_State_Image == "https://www.metaweather.com/static/img/weather/png/lr.png");
        }
    }
}
