using InvestmentForecast.Api;
using InvestmentForecast.Api.Controllers;
using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.Api.Models.Response;
using InvestmentForecast.Integration.Tests.TestBuilder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
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
    public class WhenLowRisk
    {
        private ApiHelper _apiHelper;

        [TestInitialize]
        public void TestSetup()
        {
            _apiHelper = new ApiHelper();
        }
 

        [TestCategory("TotalInvested"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs30000_ThenYear0TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedTotalInvestment = 30000.00m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithLumpSum(expectedTotalInvestment)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedTotalInvestment, actual.TotalValue.ElementAt(0));

        }


        [TestCategory("TotalInvested"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear1TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedTotalInvestment = 22000.00m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(1)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);
           
            //Assert
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(expectedTotalInvestment, actual.TotalValue.ElementAt(1));

        }

        [TestCategory("TotalInvested"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear7TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedTotalInvestment = 94000m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(7)
                .Build();

            //Act
            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);
            
            //Assert
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(expectedTotalInvestment, actual.TotalValue.ElementAt(7));

        }

        [TestCategory("TotalInvested"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear100TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedTotalInvestment = 1210000m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
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
