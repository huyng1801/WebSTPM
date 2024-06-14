using System.ComponentModel.DataAnnotations;

namespace WebSTPM.Models
{
    public class AdminUser
    {
        public int AdminUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Role { get; set; } // true: Admin, false: Employee

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
