using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessInterfaces.Repositories;
using DataAccess.Entities;
using DataAccess.Data;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductTypeController
    {

        private Repository _repository;
        private MusicShopDbContextFactory _factory;
        private DbContext _context;

        public ProductTypeController()
        {
            _factory = new MusicShopDbContextFactory();
            _context = _factory.Create(new DbContextFactoryOptions());
            _repository = new Repository(_context);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {

            _repository.Add<ProductType>( new ProductType("randomType") );
            _repository.Add<ProductType>(new ProductType("randomType2"));
            _repository.Add<ProductType>(new ProductType("randomType3"));
            _repository.Save();

            ProductType prodType1 = _repository.GetById<ProductType>(1);
           var id = prodType1.Id;
            prodType1.Name = "Fancy Pants Renamed";
            _repository.Update<ProductType>(prodType1);

            _context.Database.ExecuteSqlCommand(
    "UPDATE dbo.ProductTypes SET Name = 'IUH OHHH Name' WHERE Id = 1");

            _repository.Save();

            var allItems =  _repository.GetAll<ProductType>();
            var items = new List<string>();


            foreach(var pType in allItems)
            {
                items.Add(pType.Name);
            }

            return items;

            //get out all product types stored in the DB
            //var productType = new ProductType("product type A");
            //return new string[]{ productType.ToString() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var productType = new ProductType("product type A");
            return productType.Id.ToString();
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

