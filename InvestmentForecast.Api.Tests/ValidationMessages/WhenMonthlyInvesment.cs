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

namespace InvestmentForecast.Integration.Tests.ValidationMessages
{
    [TestClass]
    public class WhenMonthlyInvestment
    {
        private ApiHelper _apiHelper;

        [TestInitialize]
        public void TestSetup()
        {
            _apiHelper = new ApiHelper();
        }

        [TestCategory("InvalidRequest"), TestCategory("ValidMinMonthlyInvesment"), TestMethod]
        public async Task Is0_ThenNoValidationMessagesAreReturned()
        {
            //Arrange
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithMonthlyInvestment(0)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
        }

        [TestCategory("InvalidRequest"), TestCategory("ValidMaxMonthlyInvestment"), TestMethod]
        public async Task Is10000000_ThenNoValidationMessagesAreReturned()
        {
            //Arrange
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithMonthlyInvestment(10000000)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
        }

        [TestCategory("InvalidRequest"), TestCategory("InvalidMonthlyInvestment"), TestMethod]
        public async Task IsMinus1_ThenValidationMessagesAreReturned()
        {
            //Arrange
            int expectedValidationMessageCount = 1;
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithMonthlyInvestment(-1)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsFalse(actual.Success);
            Assert.AreEqual(actual.ValidationMessages.Count(), expectedValidationMessageCount);
        }

        [TestCategory("InvalidRequest"), TestCategory("InvalidInvestment"), TestMethod]
        public async Task Is10000001_ThenValidationMessagesAreReturned()
        {
            //Arrange
            int expectedValidationMessageCount = 1;
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithMonthlyInvestment(10000001)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsFalse(actual.Success);
            Assert.AreEqual(actual.ValidationMessages.Count(), expectedValidationMessageCount);
        }
    }
}
