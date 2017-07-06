using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            /*
            var testManu = new Manufacturer("this is a custom manufactureres name");
            var testManu2 = new Manufacturer("this is a SECOND manufactureres name");
            var product = new SomeProduct(testManu);
            var product2 = new SomeProduct(testManu2);
            var name = product.GetManufacturersName();
            var name2 = product2.GetManufacturersName();
            return new string[] { name, "value2", name2 };*/
            return new string[] { "hi" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
