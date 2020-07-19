using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EdenlandAPI.Resources
{
    public class ProductResource
    {
        // configure mapping between model class and our new resource class
        // mapping will be almost the same as the ones for other mapping, but here we have the transformation of our EUnitOfMeasurement
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
        public CategoryResources Category { get; set; }
    }
}
