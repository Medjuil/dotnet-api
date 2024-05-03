
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiProgram.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; } = null!;
        [Required]
        public string Lastname { get; set; } = null!;
        [Required]
        public string Gender { get; set; } = null!;
        public ICollection<ClassStudent> ClassStudents { get; } = new List<ClassStudent>();

    }
}
