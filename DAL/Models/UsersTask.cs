using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UsersTask
    {
        [Key]
        public int TaskId { get; set; }
        public string? Title { get; set; }  // UI
        public string? Description { get; set; }  // Design Login Page
        public DateTime? DueDate { get; set; }  // tomorrow
        public string? Status { get; set; }  // assigned
        public int AssignedUserId { get; set; }  // fk to User 1 or 2 or 3 or 4
        public User? AssignedUser { get; set; }

    }
}
