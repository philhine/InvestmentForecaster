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

namespace InvestmentForecast.Integration.Tests.ValidationErrors
{
    [TestClass]
    public class WhenRequest
    {
        private ApiHelper _apiHelper;

        [TestInitialize]
        public void TestSetup()
        {
            _apiHelper = new ApiHelper();
        }

        [TestCategory("InvalidRequest"), TestCategory("InvalidTerm"), TestMethod]
        public async Task HasAnInvestmentTermOf0_ThenAValidationMessageIsReturned()
        {
            //Arrange
            int expectedValidationMessageCount = 1;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(0)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsFalse(actual.Success);
            Assert.AreEqual(actual.ValidationMessages.Count(), expectedValidationMessageCount);
        }

        [TestCategory("ValidRequest"), TestCategory("ValidTerm"), TestMethod]
        public async Task HasAnInvestmentTermOf100_ThenNoValidationMessagesAreReturned()
        {
            //Arrange
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(100)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
        }

        [TestCategory("InvalidRequest"), TestCategory("InvalidTerm"), TestMethod]
        public async Task HasAnInvestmentTermOf101_ThenAValidationMessageIsReturned()
        {
            //Arrange
            int expectedValidationMessageCount = 1;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(101)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsFalse(actual.Success);
            Assert.AreEqual(actual.ValidationMessages.Count(), expectedValidationMessageCount);
        }

        [TestCategory("InvalidRequest"), TestCategory("InvalidTerm"), TestMethod]
        public async Task HasAnInvestmentTermOfMinus1_ThenAValidationMessageIsReturned()
        {
            //Arrange
            int expectedValidationMessageCount = 1;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(-1)
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
