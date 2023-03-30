using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeR.Application.Dtos
{
    public class ExchangeRateResponse
    {
        public Guid Id { get; private set; }
        public string CurrencyFrom { get; private set; }
        public string CurrencyTo { get; private set; }
        public decimal Exchange { get; private set; }
        public bool IsActive { get; private set; } = true;
        protected ExchangeRateResponse()
        {
            IsActive = true;
        }
        public ExchangeRateResponse(Guid id, string currencyFrom, string currencyTo, decimal exchange)
        {
            Id = id;
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            Exchange = exchange;
        }
    }
}
