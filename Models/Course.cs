using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demoEFapp.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        [MinLength(3)]
        [MaxLength(10)]
        public string CourseName { get; set; }

        public int TeacherId {  get; set; }

        [Range(0, 25)]
        public int CourseCapacity { get; set; }

        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
