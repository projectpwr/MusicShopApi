using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DataAccess.Entities;
using DataAccess.Data;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
        private JSchema _schema;

        public ProductTypesController()
        {
            _factory = new MusicShopDbContextFactory();
            _context = _factory.Create(new DbContextFactoryOptions());
            _repository = new Repository(_context);
            _schema = JSchema.Parse(getJsonSchema());
        }

        // GET api/producttypes
        [HttpGet]
        public string Get()
        {
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
        public IActionResult Create([FromBody] JObject productTypeJObject)
        {
            try
            {
                bool isPayloadAValidProductType = productTypeJObject.IsValid(_schema);

                if (isPayloadAValidProductType)
                {
                    ProductType productType = productTypeJObject.ToObject<ProductType>();
                    _repository.Add<ProductType>(productType);
                    _repository.Save();
                    return new OkResult();
                }
                else
                {
                    return new BadRequestResult();
                }
            }
            catch
            {
                return new BadRequestResult();
            }

        }

        //PUT request says entire entity should be sent across and updated all at once.
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]JObject productTypeJObject)
        {
            if(productTypeJObject == null || (int)productTypeJObject.Property("Id") != id || !productTypeJObject.IsValid(_schema))
            {   
              return new BadRequestObjectResult(_schema);
            }

            ProductType productType = productTypeJObject.ToObject<ProductType>();
            ProductType productTypeFromDB = _repository.GetById<ProductType>(productType.Id);

            if(productTypeFromDB != null)
            {
                productTypeFromDB.Name = productType.Name;
                productTypeFromDB.RowVersion = productType.RowVersion;
                _repository.Update<ProductType>(productTypeFromDB);
                _repository.Save();
                return new OkObjectResult(productTypeFromDB);
            }
            else
            {
                return new NotFoundObjectResult(productType);
            }
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




        //_context.Database.ExecuteSqlCommand(
        //"UPDATE dbo.ProductTypes SET Name = 'IUH OHHH Name' WHERE Id = 1");

        //_repository.Save();

    }
}

