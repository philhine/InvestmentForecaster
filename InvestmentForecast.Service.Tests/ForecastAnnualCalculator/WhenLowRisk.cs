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
    public class WhenLowRisk
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
        public void AndLumpSum10000AndMonthlyInvestment1000_ThenReturnCorrectValuesForYear10()
        {
            //Arrange
            ForecastRequestDto request = _builder
                            .WithValidDefaults()
                            .WithInvestmentTerm(10)
                            .Build();

            var expectedWideLowerBound = 137167.16m;
            var expectedWideUpperBound = 152887.15m;
            var expectedNarrowLowerBound = 140918.66m;
            var expectedNarrowUpperBound = 148775.03m;
            var expectedTotalInvested = 130000m;

            //Assert
            var actual = Calculate(request);

            //Act
            Assert.AreEqual(expectedWideLowerBound, actual.ElementAt(10).TotalValueWideLower, "Wide lower");
            Assert.AreEqual(expectedWideUpperBound, actual.ElementAt(10).TotalValueWideUpper, "Wide upper");

            Assert.AreEqual(expectedNarrowLowerBound, actual.ElementAt(10).TotalValueNarrowLower, "Narrow lower");
            Assert.AreEqual(expectedNarrowUpperBound, actual.ElementAt(10).TotalValueNarrowUpper, "Narrow upper");

            Assert.AreEqual(expectedTotalInvested, actual.ElementAt(10).TotalInvestmentAmount, "Total invested");
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
            return _forecastCalculator.Calculate(new LowRiskBounds(), request);
        }

    }
}
