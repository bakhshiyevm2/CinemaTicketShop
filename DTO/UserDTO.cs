using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Min length is 5!")]
        public string Username { get; set; }
        public string? Salt { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? PasswordHash { get; set; }
        [Required]
        [MinLength(8,ErrorMessage = "Min length is 8!")]
        public string Password { get; set; }
    }
}
