using DataAccessInterfaces.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class PaymentType : IEntity
    {

        [JsonProperty(Required = Required.Default)]
        public int Id { get; private set; }

        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }

        public string Name { get; set; }


    }
}