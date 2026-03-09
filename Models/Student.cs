using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoEFapp.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string StudentName { get; set; }

        public bool IsActive { get; set; }

        [Range(5, 18)]
        public int StudentAge { get; set; }

        public string? PhotoName { get; set; }

        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}