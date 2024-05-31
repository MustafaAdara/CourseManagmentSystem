using InnovationTask.Data;
using InnovationTask.Interfaces;
using InnovationTask.Models;

namespace InnovationTask.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DBContext context) : base(context)
        {
        }

    }
}
