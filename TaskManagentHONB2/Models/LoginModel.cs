using System.ComponentModel.DataAnnotations;

namespace TaskManagentHONB2.Models
{
    public class LoginModel
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
