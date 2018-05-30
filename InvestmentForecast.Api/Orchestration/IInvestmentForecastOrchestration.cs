using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.Api.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InvestmentForecast.Api.Orchestration
{
    public interface IInvestmentForecastOrchestration
    {
        CalculateResponse Calculate(CalculateRequest request);
    }
}