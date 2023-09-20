using System.ComponentModel.DataAnnotations;

namespace WebApiJWT.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public string url { get; set; }
    }
}
