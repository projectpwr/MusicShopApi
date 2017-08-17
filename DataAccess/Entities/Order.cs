using DataAccess.Static;
using DataAccessInterfaces.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{
    public class Order : IEntity
    {
        [Key]
        [JsonProperty(Required = Required.Default)]
        public int Id { get; set; }

        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public OrderStatus Status { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public double OrderTotal { get; set; }

        private Order() { }

    }
}
