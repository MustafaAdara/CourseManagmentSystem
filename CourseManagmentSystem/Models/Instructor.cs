namespace InnovationTask.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public Decimal? Salary { get; set; }
        public string Image { get; set; }
        public int CourseId { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public Course Course { get; set; }
    }
}
