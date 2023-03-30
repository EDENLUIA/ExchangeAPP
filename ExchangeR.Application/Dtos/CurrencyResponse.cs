using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeR.Application.Dtos
{
    public class CurrencyResponse
    {
        public Guid Id { get; set; }
        public string Name { get; }
        public string Abbreviation { get; }
        public string Description { get; }

        public CurrencyResponse(Guid id, string name, string abbreviation, string description)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
            Description = description;
        }
    }
}
