using ExchangeR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ExchangeR.Infrastructure.Config
{
    public class CurrencyConfiguration 
    {
        public CurrencyConfiguration(EntityTypeBuilder<Currency> entityBuilder)
        {

            entityBuilder.ToTable("Currency", "Exchange");

            entityBuilder.HasKey(x => x.Id);
       

            // Mapping
            entityBuilder.Property(c => c.Name).IsRequired();
            entityBuilder.Property(c => c.Abbreviation).IsRequired();
            entityBuilder.Property(c => c.Description).IsRequired();
            entityBuilder.Property(c => c.isActive).IsRequired();


        }
    }
}
