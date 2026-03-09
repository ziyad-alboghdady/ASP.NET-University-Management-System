using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoEFapp.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(60)]
        [MinLength(10)]
        public string TeacherName { get; set; }
        [Range(22, 70)]
        public int TeacherAge {  get; set; }
    }
}
