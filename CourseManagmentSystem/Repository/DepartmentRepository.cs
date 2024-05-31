using CourseManagmentSystem.Interfaces;
using InnovationTask.Data;
using InnovationTask.Models;
using InnovationTask.Repository;

namespace CourseManagmentSystem.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DBContext context) : base(context)
        {
        }
    }
}
