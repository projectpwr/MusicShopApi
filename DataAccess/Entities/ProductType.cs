using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessInterfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class ProductType : IEntity
    {
        public int Id { get; private set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string Name { get; set; }

        public ProductType() { }
        
        public ProductType(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
