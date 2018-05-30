using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentForecaster.Service.DTO
{
    public class AnnualForecast
    {
        public AnnualForecast(int index, decimal totalInvestmentAmount, decimal totalValueWideLower, decimal totalValueNarrowLower, decimal totalValueWideUpper, decimal totalValueNarrowUpper)
        {
            Index = index;
            TotalInvestmentAmount = totalInvestmentAmount;
            TotalValueNarrowLower = totalValueNarrowLower;
            TotalValueNarrowUpper = totalValueNarrowUpper;
            TotalValueWideLower = totalValueWideLower;
            TotalValueWideUpper = totalValueWideUpper;

        }

        public AnnualForecast(decimal lumpSum)
        {
            TotalInvestmentAmount = lumpSum;
            TotalValueNarrowLower = lumpSum;
            TotalValueNarrowUpper = lumpSum;
            TotalValueWideLower = lumpSum;
            TotalValueWideUpper = lumpSum;
        }

        public int Index { get; }
        public decimal TotalInvestmentAmount { get; }
        public decimal TotalValueWideLower { get; }
        public decimal TotalValueWideUpper { get; }
        public decimal TotalValueNarrowLower { get; }
        public decimal TotalValueNarrowUpper { get; }
    }
}
