using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessInterfaces.Entities;

namespace DataAccess.Entities
{
    public class ProductType : IEntity
    {
        public int Id { get; private set; }
        public byte[] RowVersion { get; private set; }
        public string Name { get; private set; }


        public ProductType(string name)
        {
            Name = name;
        }
    }
}
