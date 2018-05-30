using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestmentForecast.Api.Models.Request
{
    public class CalculateRequest : IValidatableObject
    {
        const double MaxLumpSumInvestment = 100000000.00;
        const double MaxMonthlyInvestment = 10000000.00;
        const int MaxYears = 100;

        [Range(0, MaxLumpSumInvestment)]
        public decimal LumpSumInvestment { get; set; }

        [Range(0, MaxMonthlyInvestment)]
        public decimal MonthlyInvestment { get; set; }

        [Required]
        [Range(1, MaxYears)]
        public int InvestmentTermInYears { get; set; }

        public string RiskLevel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            switch (RiskLevel.ToLower())
            {
                case "low":
                case "medium":
                case "high":
                   break;
                default:
                    yield return new ValidationResult($"Invalid risk level use low, medium, high", new[] { nameof(RiskLevel) });
                    break;
            }
        }
    }
}
