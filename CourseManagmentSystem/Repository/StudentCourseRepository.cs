using InnovationTask.Data;
using InnovationTask.Interfaces;
using InnovationTask.Models;

namespace InnovationTask.Repository
{
    public class StudentCourseRepository : Repository<StudentCourse>, IStudentCourseRepository
    {
        public StudentCourseRepository(DBContext context) : base(context)
        {
        }

        public bool CourseExists(int id)
        {
            return _context.StudentCourses.Any(x => x.CourseId == id);
        }

        public void RemoveRange(List<StudentCourse> studentCourses)
        {
            _context.RemoveRange(studentCourses);
        }
    }
}
