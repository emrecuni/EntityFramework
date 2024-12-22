using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Data
{
    public class Student
    {
        [Key] // primary key olduğunu belirtmek için (Id veya className+Id de olur)
        public int Id { get; set; }

        public string? StudentName { get; set; }
        public string? StudentSurname { get; set; }
        public string? EMail { get; set; }
        public string? Phone { get; set; }
    }
}
