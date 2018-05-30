using InvestmentForecast.Api.Models.Response;
using InvestmentForecaster.Service.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentForecast.Api.Mapper
{
    public class ServiceResponseMapper : IServiceResponseMapper
    {
        public CalculateResponse MapCalculationResponse (ForecastResponseDto response)
        {
            var annualForecasts = response.AnnualForecasts;

            var totalInvestmentAmount = annualForecasts.Select(x => x.TotalInvestmentAmount);
            var totalWideLower = annualForecasts.Select(x => x.TotalValueWideLower);
            var totalWideUpper = annualForecasts.Select(x => x.TotalValueWideUpper);
            var totalNarrowLower = annualForecasts.Select(x => x.TotalValueNarrowLower);
            var totalNarrowUpper = annualForecasts.Select(x => x.TotalValueNarrowUpper);

            return new CalculateResponse(totalInvestmentAmount, totalWideLower, totalWideUpper, totalNarrowLower, totalNarrowUpper);
        }
    }
}
