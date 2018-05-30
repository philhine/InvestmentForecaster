using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecaster.Service
{
    public class ForecastRequestDto
    {
        public decimal LumpSumInvestment { get; set; }

        public decimal MonthlyInvestment { get; set; }

         public int InvestmentTermInYears { get; set; }

        public RiskLevel RiskLevel { get; set; }
    }

    public enum RiskLevel
    {
        low,
        medium,
        high
    }
}
