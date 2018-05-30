using InvestmentForecaster.Service;
using InvestmentForecaster.Service.Bounds;
using InvestmentForecaster.Service.DTO;
using InvestmentForecaster.Service.Model;
using InvestmentForecaster.Service.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InvestmentForecast.Service.Tests
{
    [TestClass]
    public class WhenCalculateAnnualGrowthIsCalled
    {
        IInvestmentForecastService _service;
        Mock<IBoundsFactory> _boundsFactory;

        Mock<IValidationService> _validationService;
        Mock<IForecastCalculator> _forecastCalculator;
            /*
             *             _boundsFactory = boundsFactory;
            _forecastCalculator = forecastCalculator;
            _validator = validationService;
             */

        [TestInitialize]
        public void Setup()
        {
            _boundsFactory = new Mock<IBoundsFactory>();
            _forecastCalculator = new Mock<IForecastCalculator>();
            _validationService = new Mock<IValidationService>();
            _service = new InvestmentForecastService(_boundsFactory.Object, _forecastCalculator.Object, _validationService.Object);
        }

        [TestMethod]
        public void ThenValidationServiceIsCalled()
        {
            //Arrange
            var request = CreateRequest();

            //Act
            _service.CalculateAnnualGrowth(request);

            //Assert
            _validationService.Verify(x => x.Validate(request));
        }

        [TestMethod]
        public void ThenValidationBoundsFactoryIsCalled()
        {
            //Arrange
            var request = CreateRequest();

            //Act
            _service.CalculateAnnualGrowth(request);

            //Assert
            _boundsFactory.Verify(x => x.GetBounds(It.IsAny<RiskLevel>()));
        }

        [TestMethod]
        public void ThenValidationForecastCalculatorIsCalled()
        {
            //Arrange
            var request = CreateRequest();

            //Act
            _service.CalculateAnnualGrowth(request);

            //Assert
            _forecastCalculator.Verify(x => x.Calculate(It.IsAny<IBounds>(), request));
        }

        [TestMethod]
        public void ThenTheResultFromForecastCalculatorIsReturned()
        {
            //Arrange
            var request = CreateRequest();
            var annualForecastResults = new List<AnnualForecast>()
            {
                new AnnualForecast(1000)
            };

            var expectedForecastResponseDto = new ForecastResponseDto(annualForecastResults);
            _forecastCalculator.Setup(x => x.Calculate(It.IsAny<IBounds>(), request)).Returns(annualForecastResults);

            //Act
            var actual = _service.CalculateAnnualGrowth(request);

            //Assert
            Assert.AreEqual(expectedForecastResponseDto.AnnualForecasts.ElementAt(0).TotalInvestmentAmount, actual.AnnualForecasts.ElementAt(0).TotalInvestmentAmount);
            Assert.AreEqual(expectedForecastResponseDto.AnnualForecasts.ElementAt(0).TotalValueNarrowLower, actual.AnnualForecasts.ElementAt(0).TotalValueNarrowLower);
            Assert.AreEqual(expectedForecastResponseDto.AnnualForecasts.ElementAt(0).TotalValueNarrowUpper, actual.AnnualForecasts.ElementAt(0).TotalValueNarrowUpper);
            Assert.AreEqual(expectedForecastResponseDto.AnnualForecasts.ElementAt(0).TotalValueWideLower, actual.AnnualForecasts.ElementAt(0).TotalValueWideLower);
            Assert.AreEqual(expectedForecastResponseDto.AnnualForecasts.ElementAt(0).TotalValueWideUpper, actual.AnnualForecasts.ElementAt(0).TotalValueWideUpper);
        }

        [TestMethod]
        public void AndThereAreValidationMessagesThenValidationMessagesAreReturned()
        {
            //Arrange
            var request = CreateRequest();
            var validationMessages = new List<string>()
            {
                "dummyValMsg1",
                "dummyValMsg2"
            };

            var expectedForecastResponseDto = new ForecastResponseDto(validationMessages);
            _validationService.Setup(x => x.Validate(request)).Returns(validationMessages);

            //Act
            var actual = _service.CalculateAnnualGrowth(request);

            //Assert
            Assert.AreEqual(expectedForecastResponseDto.ValidationMessages.ElementAt(0), actual.ValidationMessages.ElementAt(0));
            Assert.AreEqual(expectedForecastResponseDto.ValidationMessages.ElementAt(1), actual.ValidationMessages.ElementAt(1));
        }

        [TestMethod]
        public void ThenTheBoundsFromFactoryArePassedToForecastCalculator()
        {
            //Arrange
            var request = CreateRequest();
            IBounds bounds = new MediumRiskBounds();

            _boundsFactory.Setup(x => x.GetBounds(RiskLevel.medium)).Returns(bounds);

            //Act
            var actual = _service.CalculateAnnualGrowth(request);

            //Assert
            _forecastCalculator.Verify(x => x.Calculate(bounds, request));
        }

        public ForecastRequestDto CreateRequest()
        {
            return new ForecastRequestDto()
            {
                InvestmentTermInYears = 5,
                LumpSumInvestment = 10000,
                MonthlyInvestment = 1000,
                RiskLevel = RiskLevel.medium
            };
        }
    }
}
