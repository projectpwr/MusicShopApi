using DataAccessInterfaces.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class OrderItem : IEntity
    {
        [Key]
        [JsonProperty(Required = Required.Default)]
        public int Id { get; set; }

        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public double ItemPrice { get; set; }
        public double ItemVatRate { get; set; }
        public int ItemQuantity { get; set; }
        public double OrderItemGross { get; set; }

        private OrderItem() { }
    }
}
