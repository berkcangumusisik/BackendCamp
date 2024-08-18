using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week5.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // Aşağıdaki endpointleri içeren WebApi uygulamasını yazın

        // 1) https://www.siliconmadeacademy.com  adresine yönlendirme yapan bir endpoint oluşturun 
        // 2) 1. action'a yönlendirme yapan bir endpoint oluşturun 
        // 3) Bir product nesnesini 200 status kodu ile döndüren bir endpoint oluşturun 
        // 4) İsminizi italik olarak yazdıran bir endpoint oluşturun 

        [HttpGet("redirectToWebSite")]
        public IActionResult RedirectToWebSite()
        {
            return Redirect("https://www.siliconmadeacademy.com");
        }

        [HttpGet("redirectToRedirectToWebSite2")]
        public IActionResult RedirectToRedirectToWebSite2()
        {
            return RedirectToAction("RedirectToWebSite");
        }

        [HttpGet("product")]
        public IActionResult Product()
        {
            var product = new
            {
                name = "Product",
                price = 100
            };

            return Ok(product);
        }

        [HttpGet("nameItalic")]
        public IActionResult NameItalic()
        {
            return Content("<i>Berkcan Gümüşışık</i>", "text/html; charset=utf-8");
        }
    }
}
