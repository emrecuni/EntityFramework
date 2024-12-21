using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Course> Courses => Set<Course>(); // nullable uyarısı için
        public DbSet<Student> Students => Set<Student>();
        public DbSet<CourseRegister> CourseRegisters => Set<CourseRegister>();
    }

    //database-first => veri tabanını ssms gibi bir ortamda manuel oluşturma
    //code-first => entity, dbcontext sınıflarını oluşturduktan sonra bir database oluşturulur
}