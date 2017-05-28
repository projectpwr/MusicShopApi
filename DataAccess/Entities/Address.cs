using System;
using System.Collections.Generic;
using System.Text;
using DataAccessInterfaces.Entities;

namespace DataAccess.Entities
{
    public class Address 
    {
        public int Id { get; private set; }
        public byte[] RowVersion { get; private set; }
        public string FirstLine { get; private set; }
        public string SecondLine { get; private set; }
        public string ThirdLine { get; private set; }
        public string Town { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }
        public string Postcode { get; private set; }

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
