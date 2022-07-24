using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AntBlazor.Shared.DTO
{
    public class LoginDto
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = String.Empty;
    }
}
