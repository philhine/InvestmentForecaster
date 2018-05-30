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

namespace InvestmentForecast.Integration.Tests.WideBound
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
 

        [TestCategory("WideBound"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs30000_ThenYear0IsCorrect()
        {
            //Arrange
            decimal expectedLowerValue = 30000.00m;
            decimal expectedUpperValue = 30000.00m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithLumpSum(30000.00m)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedLowerValue, actual.WideLowerValue.ElementAt(0));
            Assert.AreEqual(expectedUpperValue, actual.WideUpperValue.ElementAt(0));

        }


        [TestCategory("WideBound"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear1TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedLowerValue = 22154.90m;
            decimal expectedUpperValue = 22464.12m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(1)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);
           
            //Assert
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(expectedLowerValue, actual.WideLowerValue.ElementAt(1));
            Assert.AreEqual(expectedUpperValue, actual.WideUpperValue.ElementAt(1));

        }

        [TestCategory("WideBound"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear100TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedLowerValue = 2082184.28m;
            decimal expectedUpperValue = 7579306.72m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(100)
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
