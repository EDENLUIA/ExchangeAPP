using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeR.Domain
{
    public class ExchangeRate
    {
        public Guid Id { get; private set; }
        public Guid CurrencyFromId { get; private set; }
        public Guid CurrencyToId { get; private set; }
        public decimal Exchange { get; private set; }
        public bool IsActive { get; private set; } = true;
        protected ExchangeRate()
        {
            IsActive = true;
        }
        public ExchangeRate(Guid id, Guid currencyFromId, Guid currencyToId, decimal exchange)
        {
            Id = id;
            CurrencyFromId = currencyFromId;
            CurrencyToId = currencyToId;
            Exchange = exchange;
        }

    }
}
