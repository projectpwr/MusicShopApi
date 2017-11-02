using DataAccess;
using DataAccess.Entities;
using DataAccessInterfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace Api.Controllers
{
    /*
    [Route("api/v1/[controller]")]
    public class ProductController 
    {
        private IRepository _repository;
        private JSchema _schema;

        public ProductController(IRepository repository)
        {
            _repository = repository;
            _schema = JSchema.Parse(GetJsonSchema());
        }
        
        public ProductTypesController()
        {
            _factory = new MusicShopDbContextFactory();
            _context = _factory.Create(new DbContextFactoryOptions());
            _repository = new Repository(_context);
            _schema = JSchema.Parse(GetJsonSchema());
        }

        // GET api/product
        [HttpGet]
        public string Get()
        {
            var allProducts =  _repository.GetAll<Product>();
            return JsonConvert.SerializeObject( allProducts, Formatting.Indented );
        }

        private string GetJsonSchema()
        {
            JSchemaGenerator generator = new JSchemaGenerator();
            JSchema schema = generator.Generate( typeof( Product ) );
            return schema.ToString();
        }
    }
*/
}

