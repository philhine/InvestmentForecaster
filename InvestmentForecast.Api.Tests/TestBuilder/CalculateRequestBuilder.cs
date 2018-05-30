using InvestmentForecast.Api.Models.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecast.Integration.Tests.TestBuilder
{
    public class CalculateRequestBuilder
    {
        private int _years;
        private string _riskLevel;
        private decimal _lumpSum;
        private decimal _monthlyInvestment;

        private const string Low = "low";

        public CalculateRequestBuilder WithValidDefaults()
        {
            _years = 5;
            _riskLevel = Low;
            _lumpSum = 10000;
            _monthlyInvestment = 1000;
            return this;
        }

        public CalculateRequestBuilder WithInvestmentTerm(int years)
        {
            _years = years;
            return this;
        }

        public CalculateRequestBuilder WithLumpSum(decimal lumpSum)
        {
            _lumpSum = lumpSum;
            return this;
        }

        public CalculateRequestBuilder WithMonthlyInvestment(decimal monthlyInvestment)
        {
            _monthlyInvestment = monthlyInvestment;
            return this;
        }

        public CalculateRequestBuilder WithRiskLevel(string riskLevel)
        {
            _riskLevel = riskLevel;
            return this;
        }

        public CalculateRequest Build()
        {
            return new CalculateRequest()
            {
                InvestmentTermInYears = _years,
                LumpSumInvestment = _lumpSum,
                MonthlyInvestment = _monthlyInvestment,
                RiskLevel = _riskLevel
            };
        }
    }
}
