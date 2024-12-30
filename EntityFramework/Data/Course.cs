using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Data
{
    public class Course
    {
        [Key]
        [Column("Id")]
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public ICollection<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
    }
}
