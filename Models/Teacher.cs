using System.ComponentModel.DataAnnotations;

namespace ApiProgram.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; } = null!;
        [Required]
        public string Lastname { get; set; } = null!;
        [Required]
        public string Gender { get; set; } = null!;
        [Required]
        public string Specialty { get; set; } = null!;
        public ICollection<Class> Classes { get; } = new List<Class>();
    }
}
