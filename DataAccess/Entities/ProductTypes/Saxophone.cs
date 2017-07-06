using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities.ProductTypes
{
    public class Saxophone : Instrument
    {
        public double BellDiameter { get; set; }
        public double BodyLength { get; set; }
        public int NumberOfKeys { get; set; }

        private Saxophone() { }
    }
}
