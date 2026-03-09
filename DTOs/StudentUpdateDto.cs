using System.ComponentModel.DataAnnotations;

namespace demoEFapp.DTOs
{
    public class StudentUpdateDto
    {
        [Required]
        public string StudentName { get; set; } = string.Empty;

        [Range(18, 100)]
        public int StudentAge { get; set; }

        public bool IsActive { get; set; }

        public string? PhotoName { get; set; }
    }
}