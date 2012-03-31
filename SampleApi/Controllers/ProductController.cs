using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using SampleApi.Models;

namespace SampleApi.Controllers
{
    public class ProductController : ApiController
    {
        // GET /api/product
        public IEnumerable<Product> Get()
        {
            return new List<Product> 
            { 
                new Product { Id=1, Name="Apples", Price = 29.5m },
                new Product { Id=2, Name="Pears", Price = 30m }
            };
        }

        // GET /api/product/1
        public Product Get(int id)
        {
            return new Product { Id = 1, Name = "Apples", Price = 29.5m };
        }

        // POST /api/values
        public void Post(string value)
        {
        }

        // PUT /api/values/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/values/5
        public void Delete(int id)
        {
        }
    }
}