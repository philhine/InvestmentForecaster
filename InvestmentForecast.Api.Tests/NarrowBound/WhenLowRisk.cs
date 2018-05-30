using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.Integration.Tests.TestBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentForecast.Integration.Tests.NarrowBound
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
 

        [TestCategory("NarrowBound"), TestCategory("LowRisk"), TestMethod]
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
            Assert.AreEqual(expectedLowerValue, actual.NarrowLowerValue.ElementAt(0));
            Assert.AreEqual(expectedUpperValue, actual.NarrowUpperValue.ElementAt(0));

        }


        [TestCategory("NarrowBound"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear1TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedLowerValue = 22232.28m;
            decimal expectedUpperValue = 22386.89m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(1)
                .Build();

            var contents = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            //Act

            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);
           
            //Assert
            Assert.IsTrue(actual.Success);

            Assert.AreEqual(expectedLowerValue, actual.NarrowLowerValue.ElementAt(1));
            Assert.AreEqual(expectedUpperValue, actual.NarrowUpperValue.ElementAt(1));

        }

        [TestCategory("NarrowBound"), TestCategory("LowRisk"), TestMethod]
        public async Task AndMonthlyInvestmentIs1000_AndLumpSumIs10000_ThenYear100TotalInvestedIsCorrect()
        {
            //Arrange
            decimal expectedLowerValue = 2808782.36m;
            decimal expectedUpperValue = 5367931.32m;

            CalculateRequest request = new CalculateRequestBuilder()
                .WithValidDefaults()
                .WithInvestmentTerm(100)
                .Build();

            //Act
            Tests.Model.ForecastViewModel actual = await _apiHelper.Calculate(request);

            //Assert
            Assert.IsTrue(actual.Success);
            Assert.AreEqual(expectedLowerValue, actual.NarrowLowerValue.ElementAt(100));
            Assert.AreEqual(expectedUpperValue, actual.NarrowUpperValue.ElementAt(100));

        }
    }
 }
