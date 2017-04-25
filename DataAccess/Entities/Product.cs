using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int Price { get; set; }
        public int ProductTypeId { get; set; }
        public int ManufacturerId { get; set; }

        public ProductType Type { get; set; }
        public Manufacturer Manufacturer { get; set; }
    }

}
