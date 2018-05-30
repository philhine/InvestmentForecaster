using System.Collections.Generic;

namespace InvestmentForecaster.Service.Validation
{
    public interface IValidationService
    {
        IEnumerable<string> Validate(ForecastRequestDto request);
    }
}