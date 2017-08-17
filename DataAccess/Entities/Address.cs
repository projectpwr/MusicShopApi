using System;
using System.Collections.Generic;
using System.Text;
using DataAccessInterfaces.Entities;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace DataAccess.Entities
{
    public class Address : IEntity
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty(Required = Required.Default)]
        public byte[] RowVersion { get; set; }
        [Required]
        public string FirstLine { get; private set; }
        public string SecondLine { get; private set; }
        public string ThirdLine { get; private set; }
        [Required]
        public string Town { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }
        [Required]
        public string Postcode { get; private set; }

        private Address() { }

        public Address(string firstline, string secondline, string thirdline, string town, 
            string county, string country, string postcode)
        {
            FirstLine = firstline;
            SecondLine = secondline;
            ThirdLine = thirdline;
            Town = town;
            County = county;
            Country = country;
            Postcode = postcode;
        }

        public override string ToString()
        {
            return FirstLine + "," + SecondLine + "," + ThirdLine + "," + Town + "," + County + "," + Country + "," + Postcode;
        }
    }
}
