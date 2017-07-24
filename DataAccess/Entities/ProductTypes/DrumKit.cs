using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities.ProductTypes
{
    public class DrumKit : Instrument
    {
        [Key]
        public int Id { get; set; }
        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }
        public int ProductId { get; set; }

        public int NumberOfDrums { get; set; }
        public int NumberOfKickers { get; set; }
        public int NumberOfCymbols { get; set; }

        private DrumKit() { }


    }
}
