using EntityFramework.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int? TeacherId { get; set; }
    }
}
