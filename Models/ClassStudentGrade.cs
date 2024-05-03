using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiProgram.Models
{
    public class ClassStudentGrade
    {
        public int Id { get; set; }
        [Required]
        public int ClassStudentId { get; set; }
        [JsonIgnore]
        public ClassStudent? ClassStudent { get; set; }
        [Required]
        public double Grade { get; set; }
    }
}
