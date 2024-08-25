using App.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 100 },
            new Product { Id = 2, Name = "Product 2", Price = 200 },
            new Product { Id = 3, Name = "Product 3", Price = 300 },
            new Product { Id = 4, Name = "Product 4", Price = 400 },
            new Product { Id = 5, Name = "Product 5", Price = 500 }
        };

        [HttpPost("add-product")]
        public IActionResult Post([FromBody] Product product) //FromBody : Gelen veriyi Product sınıfına dönüştürür.
        {
            products.Add(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id); //FirstOrDefault : İlk bulduğu elemanı döndürür.
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Forms([FromForm] Product product)
        {
            products.Add(product);
            return Ok();
        }


    }
}

