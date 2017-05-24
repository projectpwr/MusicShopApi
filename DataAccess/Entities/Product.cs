using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessInterfaces.Entities;


namespace DataAccess.Entities
{
    public class Product : IEntity
    {
        public int Id { get; private set; }
        public byte[] RowVersion { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int ProductTypeId { get; private set; }
        public int ManufacturerId { get; private set; }
        public ProductType Type { get; set; }
        public Manufacturer Manufacturer { get; set; }


        public Product(string name, double price, int productTypeId, int manufacturerId)
        {
            Name = name;
            Price = price;
            ProductTypeId = productTypeId;
            ManufacturerId = manufacturerId;
        }
    }
}
