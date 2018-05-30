using InvestmentForecaster.Service.DTO;
using InvestmentForecaster.Service.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentForecaster.Service
{
    public interface IInvestmentForecastService
    {
        ForecastResponseDto CalculateAnnualGrowth(ForecastRequestDto request);
    }
}
