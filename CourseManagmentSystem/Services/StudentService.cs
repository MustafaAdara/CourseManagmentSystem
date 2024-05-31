using InnovationTask.Interfaces;
using InnovationTask.Models;

namespace InnovationTask.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateStudent(Student student, int[] selectedCourses)
        {
            _unitOfWork.StudentRepository.Add(student);
            _unitOfWork.Save();

            if (selectedCourses != null && selectedCourses.Any())
            {
                foreach (var courseId in selectedCourses)
                {
                    var studentCourse = new StudentCourse
                    {
                        StudentId = student.Id,
                        CourseId = courseId
                    };
                    _unitOfWork.StudentCourseRepository.Add(studentCourse);
                }
                _unitOfWork.Save();
            }
        }

        public void DeleteStudent(int id)
        {
            var student = _unitOfWork.StudentRepository.GetStudentWithCourses(id);
            var studentCourses = student.StudentCourses;
            _unitOfWork.StudentCourseRepository.RemoveRange(studentCourses);

            // Delete the student
            _unitOfWork.StudentRepository.Delete(student);

            // Save changes
            _unitOfWork.Save();

        }

        public Student GetStudentWithCourses(int id)
        {
            return _unitOfWork.StudentRepository.GetStudentWithCourses(id);
        }

        public void UpdateStudent(Student student, int[] selectedCourses)
        {
            var existingStudent = _unitOfWork.StudentRepository.GetStudentWithCourses(student.Id);

            if (existingStudent == null)
            {
                throw new Exception("Student not found");
            }
            existingStudent.Name = student.Name;
            existingStudent.BirthDate = student.BirthDate;
            existingStudent.Address = student.Address;

            existingStudent.StudentCourses.Clear();

            _unitOfWork.Save();
            if (selectedCourses != null && selectedCourses.Any())
                {
                    foreach (var courseId in selectedCourses)
                    {
                        var studentCourse = new StudentCourse
                        {
                            StudentId = student.Id,
                            CourseId = courseId
                        };
                        existingStudent.StudentCourses.Add(studentCourse);
                    }
                    _unitOfWork.Save();
                }
         
            
        }
    }
}
