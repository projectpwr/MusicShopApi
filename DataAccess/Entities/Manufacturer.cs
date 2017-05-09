using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAccessInterfaces;

namespace DataAccess.Entities
{
    public class Manufacturer : IManufacturer
    {
        public int Id { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }
        [Required]
        public int AddressId { get; private set; }
        public Address Address { get; private set; }

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
