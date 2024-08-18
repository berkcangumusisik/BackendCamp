using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Week5.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JSONController : ControllerBase
    {
        [HttpGet("ok-json")]
        public IActionResult Get()
        {
            return Ok(new { Name = "Cemil", Age = 30, Address = "Siliconmade" });
        }

        [HttpGet("array-to-json")]
        public IActionResult NameList()
        {
            string[] names = new[] { "Ali", "Veli", "Ayşe" };

            return Ok(names);
        }


        [HttpGet("list-json")]
        public IActionResult ProductList()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product { Name = "Laptop", Price = 10000 });
            products.Add(new Product { Name = "Monitor", Price = 5000 });
            products.Add(new Product { Name = "Mouse", Price = 2000 });

            return Ok(products);
        }


        [HttpGet("list-json-content")]
        public IActionResult ProductList2()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product { Name = "Laptop", Price = 10000 });
            products.Add(new Product { Name = "Monitor", Price = 5000 });
            products.Add(new Product { Name = "Mouse", Price = 2000 });

            // Serialize : bir object'i json formatından string'e çevirme işlemi
            string jsonString = JsonSerializer.Serialize(products);

            // string olarak döndürme
            //return Content(jsonString, "text/plain;charset=utf-8");

            // string olan veriyi json olarak döndürme
            return Content(jsonString, "application/json;charset=utf-8");

        }


        [HttpGet("list-to-json-and-back")]
        public IActionResult ProductList3()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product { Name = "Laptop", Price = 10000 });
            products.Add(new Product { Name = "Monitor", Price = 5000 });
            products.Add(new Product { Name = "Mouse", Price = 2000 });

            // Serialize : bir object'i json formatından string'e çevirme işlemi
            string jsonString = JsonSerializer.Serialize(products);


            var listFromJson = JsonSerializer.Deserialize<List<Product>>(jsonString);

            return Ok(listFromJson);
        }

        [HttpGet("list-with-result")]
        public IResult GetPersonWithContentResult()
        {
            // ControllerBase class’ındaki “Content” metodu
            // ile JSON response oluşturmak:
            List<Product> products = new List<Product>();

            products.Add(new Product { Name = "Laptop", Price = 10000 });
            products.Add(new Product { Name = "Monitor", Price = 5000 });
            products.Add(new Product { Name = "Mouse", Price = 2000 });


            return Results.Json(products, statusCode: StatusCodes.Status200OK);
        }


        [HttpGet("list-with-result2")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IResult GetPersonWithContentResult2()
        {
            List<Product> products = new List<Product>();

            //products.Add(new Product { Name = "Laptop", Price = 10000 });
            //products.Add(new Product { Name = "Monitor", Price = 5000 });
            //products.Add(new Product { Name = "Mouse", Price = 2000 });

            if (products.Count == 0)
            {
                return Results.NotFound("liste boş");
            }

            if (products.Count != 3)
            {
                return Results.BadRequest("Liste 3 eleman içermeli");
            }

            return Results.Json(products, statusCode: StatusCodes.Status200OK);
        }
        // ÖRNEK SORU

        // Ürün fiyatının dolar olarak girildiği kabul edilerek; 
        // 1) Request body'den bir product gönderilecek ("application/json")
        // 2) Request'ten gelen bu product ilgili action içerisinde
        //    - fiyatı 0'dan küçükse "Fiyat 0'dan küçük olamaz" mesajı ile BadRequest olarak dönecek
        //    - değilse, fiyat dolar'dan tl'te çevrilerek güncellenecek ve Ok ile response olarak döndürülecek


        [HttpPost("product-price-as-try")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [Consumes(typeof(Product), "application/json")]
        public IActionResult ProductPriceTry(Product product)
        {
            if (product.Price < 0)
            {
                return BadRequest("Fiyat 0'dan küçük olamaz");
            }

            decimal usdTry = 33.5m;

            product.Price *= usdTry;

            return Ok(product);
        }







    }

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
