using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Address
    {
        public int Id { get; set; }
        string FirstLine { get; set; }
        string SecondLine { get; set; }
        string ThirdLine { get; set; }
        string Town { get; set; }
        string County { get; set; }
        string Country { get; set; }
        string Postcode { get; set; }

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
