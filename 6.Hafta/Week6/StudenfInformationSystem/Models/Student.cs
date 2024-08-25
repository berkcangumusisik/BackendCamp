using System.ComponentModel.DataAnnotations;

namespace StudenfInformationSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Öğrenci adı boş olamaz.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Öğrenci soyadı boş olamaz.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Öğrenci numarası boş olamaz.")]
        public string StudentNumber { get; set; }

        public int Grade { get; set; }
    }
}
