using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecaster.Service.Bounds
{
    public class BoundsFactory : IBoundsFactory
    {
        public IBounds GetBounds(RiskLevel riskLevel)
        {
            IBounds bounds;

            switch (riskLevel)
            {
                case RiskLevel.low:
                    bounds = new LowRiskBounds();
                    break;
                case RiskLevel.medium:
                    bounds = new MediumRiskBounds();
                    break;
                case RiskLevel.high:
                    bounds = new HighRiskBounds();
                    break;
                default:
                    throw new ArgumentException("Risk level is out of bounds");
            }

            return bounds;
        }
    }
}
