using System.ComponentModel.DataAnnotations;

namespace ApiProgram.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        public ICollection<Class> Classes { get; } = new List<Class>();
    }
}
