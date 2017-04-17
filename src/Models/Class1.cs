using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Class1
    {
        public Class1()
        { }

        public IEnumerable<string> something()
        {
            return new List<string>{ "Oh hi there" };
        }
        
    }
}
