using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week5.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("berkcan")]
        public string ProductName()
        {
            return "Berkcan's Product";
        }
    }
}
