using InvestmentForecaster.Service.Bounds;
using InvestmentForecaster.Service.DTO;
using InvestmentForecaster.Service.Model;
using InvestmentForecaster.Service.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentForecaster.Service
{
    public class InvestmentForecastService : IInvestmentForecastService
    {
        private IBoundsFactory _boundsFactory;
        private IForecastCalculator _forecastCalculator;
        private IValidationService _validator;

        public InvestmentForecastService(IBoundsFactory boundsFactory, IForecastCalculator forecastCalculator, 
            IValidationService validationService)
        {
            _boundsFactory = boundsFactory;
            _forecastCalculator = forecastCalculator;
            _validator = validationService;
        }

        public ForecastResponseDto CalculateAnnualGrowth(ForecastRequestDto request)
        {
            try
            {
                IEnumerable<string> validationMessages = _validator.Validate(request);

                if (validationMessages != null && validationMessages.Any())
                {
                    return new ForecastResponseDto(validationMessages);
                }

                IBounds bounds = _boundsFactory.GetBounds(request.RiskLevel);
                IEnumerable<AnnualForecast> annualForecasts = _forecastCalculator.Calculate(bounds, request);

                return new ForecastResponseDto(annualForecasts);
            }
            catch(Exception ex)
            {
                //logging here
                throw;
            }
        }
    }
}
