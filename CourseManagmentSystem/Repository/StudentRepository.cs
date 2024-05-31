using InnovationTask.Data;
using InnovationTask.Interfaces;
using InnovationTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InnovationTask.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DBContext context) : base(context)
        {

        }

        public IEnumerable<Student> GetAllStudentsWithCourses()
        {
            return _context.Students.Include(x => x.StudentCourses).ThenInclude(x => x.Course).ToList();
        }

        public Student GetStudentWithCourses(int id)
        {
            return _context.Students.Include(x => x.StudentCourses).ThenInclude(x => x.Course).FirstOrDefault(x => x.Id == id);
        }

        public bool StudentExists(int id)
        {
            return _context.Students.Any(x => x.Id == id);
        }
    }
}
