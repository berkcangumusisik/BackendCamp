using Microsoft.AspNetCore.Mvc;

namespace Week5.Homework.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private static List<Article> _articles = new List<Article>
        {
            new Article { Id = 1, Title = "ASP.NET Core ile Web API Geliþtirme", Content = "Bu makalede ASP.NET Core ile Web API geliþtirmenin temellerini öðreneceksiniz." },
            new Article { Id = 2, Title = "Postman Kullanýmý", Content = "Postman ile API testlerini nasýl yapabileceðinizi öðreneceksiniz." }
        };

        // GET: api/articles
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Article>> GetArticles()
        {
            return Ok(_articles);
        }

        // GET: api/articles/{id}
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Article> GetArticle(int id)
        {
            var article = _articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // POST: api/articles
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Article> PostArticle(Article article)
        {
            if (string.IsNullOrWhiteSpace(article.Title))
            {
                return BadRequest("Article title cannot be empty or null.");
            }

            article.Id = _articles.Count + 1;
            _articles.Add(article);

            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
        }

        // PUT: api/articles/{id}
        [HttpPut("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult PutArticle(int id, Article article)
        {
            if (string.IsNullOrWhiteSpace(article.Title))
            {
                return BadRequest("Article title cannot be empty or null.");
            }

            var existingArticle = _articles.FirstOrDefault(a => a.Id == id);
            if (existingArticle == null)
            {
                return NotFound();
            }

            existingArticle.Title = article.Title;
            existingArticle.Content = article.Content;

            return Ok(existingArticle);
        }

        // DELETE: api/articles/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteArticle(int id)
        {
            var article = _articles.FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return NoContent();
            }

            _articles.Remove(article);
            return Ok();
        }
    }

    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}