using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiProgram.Models
{
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [JsonIgnore]
        public Teacher? Teacher { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [JsonIgnore]
        public Subject? Subject { get; set; }
        [Required]
        public string ScheduleTime { get; set; } = null!;
        [Required]
        public string ScheduleDays { get; set; } = null!;
        public ICollection<ClassStudent> ClassStudents { get; } = new List<ClassStudent>();
    }
}
