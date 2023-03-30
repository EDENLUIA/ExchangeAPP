using ExchangeR.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace ExchangeR.Infrastructure.Config
{
    public class ExchangeRateConfiguration
    {
        public ExchangeRateConfiguration(EntityTypeBuilder<ExchangeRate> entityBuilder)
        {

            entityBuilder.ToTable("ExchangeRate", "Exchange");

            entityBuilder.HasKey(x => x.Id);

            // Mapping
            entityBuilder.Property(c => c.Exchange).HasPrecision(10, 2).IsRequired();
            entityBuilder.Property(c => c.IsActive).IsRequired();
            entityBuilder.Property(e => e.CurrencyFromId);
            entityBuilder.HasOne<Currency>().WithMany().HasForeignKey(e => e.CurrencyFromId);
            entityBuilder.Property(e => e.CurrencyToId);
            entityBuilder.HasOne<Currency>().WithMany().HasForeignKey(e => e.CurrencyToId);


        }
    }
}
