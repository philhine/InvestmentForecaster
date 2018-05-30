using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentForecast.Api.Models.Response
{
    public class CalculateResponse
    {
        public CalculateResponse(IEnumerable<decimal> totalValue, IEnumerable<decimal> wideLowerValue, IEnumerable<decimal> wideUpperValue, IEnumerable<decimal> narrowLowerValue, IEnumerable<decimal> narrowUpperValue)
        {
            TotalValue = totalValue;
            WideLowerValue = wideLowerValue;
            WideUpperValue = wideUpperValue;
            NarrowLowerValue = narrowLowerValue;
            NarrowUpperValue = narrowUpperValue;
        }

        public CalculateResponse(ModelStateDictionary modelState)
        {
            var validationMessages = modelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            ValidationMessages = validationMessages;
        }

        public CalculateResponse(IEnumerable<string> validationMessages)
        {
            ValidationMessages = validationMessages;
        }

        public IEnumerable<string> ValidationMessages { get; }

        public bool Success {
            get => ValidationMessages == null || !ValidationMessages.Any();
            set { }
        } 
        
        public IEnumerable<decimal> TotalValue { get; }
        public IEnumerable<decimal> WideLowerValue { get; }
        public IEnumerable<decimal> WideUpperValue { get; }
        public IEnumerable<decimal> NarrowLowerValue { get; }
        public IEnumerable<decimal> NarrowUpperValue { get; }

    }
}
