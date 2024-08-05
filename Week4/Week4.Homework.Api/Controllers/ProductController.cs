using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week4.Homework.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, Category = "Electronics" },
            new Product { Id = 2, Name = "Smartphone", Price = 500, Category = "Electronics" }
        };

        [HttpGet]
        public IEnumerable<Product> GetList()
        {
            return _products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public void Create(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        [HttpPut("{id}")]
        public void Update(int id, Product product)
        {
            var existingProductIndex = _products.FindIndex(p => p.Id == id);
            if (existingProductIndex == -1)
            {
                return ;
            }
            _products[existingProductIndex].Name = product.Name;
            _products[existingProductIndex].Price = product.Price;
            _products[existingProductIndex].Category = product.Category;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return ;
            }
            _products.Remove(product);
        }
    }
}
