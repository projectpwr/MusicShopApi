using DataAccess.Static;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities.ProductTypes
{
    public class Guitar : Instrument
    {
        public int NumberOfStrings { get; set; }
        public int NumberOfPickups { get; set; }
        public double NeckLength { get; set; }
        public GuitarType GuitarType{ get; set; }
        public Orientation Orientation { get; set; }

        private Guitar() { }
    }


}
