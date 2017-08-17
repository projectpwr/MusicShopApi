using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using DataAccessInterfaces.Entities;

namespace DataAccess.Entities
{
    public class ProductType : IEntity
    {   
        [Key]
        [JsonProperty(Required = Required.Default)]
        public int Id { get; private set; }

        [Timestamp]
        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonProperty(Required = Required.Always)]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }



        private ProductType() { }
        
        public ProductType(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name.ToString();
        }


    }
}
