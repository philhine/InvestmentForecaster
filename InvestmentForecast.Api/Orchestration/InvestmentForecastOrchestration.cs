using InvestmentForecast.Api.Mapper;
using InvestmentForecast.Api.Models.Request;
using InvestmentForecast.Api.Models.Response;
using InvestmentForecaster.Service;
using InvestmentForecaster.Service.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentForecast.Api.Orchestration
{
    public class InvestmentForecastOrchestration : IInvestmentForecastOrchestration
    {
        IInvestmentForecastService _orchestrator;
        IServiceRequestMapper _requestMapper;
        IServiceResponseMapper _responseMapper;

        public InvestmentForecastOrchestration(IServiceRequestMapper requestMapper, IServiceResponseMapper responseMapper,
            IInvestmentForecastService orchestrator)
        {
            _requestMapper = requestMapper;
            _responseMapper = responseMapper;
            _orchestrator = orchestrator;
        }

        public CalculateResponse Calculate(CalculateRequest request)
        {
            ForecastRequestDto requestDto = _requestMapper.MapCalculation(request);
            ForecastResponseDto responseDto = _orchestrator.CalculateAnnualGrowth(requestDto);

            return _responseMapper.MapCalculationResponse(responseDto);
        }

    }
}
