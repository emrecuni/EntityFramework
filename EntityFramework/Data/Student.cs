using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFramework.Data
{
    public class Student
    {
        [Key] // primary key olduğunu belirtmek için (Id veya className+Id de olur)
        [Column("Id")]
        public int StudentId { get; set; }

        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public string  FullName { get 
            {
                return this.StudentName + " " + this.StudentSurname;
            }
        }
        public string? EMail { get; set; }
        public string? Phone { get; set; }
    }
}
