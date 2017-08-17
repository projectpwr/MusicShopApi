using DataAccessInterfaces.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class UserPayment : IEntity
    {
        [Key]
        [JsonProperty(Required = Required.Default)]
        public int Id { get; private set; }

        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }

        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        //to map to relevant table for this payment type eg credit car perhaps...might opt for diff strategy when come to implementation stage
        public int PaymentDetailsId { get; set; }

        private UserPayment() { }
    }
}
