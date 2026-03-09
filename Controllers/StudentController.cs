using demoEFapp.Models;
using demoEFapp.Repositoy;
using demoEFapp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace demoEFapp.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IWebHostEnvironment _Environment;
        public StudentController(IStudentRepository studentRepository, ICourseRepository courseRepository, IWebHostEnvironment environment)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _Environment = environment;
        }
        private string UploadPhoto(IFormFile photo)
        {
            string uploadsFolder = Path.Combine(_Environment.WebRootPath, "StudentPictures");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            string fullPath = Path.Combine(uploadsFolder, fileName);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return fileName;
        }

        [HttpGet]
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 5;
            if (pageSize > 50) pageSize = 50;

            var students = _studentRepository.GetAllStudents(); // List<Student>

            var totalCount = students.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            if (totalPages > 0 && pageNumber > totalPages)
                pageNumber = totalPages;

            var pageItems = students
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var vm = new StudentIndexVM
            {
                Students = pageItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages
            };

            return View(vm);
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create(Student st, IFormFile? StudentPhoto)
        {
            if(!ModelState.IsValid) 
            {
                return View(st);
            }
            if (StudentPhoto != null && StudentPhoto.Length > 0)
            {
                st.PhotoName = UploadPhoto(StudentPhoto);
            }
            _studentRepository.CreateNewStudent(st);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int StudentId)
        {
            _studentRepository.DeleteStudent(StudentId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Register()
        {
            StudentCourseVM data = new StudentCourseVM();
            data.Courses = _courseRepository.GetAllCourses();
            data.Students = _studentRepository.GetAllStudents();
            return View(data);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Register(int StudentId, int CourseId)
        {
            _studentRepository.Register(StudentId, CourseId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(int id)
        {
            Student student = _studentRepository.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Edit(Student st, IFormFile? StudentPhoto)
        {
            if (!ModelState.IsValid)
            {
                return View(st);
            }

            Student oldStudent = _studentRepository.GetStudentById(st.StudentId);

            if (oldStudent == null)
            {
                return NotFound();
            }

            oldStudent.StudentName = st.StudentName;
            oldStudent.StudentAge = st.StudentAge;
            oldStudent.IsActive = st.IsActive;

            if (StudentPhoto != null && StudentPhoto.Length > 0)
            {
                oldStudent.PhotoName = UploadPhoto(StudentPhoto);
            }

            _studentRepository.UpdateStudent(oldStudent);
            return RedirectToAction("Index");
        }

    }
}