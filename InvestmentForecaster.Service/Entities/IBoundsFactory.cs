namespace InvestmentForecaster.Service.Bounds
{
    public interface IBoundsFactory
    {
        IBounds GetBounds(RiskLevel riskLevel);
    }
}