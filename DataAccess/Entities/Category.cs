using DataAccessInterfaces.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }

        [Required]
        public int Name { get; set; }

        private Category() { }
    }
}
