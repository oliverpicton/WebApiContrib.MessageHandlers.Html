using System.Collections.Generic;
using System.Web.Mvc;
using SampleApi.Models;

namespace SampleApi.Controllers.Html
{
    public class ProductController : Controller
    {
        // GET /api/product/html
        public ActionResult Index()
        {
            var model = new List<Product> 
            { 
                new Product { Id=1, Name="Apples", Price = 29.5m },
                new Product { Id=2, Name="Pears", Price = 30m }
            };

            return View(model);
        }

        // GET /api/product/1
        public ActionResult Get(int id)
        {
            var model = new Product { Id = 1, Name = "Apples", Price = 29.5m };

            return View(model);
        }        
    }
}