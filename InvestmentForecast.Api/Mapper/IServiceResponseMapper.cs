using InvestmentForecast.Api.Models.Response;
using InvestmentForecaster.Service.Model;

namespace InvestmentForecast.Api.Mapper
{
    public interface IServiceResponseMapper
    {
        CalculateResponse MapCalculationResponse(ForecastResponseDto response);
    }
}