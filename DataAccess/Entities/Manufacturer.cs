using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAccessInterfaces;
using DataAccessInterfaces.Entities;

namespace DataAccess.Entities
{
    public class Manufacturer : IManufacturer
    {
        public int Id { get; private set; }
        public byte[] RowVersion { get; private set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }
        [Required]
        public int AddressId { get; private set; }
        public Address Address { get; private set; }

        public Manufacturer(string name)
        {
            Name = name;
        }

        public Manufacturer(string name, int addressId)
        {
            Name = name;
            AddressId = addressId;
        }


        public string getName()
        {
            return this.Name;
        }

    }
 
}
