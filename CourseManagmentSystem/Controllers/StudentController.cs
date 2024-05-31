using InnovationTask.Interfaces;
using InnovationTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InnovationTask.Controllers
{

    // I just used an Example of Service layer to write the business logic so i didnt use it completely
    //and that was my reference https://stackoverflow.com/questions/31180816/mvc-design-pattern-service-layer-purpose
    public class StudentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentService _studentService;

        public StudentController(IUnitOfWork unitOfWork, IStudentService studentService)
        {
            _unitOfWork = unitOfWork;
            _studentService = studentService;
        }

        // GET: StudentController
        public ActionResult GetAllStudent()
        {
            var students = _unitOfWork.StudentRepository.GetAllStudentsWithCourses();
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var student = _unitOfWork.StudentRepository.GetStudentWithCourses(id);
            return View(student);
        }

        // GET: StudentController/Create
        public ActionResult AddStudent()
        {
            ViewBag.Subjects = _unitOfWork.CourseRepository.GetAll();
            ViewBag.DepartNames = _unitOfWork.DepartmentRepository.GetAll();
            return View();
        }

        // POST: StudentController/SaveCreate
        [HttpPost]

        // -------- this to prevent the external Calling 
        [ValidateAntiForgeryToken]
        public ActionResult SaveCreate(Student student, int[] selectedSubjects)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    ViewBag.Subjects = _unitOfWork.CourseRepository.GetAll();
                    return View("AddStudent", student);
                }

                if (ModelState.IsValid)
                {
                    _studentService.CreateStudent(student, selectedSubjects);
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong while doin");
                    ViewBag.Subjects = _unitOfWork.CourseRepository.GetAll();
                    return View("AddStudent", student);
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message.ToString());
            }
            ViewBag.Subjects = _unitOfWork.CourseRepository.GetAll();
            return RedirectToAction(nameof(GetAllStudent));
        }

        // GET: StudentController/EditStudent/5
        public ActionResult EditStudent(int id)
        {
            var student = _unitOfWork.StudentRepository.GetStudentWithCourses(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.Subjects = _unitOfWork.CourseRepository.GetAll();
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEdit(int id, Student NewStudent, int[] selectedSubjects)
        {
            if (id != NewStudent.Id)
            {
                return BadRequest();
            }

            var student = _unitOfWork.StudentRepository.StudentExists(id);
            if (!student)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Subjects = _unitOfWork.CourseRepository.GetAll();
                return View(NewStudent);
            }
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(NewStudent, selectedSubjects);
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong while saving changes");
                ViewBag.Subjects = _unitOfWork.CourseRepository.GetAll();
                return View(NewStudent);
            }

            return RedirectToAction(nameof(GetAllStudent));

        }
        // GET: StudentController/Delete/5
        public ActionResult DeleteStudent(int id)
        {

            if (!_unitOfWork.StudentRepository.StudentExists(id))
            { 
                return NotFound();
            }
            var student = _unitOfWork.StudentRepository.GetStudentWithCourses(id);
            if(student.StudentCourses == null || student == null)
            {
                return NotFound();
            }
            _unitOfWork.StudentCourseRepository.RemoveRange(student.StudentCourses);
            _unitOfWork.StudentRepository.Delete(student);
            _unitOfWork.Save();

            return RedirectToAction(nameof(GetAllStudent));
        }
        public ActionResult Back()
        {
            return RedirectToAction(nameof(GetAllStudent));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
