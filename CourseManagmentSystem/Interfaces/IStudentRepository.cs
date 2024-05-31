using InnovationTask.Models;

namespace InnovationTask.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Student> GetAllStudentsWithCourses();
        Student GetStudentWithCourses(int id);
        bool StudentExists(int id);
    }
}
