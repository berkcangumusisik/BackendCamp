using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampeController : ControllerBase
    {
        [HttpGet("get/{number1}")]
        public IActionResult Get(int number1, [FromQuery] int number2, [FromHeader] int number3)
        {
            return Ok((number1 - number2) * number3);
        }
    }
}

/*
 * Bir Action içerisinde 3 parametre(sayı) alınacak
 * 1 Parametre Route'dan gelecek
 * 1 parametre Query'den gelecek
 * 1 parametre Header'den gelecek
 *
 *(Route'dan alınan değer - Query'den alınan değer )* Header'den alınan değer
 * Sonuç Ok olarak dönecek
 *
 */