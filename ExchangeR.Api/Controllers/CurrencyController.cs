using ExchangeR.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExchangeR.Application;
using ExchangeR.Domain;
using Azure.Core;
using ExchangeR.Api.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeR.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly CurrencyService _currencyService;

        public CurrencyController(ILogger<CurrencyController> logger, CurrencyService currencyService)
        {            
            _logger = logger;
            _currencyService = currencyService;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<CurrencyResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _currencyService.GetCurrencies();
            return Ok(result);
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(GenericResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create( CurrencyModel request)
        {
            Currency _currency = new Currency(new Guid(), request.Name, request.Abbreviation, request.Description);

            var result = await _currencyService.CreateCurrency(_currency);

            return Ok(result);
        }
    }
}
