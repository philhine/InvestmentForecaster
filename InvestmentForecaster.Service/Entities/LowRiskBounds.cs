using System;

namespace InvestmentForecaster.Service.Bounds
{
    public class LowRiskBounds : IBounds
    {
        public decimal WideLowerBound { get => 1; }
        public decimal WideUpperBound { get => 3;  }
        public decimal NarrowLowerBound { get => 1.5m; }
        public decimal NarrowUpperBound { get => 2.5m; }
    }
}
