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
        public string? FullName { get 
            {
                return this.Name + " " + this.Surname;
            }
        }
        public string? EMail { get; set; }
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = false)]
        public DateTime StartDate { get; set; }
        public ICollection<CourseRegister> CourseRegisters { get; set; } = new List<CourseRegister>();
    }
}
