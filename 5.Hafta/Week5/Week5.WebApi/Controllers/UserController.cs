using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week5.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("name")] // attribute routing
        public string UserName()
        {
            return "Berkcan Gümüşışık";
        }

        [HttpGet("nameBold1")]
        public string UserNameBold()
        {
            return "<b>Berkcan Gümüşışık</b>";
        }

        [HttpGet("nameBold2")]
        public IActionResult UserNameBold2()
        {
            // IActionResult bir interface'dir. IActionResult döndüğümüzde, dönüş tipi belirtilmez.
            return
                Content("<b>Berkcan Gümüşışık</b>",
                    "text/html; charset=utf-8"); // Content ile html dönüşü yapılabilir. content type belirtilmeli ve charset belirtilmeli.
        }

        [HttpGet("nameBold3")]
        public IActionResult UserNameBold3()
        {
            //Anonim Obje : Bir classtan türetilmeyen, ismi olmayan, sadece içerisinde propertyler bulunan objedir.
            var result = new
            {
                name = "Berkcan",
                surname = "Gümüşışık"
            };

            return Ok(result); // Ok metodu ile 200 dönüşü yapılır.
        }

        [HttpGet("nameBold4")]
        public IActionResult UserNameBold4()
        {
            return RedirectToAction("UserNameBold","User"); // Burada UserNameBold action'ına yönlendirme yapılır.
        }

        [HttpGet("redirect")]
        public IActionResult RedirectName()
        {
            return LocalRedirect("/api/Product/berkcan"); // LocalRedirect ile local bir yönlendirme yapılır.
            
        }

        [HttpGet("redirect2")]
        public IActionResult RedirectName2()
        {
            return RedirectToAction("Get", "Product");
        }

        [HttpGet("redirect3")]
        public IActionResult RedirectName3()
        {
            return Redirect("https://www.google.com.tr"); // Redirect ile farklı bir url'ye yönlendirme yapılır.
        }

        

    }
}
