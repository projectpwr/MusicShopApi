﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessInterfaces.Entities;


namespace DataAccess.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }

        public string Name { get; set; }
        public double Price { get; private set; }
        public string Description { get; set; }

        public int ProductTypeId { get; private set; }
        public int ManufacturerId { get; private set; }
        public ProductType Type { get; set; }
        public Manufacturer Manufacturer { get; set; }

        //link to specific product details metadata table via product type id and details id
        public int ProductDetailsId { get; set; }


 
    }
}
