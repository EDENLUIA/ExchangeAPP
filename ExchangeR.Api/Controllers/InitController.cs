using ExchangeR.Api.Models;
using ExchangeR.Application.Dtos;
using ExchangeR.Application;
using ExchangeR.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExchangeR.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace ExchangeR.Api.Controllers
{
    [Authorize]    
    [ApiController]
    [Route("[controller]")]
    public class InitController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly CurrencyService _currencyService;
        private readonly ExchangeDbContext _exchangeDbContext;

        public InitController(ILogger<CurrencyController> logger, CurrencyService currencyService, ExchangeDbContext exchangeDbContext)
        {
            _logger = logger;
            _currencyService = currencyService;
            _exchangeDbContext = exchangeDbContext;
        }


        [HttpPost("createData")]
        [ProducesResponseType(typeof(GenericResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateData()
        {

            Currency Currenty_1 = new Currency(Guid.NewGuid(), "SOLES", "SOL", "MONEDA PERU");
            Currency Currenty_2 = new Currency(Guid.NewGuid(), "DOLARES", "USD", "MONEDA EEUU");
            Currency Currenty_3 = new Currency(Guid.NewGuid(), "EURO", "EUR", "MONEDA EUROPA");
           

            var result1 = await _currencyService.CreateCurrency(Currenty_1);
            var result2 = await _currencyService.CreateCurrency(Currenty_2);
            var result3 = await _currencyService.CreateCurrency(Currenty_3);

            var solesCurrency = _exchangeDbContext.Currency.FirstOrDefault(x => x.Abbreviation == "SOL");
            var dolarCurrency = _exchangeDbContext.Currency.FirstOrDefault(x => x.Abbreviation == "USD");
            var euroCurrency = _exchangeDbContext.Currency.FirstOrDefault(x => x.Abbreviation == "EUR");


            _exchangeDbContext.ExchangeRate.AddRange(new List<ExchangeRate> {
                        new ExchangeRate(Guid.NewGuid(),solesCurrency!.Id, dolarCurrency!.Id, 3.16m),
                        new ExchangeRate(Guid.NewGuid(),solesCurrency!.Id, euroCurrency!.Id, 4.44m)
                    });

            await _exchangeDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
