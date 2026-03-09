using System.ComponentModel.DataAnnotations;

namespace demoEFapp.ViewModels
{
    public class CreateRoleVM
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; } = string.Empty;
    }
}