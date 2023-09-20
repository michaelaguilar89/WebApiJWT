using System.ComponentModel.DataAnnotations;

namespace WebApiJWT.Dto
{
    public class userParametersDto
    {
        
        public int id { get; set; }

       
        public string userName { get; set; }
       
        public string password { get; set; }

      
        public string role { get; set; }
        
        public string url { get; set; }

        public string Token { get; set; }

        public DateTime expirationDate { get; set; }
    }
}
