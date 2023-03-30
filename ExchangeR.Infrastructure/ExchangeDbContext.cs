using ExchangeR.Domain;
using ExchangeR.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeR.Infrastructure
{
    public class ExchangeDbContext : DbContext
    {
        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options)
        : base(options)
        {

        }
        public DbSet<Currency> Currency => Set<Currency>();
        public DbSet<ExchangeRate> ExchangeRate => Set<ExchangeRate>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CurrencyConfiguration(modelBuilder.Entity<Currency>());
            new ExchangeRateConfiguration(modelBuilder.Entity<ExchangeRate>());

            base.OnModelCreating(modelBuilder);
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
