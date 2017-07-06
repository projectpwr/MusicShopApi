using DataAccess.Static;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities.ProductTypes
{
    public class Instrument : Product
    {
        public Size Size { get; set; }
        public ExperienceLevel ExperienceLevel { get; set; }
    }


}
