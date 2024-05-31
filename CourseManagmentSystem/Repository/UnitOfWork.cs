using CourseManagmentSystem.Interfaces;
using CourseManagmentSystem.Repository;
using InnovationTask.Data;
using InnovationTask.Interfaces;
using InnovationTask.Models;

namespace InnovationTask.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private IStudentRepository? _studentRepo;
        private ICourseRepository? _courseRepo;
        private IDepartmentRepository? _departmentRepo;
        private IStudentCourseRepository? _studentCourseRepo;
        public UnitOfWork(DBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IStudentRepository StudentRepository => _studentRepo ??= new StudentRepository(_context);
        public ICourseRepository CourseRepository => _courseRepo ??= new CourseRepository(_context);
        public IDepartmentRepository DepartmentRepository => _departmentRepo ??= new DepartmentRepository(_context);
        public IStudentCourseRepository StudentCourseRepository => _studentCourseRepo ??= new StudentCourseRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
