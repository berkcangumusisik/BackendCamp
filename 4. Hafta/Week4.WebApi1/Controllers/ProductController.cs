using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week4.WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("/asus")]
        public string Asus()
        {
            return "Asus Laptop";
        }

        [HttpGet("/dell")]
        public string Dell()
        {
            return "Dell Laptop";
        }

        [HttpGet("{brand}")]
        public string GetProduct(string brand)
        {
            return $"{brand} Notebook"; // String interpolation kullanımı
        }
    }
}
