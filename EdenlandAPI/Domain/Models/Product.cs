using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }
        public EUnitOfMeasurement UnitOfMeasurement { get; set; }

        // maps relationship beetwen Products and Categories. It indicaties that a product has one, and only one category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
