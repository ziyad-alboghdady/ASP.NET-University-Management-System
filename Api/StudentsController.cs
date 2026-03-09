using demoEFapp.DTOs;
using demoEFapp.Models;
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
        public IActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 1)
                pageSize = 5;

            var students = _studentRepository.GetAllStudents();

            var totalCount = students.Count();

            var pagedStudents = students
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(s => new StudentReadDto
                {
                    StudentId = s.StudentId,
                    StudentName = s.StudentName,
                    IsActive = s.IsActive,
                    StudentAge = s.StudentAge,
                    PhotoName = s.PhotoName
                })
                .ToList();

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return Ok(new
            {
                pageNumber = pageNumber,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPages = totalPages,
                data = pagedStudents
            });
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

        [HttpPost]
        public IActionResult Create(StudentCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = new Student
            {
                StudentName = dto.StudentName,
                StudentAge = dto.StudentAge,
                IsActive = dto.IsActive,
                PhotoName = dto.PhotoName
            };

            _studentRepository.CreateNewStudent(student);

            var studentReadDto = new StudentReadDto
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                StudentAge = student.StudentAge,
                IsActive = student.IsActive,
                PhotoName = student.PhotoName
            };

            return CreatedAtAction(nameof(GetById), new { id = student.StudentId }, studentReadDto);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, StudentUpdateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _studentRepository.GetAllStudents()
                            .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            student.StudentName = dto.StudentName;
            student.StudentAge = dto.StudentAge;
            student.IsActive = dto.IsActive;
            student.PhotoName = dto.PhotoName;

            _studentRepository.UpdateStudent(student);

            //204 is returned from no content
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentRepository.DeleteStudent(id);
            return NoContent();
        }
    }
}