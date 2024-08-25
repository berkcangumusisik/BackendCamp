using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudenfInformationSystem.Models;

namespace StudenfInformationSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return Ok(_students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> Post(Student student)
        {
            if (_students.Any(s => s.StudentNumber == student.StudentNumber))
            {
                return BadRequest("Öğrenci numarası benzersiz olmalıdır.");
            }

            student.Id = _students.Count + 1;
            _students.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            if (_students.Any(s => s.StudentNumber == student.StudentNumber && s.Id != id))
            {
                return BadRequest("Öğrenci numarası benzersiz olmalıdır.");
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.StudentNumber = student.StudentNumber;
            existingStudent.Grade = student.Grade;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            _students.Remove(student);
            return NoContent();
        }
    }
}
