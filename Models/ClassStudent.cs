using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiProgram.Models
{
    public class ClassStudent
    {
        public int Id { get; set; }
        [Required]
        public int ClassId { get; set; }
        [JsonIgnore]
        public Class?Class { get; set; }
        [Required]
        public int StudentId { get; set; }
        [JsonIgnore]
        public Student? Student { get; set; }
        public ICollection<ClassStudentGrade> ClassStudentGrades { get; } = new List<ClassStudentGrade>();
    }
}
