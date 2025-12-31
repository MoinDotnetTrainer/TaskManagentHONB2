using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace TaskManagentHONB2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public List<UsersTask>? Tasks { get; set; }
    }
}
