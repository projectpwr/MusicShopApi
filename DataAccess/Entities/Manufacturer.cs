using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataAccessInterfaces;
using DataAccessInterfaces.Entities;
using Newtonsoft.Json;

namespace DataAccess.Entities
{
    public class Manufacturer : IEntity
    {
        [Key]
        public int Id { get; set; }
     
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }


        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        private Manufacturer() { }
    }
 
}
