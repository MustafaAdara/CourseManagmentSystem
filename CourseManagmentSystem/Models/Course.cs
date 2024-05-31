using System.ComponentModel.DataAnnotations;

namespace InnovationTask.Models
{
    public class Course
    {
        public int Id {set; get;}
        public string Name { set; get;}
        public int Degree { get; set; }
        public int MinDegree { get; set; }

        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }

        public virtual List<StudentCourse>? StudentCourses { get; set; }

    }
}
