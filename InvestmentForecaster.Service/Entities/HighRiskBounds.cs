using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecaster.Service.Bounds
{
    public class HighRiskBounds : IBounds
    {
        public decimal WideLowerBound { get => 1; }
        public decimal WideUpperBound { get => 7; }
        public decimal NarrowLowerBound { get => 2; }
        public decimal NarrowUpperBound { get => 4; }


    }
}
