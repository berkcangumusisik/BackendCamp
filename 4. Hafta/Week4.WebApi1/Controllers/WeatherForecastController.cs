using Microsoft.AspNetCore.Mvc;

namespace Week4.WebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}

/*
Attribute Kullanýmý
[ApiController] : Controller sýnýfýnýn bir controller olduðunu belirtir.
[Route] : Controller sýnýfýnýn route bilgisini belirtir.
[HttpGet] : Controller sýnýfýnýn get metodu olduðunu belirtir.
[HttpPost] : Controller sýnýfýnýn post metodu olduðunu belirtir.


Bir C# sýnýfýnýn Controller olabilmesi için :
 * ControllerBase sýnýfýndan türetilmelidir.
 * [ApiController] attribute'una sahip olmalýdýr.
 * Ýsminin sonunda Controller kelimesi bulunmalýdýr.
 */