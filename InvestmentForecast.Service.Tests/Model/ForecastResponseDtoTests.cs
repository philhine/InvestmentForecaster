using InvestmentForecaster.Service.DTO;
using InvestmentForecaster.Service.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecast.Service.Tests.Model
{
    [TestClass]
    public class ForecastResponseDtoTests
    {
        [TestMethod]
        public void WhenResponseHasValidationMessages_ThenReturnsSuccessFalse()
        {
            //Arrange
            var validationMessages = new List<string> { "Dummy Error" };

            //Act
            var actual = new ForecastResponseDto(validationMessages);

            //Assert
            Assert.IsFalse(actual.Success);
        }

        [TestMethod]
        public void WhenResponseHasNoValidationMessages_ThenReturnsSuccess()
        {
            //Arrange
            IEnumerable<AnnualForecast> annualForecasts = new List<AnnualForecast>();

            //Act
            var actual = new ForecastResponseDto(annualForecasts);

            //Assert
            Assert.IsTrue(actual.Success);
        }
    }
}
