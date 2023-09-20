using System.ComponentModel.DataAnnotations;

namespace WebApiJWT.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }

        [Required]
        public string role { get; set; }
        [Required]
        public string url { get; set; }




    }
}
