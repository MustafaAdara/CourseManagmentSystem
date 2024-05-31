using CourseManagmentSystem.Interfaces;

namespace InnovationTask.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IStudentCourseRepository StudentCourseRepository { get; }
        void Save();
    }
}
