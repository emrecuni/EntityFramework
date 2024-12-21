using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Data
{
    public class CourseRegister
    {
        [Key]
        public int Id { get; set; }
        public int StundentId { get; set; }
        public int CourseId { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
