using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeR.Application.Dtos
{
    public class CurrencyExchangeResponse
    {
        public decimal Amount { get; set; }
        public decimal AmountExchange { get; set; }
        public string CurrencyFrom { get; set; }
        public string CurrencyTo { get; set; }
        public decimal ExchangeRate { get; set; }
        public CurrencyExchangeResponse()
        {

        }
        public CurrencyExchangeResponse(decimal amount, decimal amountExchange, string currencyFrom, string currencyTo, decimal exchangeRate)
        {
            Amount = amount;
            AmountExchange = amountExchange;
            CurrencyFrom = currencyFrom;
            CurrencyTo = currencyTo;
            ExchangeRate = exchangeRate;
        }
    }
}
