using Microsoft.AspNetCore.Mvc;

namespace demoEFapp.DTOs
{
    public class StudentReadDto : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
