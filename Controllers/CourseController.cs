using demoEFapp.Models;
using demoEFapp.Repositoy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace demoEFapp.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;

        public CourseController(ICourseRepository courseRepository, ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository; 
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            var teachers = _teacherRepository.GetAllTeachers();

            ViewBag.Teachers = teachers;

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create(Course course)
        {
            if (!ModelState.IsValid)
                return View(course);

            _courseRepository.CreateNewCourse(course);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                _courseRepository.DeleteCourse(id);
            }
            return RedirectToAction("Index");
        }
    }
}