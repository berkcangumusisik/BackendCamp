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
Attribute Kullan�m�
[ApiController] : Controller s�n�f�n�n bir controller oldu�unu belirtir.
[Route] : Controller s�n�f�n�n route bilgisini belirtir.
[HttpGet] : Controller s�n�f�n�n get metodu oldu�unu belirtir.
[HttpPost] : Controller s�n�f�n�n post metodu oldu�unu belirtir.


Bir C# s�n�f�n�n Controller olabilmesi i�in :
 * ControllerBase s�n�f�ndan t�retilmelidir.
 * [ApiController] attribute'una sahip olmal�d�r.
 * �sminin sonunda Controller kelimesi bulunmal�d�r.
 */