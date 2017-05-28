using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Entities;
using DataAccess.Data;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductTypesController 
    {
        private Repository _repository;
        private MusicShopDbContextFactory _factory;
        private DbContext _context;

        public ProductTypesController()
        {
            _factory = new MusicShopDbContextFactory();
            _context = _factory.Create(new DbContextFactoryOptions());
            _repository = new Repository(_context);
        }

        // GET api/producttypes
        [HttpGet]
        public string Get()
        {

            //_context.Database.ExecuteSqlCommand(
    //"UPDATE dbo.ProductTypes SET Name = 'IUH OHHH Name' WHERE Id = 1");

            //_repository.Save();

            var allProductTypes =  _repository.GetAll<ProductType>();
            return JsonConvert.SerializeObject( allProductTypes, Formatting.Indented );
        }

        // GET api/producttypes/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            ProductType productType = _repository.GetById<ProductType>(id);
            return JsonConvert.SerializeObject(productType, Formatting.Indented);
        }

        // POST api/producttypes
        [HttpPost]
        public string Post([FromBody] JObject productType)
        {

            JSchema schema = JSchema.Parse(getJsonSchema());


            ProductType prodType = productType.ToObject<ProductType>();

            //JObject productType = JObject.Parse(test);

            bool isPayloadValidProductType = productType.IsValid(schema);

            //ProductType results = JsonConvert.DeserializeObject<ProductType>(productType);
            return JsonConvert.SerializeObject(prodType, Formatting.Indented);
            //deserialize

            //validate payload

            /*
            _repository.Add<ProductType>(new ProductType("randomType"));
            _repository.Add<ProductType>(new ProductType("randomType2"));
            _repository.Add<ProductType>(new ProductType("randomType3"));
            _repository.Save();
            */
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



        private string getJsonSchema()
        {

            //CHANGE THIS TO BE AN EXTENSION METHOD OF ANYTHING THAT IMPLEMENTS IENTITY
            string jsonSchema = @"{
                                       'description': 'ProductType',
                                       'type': 'object',
                                       'properties':
                                       {
                                         'Name': {'type':'string'},
                                     
                                       },
                                       'required': ['Name']
                                     }";

            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate(typeof(ProductType));
            // {
            //   "type": "object",
            //   "properties": {
            //     "email": { "type": "string", "format": "email" }
            //   },
            //   "required": [ "email" ]
            // }
            return schema.ToString();
        }
    }
}

