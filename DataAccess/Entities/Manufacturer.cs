using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessInterfaces;

namespace DataAccess.Entities
{
    public class Manufacturer : IManufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public Manufacturer()
        {
            this.Id= 1;
            this.Name = "default name";
        }

        public Manufacturer(string name)
        {
            this.Id = 099;
            this.Name = name;
        }


        public string getName()
        {
            return this.Name;
        }

    }
 
}
