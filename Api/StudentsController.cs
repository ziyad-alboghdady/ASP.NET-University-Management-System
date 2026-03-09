using demoEFapp.DTOs;
using demoEFapp.Repositoy;
using Microsoft.AspNetCore.Mvc;

namespace demoEFapp.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentRepository.GetAllStudents();

            var studentDtos = students.Select(s => new StudentReadDto
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName,
                IsActive = s.IsActive,
                StudentAge = s.StudentAge,
                PhotoName = s.PhotoName
            }).ToList();

            return Ok(studentDtos);
        }


        //the route ex/ will be like this GET /api/students/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentRepository.GetAllStudents()
                            .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                //404 Not Found
                return NotFound();
            }

            var studentDto = new StudentReadDto
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                IsActive = student.IsActive,
                StudentAge = student.StudentAge,
                PhotoName = student.PhotoName
            };

            //200 ok
            return Ok(studentDto);
        }
    }
}