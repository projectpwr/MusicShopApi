using DataAccess.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities.ProductTypes
{
    public class Guitar : Instrument
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }
        public int ProductId { get; set; }

        public int NumberOfStrings { get; set; }
        public int NumberOfPickups { get; set; }
        public double NeckLength { get; set; }
        public GuitarType GuitarType{ get; set; }
        public Orientation Orientation { get; set; }

        private Guitar() { }
    }


}
