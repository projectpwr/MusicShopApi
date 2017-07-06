using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities.ProductTypes
{
    public class DrumKit : Instrument
    {
        public int NumberOfDrums { get; set; }
        public int NumberOfKickers { get; set; }
        public int NumberOfCymbols { get; set; }
    }
}
