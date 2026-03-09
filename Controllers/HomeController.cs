using System.Diagnostics;
using demoEFapp.Models;
using demoEFapp.Repositoy;
using Microsoft.AspNetCore.Mvc;

namespace demoEFapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IRoomRepository _roomRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository,
            ICourseRepository courseRepository,
            IRoomRepository roomRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
            _roomRepository = roomRepository;
        }

        public IActionResult Index()
        {
            ViewBag.StudentsCount = _studentRepository.GetAllStudents().Count;
            ViewBag.TeachersCount = _teacherRepository.GetAllTeachers().Count;
            ViewBag.CoursesCount = _courseRepository.GetAllCourses().Count;
            ViewBag.RoomsCount = _roomRepository.GetAllRooms().Count;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}