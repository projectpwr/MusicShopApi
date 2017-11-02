using DataAccessInterfaces.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class UserAddress : IEntity
    {
        
        [Key]
        [JsonProperty(Required = Required.Default)]
        public int Id { get; private set; }
        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }
        public virtual User User { get; set; }
        public virtual Address Address { get; set; }

        private UserAddress() { }
    }
}
