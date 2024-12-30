using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Data
{
    public class Teacher
    {
        [Key] // primary key olduğunu belirtmek için (Id veya className+Id de olur)
        [Column("Id")]
        public int TeacherId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? EMail { get; set; }
        public string? Phone { get; set; }
        public DateTime StartDate { get; set; }
        public ICollection<CourseRegister> Courses { get; set; } = new List<CourseRegister>();
    }
}
