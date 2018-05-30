using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.Integration.Tests.TestBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentForecast.Integration.Tests.WideBound
{
    [TestClass]
    public class WhenMediumRisk
    {
        private ApiHelper _apiHelper;

        [TestInitialize]
        public void TestSetup()
        {
            _apiHelper = new ApiHelper();
        }


        [TestCategory("WideBound"), TestCategory("MediumRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear0ValuesAreCorrect()
        {
            //Arrange
            decimal expectedLowerBound = 10000.00m;
            decimal expectedUpperBound = 10000.00m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithRiskLevel("medium")
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedLowerBound, actual.WideLowerValue.ElementAt(0));
            Assert.AreEqual(expectedUpperBound, actual.WideUpperValue.ElementAt(0));
        }
        
        [TestCategory("WideBound"), TestCategory("MediumRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear100TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedLowerBound = 1210000m;
            decimal expectedUpperBound = 33346750.84m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithRiskLevel("medium")
                .WithInvestmentTerm(100)
                .Build();

            //Act
            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedLowerBound, actual.WideLowerValue.ElementAt(100));
            Assert.AreEqual(expectedUpperBound, actual.WideUpperValue.ElementAt(100));

        }
    }
}
