namespace ExchangeR.Api.Models
{
    public class ExchangeRateModel
    {
        public Guid Id { get; private set; }
        public Guid CurrencyFromId { get; private set; }
        public Guid CurrencyToId { get; private set; }
        public decimal Exchange { get; private set; }
        public bool IsActive { get; private set; } = true;
        protected ExchangeRateModel()
        {
            IsActive = true;
        }
        public ExchangeRateModel(Guid id, Guid currencyFromId, Guid currencyToId, decimal exchange)
        {
            Id = id;
            CurrencyFromId = currencyFromId;
            CurrencyToId = currencyToId;
            Exchange = exchange;
        }
    }
}
