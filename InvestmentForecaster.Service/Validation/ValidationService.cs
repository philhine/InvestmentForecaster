using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentForecaster.Service.Validation
{
    //Performs business validation
    public class ValidationService : IValidationService
    { 
        public IEnumerable<string> Validate(ForecastRequestDto request)
        {
            //perform any business validation
            return new List<string>();
        }
    }
}
