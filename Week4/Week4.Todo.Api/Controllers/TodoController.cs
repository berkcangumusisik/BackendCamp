using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week4.Todo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        static private readonly List<TodoItem> _todoItems = new()
        {
            new TodoItem { Id = 1, Description = "Todo 1" },
            new TodoItem { Id = 2, Description = "Todo 2" },
            new TodoItem { Id = 3, Description = "Todo 3" }
        };

        [HttpGet]
        public IEnumerable<TodoItem> GetList() //bütün todoları getir
        {
            return _todoItems;
        }

        [HttpGet("{id}")]
        public TodoItem? GetItem(int id) //id'ye göre getirir
        {
            return _todoItems.Find(x => x.Id == id);
            // .Find() metodu, bir koleksiyon içindeki belirli bir öğeyi bulmak için kullanılır.

        }

        [HttpPost]
        public void AddItem(string description)
        {
            var item = new TodoItem
            {
                Id = _todoItems.Count + 1,
                Description = description
            };

            _todoItems.Add(item); 
        }

        [HttpPut("{id}")]
        public void UpdateItem(int id, string description)
        {
            var item = _todoItems.FindIndex(x => x.Id == id); //FindIndex metodu, belirli bir koşulu sağlayan ilk öğenin dizinini döndürür.
            if (item == -1)
            {
                return;
            }
            _todoItems[item].Description = description;
            
        }

        [HttpDelete("{id}")]
        public void DeleteItem(int id)
        {
            var item = _todoItems.FindIndex(x => x.Id == id);
            if (item == -1)
            {
                return;
            }
            _todoItems.RemoveAt(item);
        }
    }
}
