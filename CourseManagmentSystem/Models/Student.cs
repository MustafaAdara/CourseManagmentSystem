using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnovationTask.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="Enter Your Full Name"),]
        public string? Name { get; set; }

        [Display(Name ="Day Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        [MinLength(3, ErrorMessage ="Enter a valid Address")]
        public string? Address { get; set; }
        public string? Email {  get; set; }
        public string? Image { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }

        // virtual to refrence on it's object and not creating new one on intializing an student object 
        public virtual Department? Department { get; set; }
        public virtual List<StudentCourse>? StudentCourses { get; set; }
    }
}
