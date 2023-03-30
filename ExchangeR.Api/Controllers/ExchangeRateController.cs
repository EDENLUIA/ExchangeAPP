using ExchangeR.Api.Models;
using ExchangeR.Application.Dtos;
using ExchangeR.Application;
using ExchangeR.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExchangeR.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeR.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ExchangeRateService _exchangeRateService;

        public ExchangeRateController(ILogger<ExchangeRateController> logger, ExchangeRateService exchangeRateService)
        {
            _logger = logger;
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<CurrencyResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _exchangeRateService.GetExchangeRates();
            return Ok(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(GenericResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ExchangeRateModel request)
        {
            ExchangeRate _exchangeRate = new ExchangeRate(new Guid(), request.CurrencyFromId, request.CurrencyToId, request.Exchange);

            var result = await _exchangeRateService.CreateExchangeRate(_exchangeRate);

            return Ok(result);
        }

        [HttpPut("update")]
        [ProducesResponseType(typeof(GenericResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] ExchangeRateModel request)
        {
            ExchangeRate _exchangeRate = new ExchangeRate(request.Id, request.CurrencyFromId, request.CurrencyToId, request.Exchange);

            var result = await _exchangeRateService.UpdateExchangeRate(_exchangeRate);

            return Ok(result);
        }

        [HttpPost("calculateExchange")]
        [ProducesResponseType(typeof(GenericResult<CurrencyExchangeResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalculateExchange(RequestCalculateExchange request)
        {
           
            var result = await _exchangeRateService.CalculateExchange(request);

            return Ok(result);
        }
    }
}
