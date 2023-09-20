using System.ComponentModel.DataAnnotations;

namespace WebApiJWT.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string cargo { get; set; }
        [Required]
        public string age { get; set; }
        [Required]
        public string url { get; set; }
    }
}
