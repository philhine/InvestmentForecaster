using InvestmentForecaster.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecast.Service.Tests.TestBuilder
{
    public class ForecastRequestDtoBuilder
    {
        private int _years;
        private RiskLevel _riskLevel;
        private decimal _lumpSum;
        private decimal _monthlyInvestment;

        private const string Low = "low";

        public ForecastRequestDtoBuilder WithValidDefaults()
        {
            _years = 5;
            _riskLevel = RiskLevel.low;
            _lumpSum = 10000;
            _monthlyInvestment = 1000;
            return this;
        }

        public ForecastRequestDtoBuilder WithInvestmentTerm(int years)
        {
            _years = years;
            return this;
        }

        public ForecastRequestDtoBuilder WithLumpSum(decimal lumpSum)
        {
            _lumpSum = lumpSum;
            return this;
        }

        public ForecastRequestDtoBuilder WithMonthlyInvestment(decimal monthlyInvestment)
        {
            _monthlyInvestment = monthlyInvestment;
            return this;
        }

        public ForecastRequestDtoBuilder WithRiskLevel(RiskLevel riskLevel)
        {
            _riskLevel = riskLevel;
            return this;
        }

        public ForecastRequestDto Build()
        {
            return new ForecastRequestDto()
            {
                InvestmentTermInYears = _years,
                LumpSumInvestment = _lumpSum,
                MonthlyInvestment = _monthlyInvestment,
                RiskLevel = _riskLevel
            };
        }
    }
}
