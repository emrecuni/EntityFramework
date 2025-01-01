using EntityFramework.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        [StringLength(50)]
        public string? Title { get; set; }
        public int TeacherId { get; set; }
        public ICollection<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
    }
}
