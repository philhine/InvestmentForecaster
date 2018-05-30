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
    public class WhenLumpSum
    {
        private ApiHelper _apiHelper;

        [TestInitialize]
        public void TestSetup()
        {
            _apiHelper = new ApiHelper();
        }

        [TestCategory("InvalidRequest"), TestCategory("ValidMinLumpSum"), TestMethod]
        public async Task Is0_ThenNoValidationMessagesAreReturned()
        {
            //Arrange
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithLumpSum(0)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
        }

        [TestCategory("InvalidRequest"), TestCategory("ValidMaxLumpSum"), TestMethod]
        public async Task Is100000000_ThenNoValidationMessagesAreReturned()
        {
            //Arrange
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithLumpSum(100000000)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
        }

        [TestCategory("InvalidRequest"), TestCategory("InvalidLumpSum"), TestMethod]
        public async Task IsMinus1_ThenValidationMessagesAreReturned()
        {
            //Arrange
            int expectedValidationMessageCount = 1;
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithLumpSum(-1)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsFalse(actual.Success);
            Assert.AreEqual(actual.ValidationMessages.Count(), expectedValidationMessageCount);
        }

        [TestCategory("InvalidRequest"), TestCategory("InvalidLumpSum"), TestMethod]
        public async Task Is100000001_ThenValidationMessagesAreReturned()
        {
            //Arrange
            int expectedValidationMessageCount = 1;
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithLumpSum(100000001)
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
