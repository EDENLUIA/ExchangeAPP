namespace ExchangeR.Api.Models
{
    public class CurrencyModel
    {
       
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public string Description { get; private set; }
        public bool isActive { get; private set; }

        public CurrencyModel(Guid id,string name, string abbreviation, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.Description = description;
           
        }
    }
}
