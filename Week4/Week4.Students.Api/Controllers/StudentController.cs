using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Week4.Students.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static readonly List<Students> _students = new List<Students>
        {
            new Students { Id = 1, FirstName = "John", LastName = "Doe" },
            new Students { Id = 2, FirstName = "Jane", LastName = "Doe" }
        };

        [HttpGet]
        public IEnumerable<Students> GetList()
        {
            return _students;
        }

        [HttpGet("{id}")]
        public ActionResult<Students> GetById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpPost]
        public void Create(Students student)
        {
            student.Id = _students.Count + 1;
            _students.Add(student);
        }

        [HttpPut("{id}")]
        public void Update(int id, Students student)
        {
            var existingStudent = _students.FindIndex(s => s.Id == id);
            if (existingStudent == -1)
            {
                return ;
            }
            _students[existingStudent].FirstName = student.FirstName;
            _students[existingStudent].LastName = student.LastName;

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return;
            }
            _students.Remove(student);
        }

    }
}
