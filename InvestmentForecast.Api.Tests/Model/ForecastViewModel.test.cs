using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecast.Integration.Tests.Model
{
    public class ForecastViewModel
    {
        public IEnumerable<string> ValidationMessages { get; set; }

        public bool Success { get; set; }

        public IEnumerable<decimal> TotalValue { get; set; }
        public IEnumerable<decimal> WideLowerValue { get; set; }
        public IEnumerable<decimal> WideUpperValue { get; set; }
        public IEnumerable<decimal> NarrowLowerValue { get; set; }
        public IEnumerable<decimal> NarrowUpperValue { get; set; }

    }

}
