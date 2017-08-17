using DataAccessInterfaces.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities.ProductTypes
{
    public class Saxophone : Instrument, IEntity
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }
        public int ProductId { get; set; }

        public double BellDiameter { get; set; }
        public double BodyLength { get; set; }
        public int NumberOfKeys { get; set; }

        private Saxophone() { }
    }
}
