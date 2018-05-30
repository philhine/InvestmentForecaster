using InvestmentForecast.Api.Models.Request;
using InvestmentForecaster.Service;

namespace InvestmentForecast.Api.Mapper
{
    public interface IServiceRequestMapper
    {
        ForecastRequestDto MapCalculation(CalculateRequest model);
    }
}