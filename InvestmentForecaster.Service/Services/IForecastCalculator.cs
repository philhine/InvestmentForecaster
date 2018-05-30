using System.Collections.Generic;
using System.Threading.Tasks;
using InvestmentForecaster.Service.Bounds;
using InvestmentForecaster.Service.DTO;

namespace InvestmentForecaster.Service
{
    public interface IForecastCalculator
    {
        IEnumerable<AnnualForecast> Calculate(IBounds bounds, ForecastRequestDto request);
    }
}