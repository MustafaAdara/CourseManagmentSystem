using InnovationTask.Models;

namespace InnovationTask.Interfaces
{
    public interface IStudentService
    {
        void CreateStudent(Student student, int[] selectedSubjects);
        void UpdateStudent(Student student, int[] selectedSubjects);
        public Student GetStudentWithCourses(int id);
        public void DeleteStudent(int id);
    }
}
