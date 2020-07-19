using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Domain.Models
{
    public class Category
    {
        // simply model POCO - Plain Old CLR Object - it means, the class will have only properties to describe its basic information
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Product> Products { get; set; } = new List<Product>();
    }
}
