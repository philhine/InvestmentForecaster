using InvestmentForecast.Api.Mapper;
using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.Api.Models.Response;
using InvestmentForecast.Api.Orchestration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentForecast.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class InvestmentForecastController : Controller
    {
        //IInvestmentForecastOrchestrator _orchestrator;
        IInvestmentForecastOrchestration _orchestrator;
        IServiceResponseMapper _responseMapper;

        public InvestmentForecastController(IInvestmentForecastOrchestration orchestrator)
        {
            _orchestrator = orchestrator;
        }

        /// <summary>
        /// Calculates the monthly annual growth value using monthly payments. Uses model binding validation.
        /// </summary>
        [HttpPost]
        public IActionResult Calculate([FromBody] CalculateRequest request)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new CalculateResponse(ModelState));
 
                return Ok(_orchestrator.Calculate(request));
            }
            catch (Exception ex)
            {
                //log details
                return BadRequest("An exception occurred");
            }
        }

    }
}