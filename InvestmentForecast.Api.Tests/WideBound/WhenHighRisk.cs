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
    public class WhenHighRisk
    {
        private ApiHelper _apiHelper;

        [TestInitialize]
        public void TestSetup()
        {
            _apiHelper = new ApiHelper();
        }


        [TestCategory("WideBound"), TestCategory("HighRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs30000_ThenYear0IsCorrect()
        {
            //Arrange
            decimal expectedLowerValue = 30000.00m;
            decimal expectedUpperValue = 30000.00m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithRiskLevel("high")
                .WithLumpSum(30000)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedLowerValue, actual.WideLowerValue.ElementAt(0));
            Assert.AreEqual(expectedUpperValue, actual.WideUpperValue.ElementAt(0));

        }
        
        [TestCategory("WideBound"), TestCategory("HighRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear100IsCorrect()
        {
            //Arrange
            decimal expectedLowerValue = 2082184.28m;
            decimal expectedUpperValue = 161965818.25m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(100)
                .WithRiskLevel("high")
                .Build();

            //Act
            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedLowerValue, actual.WideLowerValue.ElementAt(100));
            Assert.AreEqual(expectedUpperValue, actual.WideUpperValue.ElementAt(100));
        }
    }
}
