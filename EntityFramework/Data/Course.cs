using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }       
    }
}
