using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace WebApiJWT.Dto
{
    public class UserDto
    {
        [Required]
        public string  userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
