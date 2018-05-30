using InvestmentForecast.Service.Tests.TestBuilder;
using InvestmentForecaster.Service;
using InvestmentForecaster.Service.Bounds;
using InvestmentForecaster.Service.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentForecast.Service.Tests.ForecastAnnualCalculator
{
    [TestClass]
    public class WhenHighRisk
    {
        IForecastCalculator _forecastCalculator;
        ForecastRequestDtoBuilder _builder;
        LowRiskBounds _lowRiskBound;

        [TestInitialize]
        public void Setup()
        {
            _forecastCalculator = new ForecastAnnualGrowthCalculator();
            _builder = new ForecastRequestDtoBuilder();
            _lowRiskBound = new LowRiskBounds();
        }

        [TestMethod]
        public void AndLumpSum10000AndMonthlyInvestment1000_ThenReturnCorrectValuesForYear7()
        {
            //Arrange
            ForecastRequestDto request = _builder
                            .WithValidDefaults()
                            .WithInvestmentTerm(7)
                            .Build();

            var expectedWideLowerBound = 97679.80m;
            var expectedWideUpperBound = 123197.17m;
            var expectedNarrowLowerBound = 101513.10m;
            var expectedNarrowUpperBound = 109664.16m;
            var expectedTotalInvested = 94000m;

            //Assert
            var actual = Calculate(request);

            //Act
            Assert.AreEqual(expectedWideLowerBound, actual.ElementAt(7).TotalValueWideLower, "Wide lower");
            Assert.AreEqual(expectedWideUpperBound, actual.ElementAt(7).TotalValueWideUpper, "Wide upper");

            Assert.AreEqual(expectedNarrowLowerBound, actual.ElementAt(7).TotalValueNarrowLower, "Narrow lower");
            Assert.AreEqual(expectedNarrowUpperBound, actual.ElementAt(7).TotalValueNarrowUpper, "Narrow upper");

            Assert.AreEqual(expectedTotalInvested, actual.ElementAt(7).TotalInvestmentAmount, "Total invested");
        }

        [TestMethod]
        public void AndLumpSum10000AndMonthlyInvestment1000_ThenReturnCorrectValuesForYear0()
        {
            //Arrange
            ForecastRequestDto request = _builder
                            .WithValidDefaults()
                            .Build();

            var expectedAmount = request.LumpSumInvestment;

            //Assert
            var actual = Calculate(request);

            //Act
            Assert.AreEqual(expectedAmount, actual.ElementAt(0).TotalValueWideLower, "Wide lower");
            Assert.AreEqual(expectedAmount, actual.ElementAt(0).TotalValueWideUpper, "Wide upper");

            Assert.AreEqual(expectedAmount, actual.ElementAt(0).TotalValueNarrowLower, "Narrow lower");
            Assert.AreEqual(expectedAmount, actual.ElementAt(0).TotalValueNarrowUpper, "Narrow upper");

            Assert.AreEqual(expectedAmount, actual.ElementAt(0).TotalValueNarrowUpper, "Total invested");
        }


        private IEnumerable<AnnualForecast> Calculate(ForecastRequestDto request)
        {
            return _forecastCalculator.Calculate(new HighRiskBounds(), request);
        }

    }
}
