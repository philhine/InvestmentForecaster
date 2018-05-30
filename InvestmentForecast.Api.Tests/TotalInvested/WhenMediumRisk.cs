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

namespace InvestmentForecast.Integration.Tests.TotalInvested
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


        [TestCategory("TotalInvested"), TestCategory("MediumRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs30000_ThenYear0TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedTotalInvestment = 30000.00m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithRiskLevel("medium")
                .WithLumpSum(expectedTotalInvestment)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedTotalInvestment, actual.TotalValue.ElementAt(0));

        }
        
        [TestCategory("TotalInvested"), TestCategory("MediumRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear100TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedTotalInvestment = 1210000m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithRiskLevel("medium")
                .WithInvestmentTerm(100)
                .Build();

            //Act
            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(expectedTotalInvestment, actual.TotalValue.ElementAt(100));

        }
    }
}
