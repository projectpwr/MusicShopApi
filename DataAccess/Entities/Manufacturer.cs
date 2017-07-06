using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAccessInterfaces;
using DataAccessInterfaces.Entities;

namespace DataAccess.Entities
{
    public class Manufacturer : IEntity
    {
        public int Id { get; set; }
        public byte[] RowVersion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }





    }
 
}
