using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoEFapp.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get;set; }
        [MinLength(3)]
        [MaxLength(10)]
        public string RoomName { get; set; }

    }
}
