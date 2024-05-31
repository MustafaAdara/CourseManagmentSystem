using InnovationTask.Models;

namespace InnovationTask.Interfaces
{
    public interface IStudentCourseRepository : IRepository<StudentCourse>
    {
        bool CourseExists(int id);
        void RemoveRange(List<StudentCourse> studentCourses);
    }
}
