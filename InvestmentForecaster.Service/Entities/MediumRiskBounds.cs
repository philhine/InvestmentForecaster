using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecaster.Service.Bounds
{
    public class MediumRiskBounds : IBounds
    {
        public decimal WideLowerBound { get => 0; }
        public decimal WideUpperBound { get => 5; }
        public decimal NarrowLowerBound { get => 1.5m; }
        public decimal NarrowUpperBound { get => 3.5m; }
    }
}
