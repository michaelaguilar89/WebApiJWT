using System.ComponentModel.DataAnnotations;

namespace WebApiJWT.Models
{
    public class Clients
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string role { get; set; }
        [Required]
        public string url { get; set; }
    }
}
