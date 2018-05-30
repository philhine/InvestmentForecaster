using InvestmentForecast.Api.Models.Request;
using InvestmentForecaster.Service;
using System;

namespace InvestmentForecast.Api.Mapper
{
    public class ServiceRequestMapper : IServiceRequestMapper
    {
        public ForecastRequestDto MapCalculation(CalculateRequest model)
        {
            RiskLevel _riskLevel;
            if (!Enum.TryParse(model.RiskLevel.ToLower(), out _riskLevel))
            {
                throw new ArgumentException("Risk level: '{model.RiskLevel}' was unexpected.");
            }
            
            return new ForecastRequestDto()
            {
                InvestmentTermInYears = model.InvestmentTermInYears,
                LumpSumInvestment = model.LumpSumInvestment,
                MonthlyInvestment = model.MonthlyInvestment,
                RiskLevel = _riskLevel
            };
        }
    }
}
