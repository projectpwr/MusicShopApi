using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessInterfaces.Entities;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataAccess.Entities
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }

        public string Name { get; set; }
        public double Price { get; private set; }
        public string Description { get; set; }

        public int ProductTypeId { get; private set; }
        public int ManufacturerId { get; private set; }
        public ProductType Type { get; set; }
        public Manufacturer Manufacturer { get; set; }

        //link to specific product details metadata table via product type id and details id
        //would want an index on here
        public int ProductDetailsId { get; set; }


        public Product() { }
    }
}
