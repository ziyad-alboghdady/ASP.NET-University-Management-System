using Microsoft.AspNetCore.Mvc;
using demoEFapp.Repositoy;

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
            return Ok(students);
        }
    }
}