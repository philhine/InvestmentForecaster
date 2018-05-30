using InvestmentForecaster.Service;
using InvestmentForecaster.Service.Bounds;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecast.Service.Tests.Entities
{
    [TestClass]
    public class BoundsFactoryTests
    {
        IBoundsFactory _boundsFactory;

        [TestInitialize]
        public void Setup()
        {
            _boundsFactory = new BoundsFactory();
        }

        [TestMethod]
        public void WhenLow_ThenReturnCorrectType()
        {
            //Arrange
            RiskLevel riskLevel = RiskLevel.low;
            Type expectedType = typeof(LowRiskBounds);

            //Act
            var actual = _boundsFactory.GetBounds(riskLevel);

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
        }

        [TestMethod]
        public void WhenMedium_ThenReturnCorrectType()
        {
            //Arrange
            RiskLevel riskLevel = RiskLevel.medium;
            Type expectedType = typeof(MediumRiskBounds);

            //Act
            var actual = _boundsFactory.GetBounds(riskLevel);

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
        }

        [TestMethod]
        public void WhenHigh_ThenReturnCorrectType()
        {
            //Arrange
            RiskLevel riskLevel = RiskLevel.medium;
            Type expectedType = typeof(MediumRiskBounds);

            //Act
            var actual = _boundsFactory.GetBounds(riskLevel);

            //Assert
            Assert.IsInstanceOfType(actual, expectedType);
        }
    }
}
