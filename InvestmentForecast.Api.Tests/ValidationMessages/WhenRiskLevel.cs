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
    public class WhenRiskLevel
    {
        private ApiHelper _apiHelper;

        [TestInitialize]
        public void TestSetup()
        {
            _apiHelper = new ApiHelper();
        }

        [TestCategory("ValidRequest"), TestCategory("ValidRiskLevel"), TestMethod]
        public async Task IsMixedCaseLow_ThenNoValidationMessages()
        {
            //Arrange
            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithRiskLevel("lOw")
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
        }

        [TestCategory("InvalidRequest"), TestCategory("InvalidRiskLevel"), TestMethod]
        public async Task IsOutOfBounds_ThenReturnsValidationMessage()
        {
            //Arrange
            int expectedValidationMessageCount = 1;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithRiskLevel("dummyRiskLevel")
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
