using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExchangeR.Domain
{
    public class Currency
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public string Description { get; private set; }
        public bool isActive { get; private set; } = true;

        protected Currency()
        {

        }
       
        public Currency(Guid id , string name, string abbreviation, string descripcion)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
            Description = descripcion;
        }
    }
}
