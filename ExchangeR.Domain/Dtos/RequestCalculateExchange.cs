using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExchangeR.Domain.Dtos
{
    public class RequestCalculateExchange
    {
        public Guid CurrencyFromId { get; set; }
        public Guid CurrencyToId { get; set; }
        public decimal Amount { get; set; }
        public RequestCalculateExchange(Guid currencyFromId, Guid currencyToId, decimal amount)
        {
            CurrencyFromId = currencyFromId;
            CurrencyToId = currencyToId;
            Amount = amount;
        }
    }
}
