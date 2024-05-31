using InnovationTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InnovationTask.Data
{
    public class DBContext : DbContext
    {
        public DBContext() : base() { }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(k => new { k.StudentId, k.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(s => s.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(s => s.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(s => s.CourseId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
