using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiJWT.Context;
using WebApiJWT.Models;

namespace WebApiJWT.Repository
{
    public class RepositoryAuthentication : InterfaceAuthentication
    {
        private readonly ApplicationDbContext context;

        public RepositoryAuthentication(ApplicationDbContext context)
        {
            this.context = context;
        }

        public string generateToken(DateTime expirationDate ,User user)
        {
            var fechaExpiracion = DateTime.UtcNow.AddHours(3);
            //Configuramos las claims
            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.NameId,user.id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub,user.userName),
            new Claim("Role",user.role),            
            new Claim("ExpirationClaim",expirationDate.ToString())
           
            };

            //Añadimos las credenciales
            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("G3VF4C6KFV43JH6GKCDFGJH45V36JHGV3H4C6F3GJC63HG45GH6V345GHHJ4623FJL3HCVMO1P23PZ07W8")),
                    SecurityAlgorithms.HmacSha256Signature
            );//luego se debe configurar para obtener estos valores, así como el issuer y audience desde el appsetings.json

            //Configuracion del jwt token
            var jwt = new JwtSecurityToken(
                issuer: "Peticionario",
                audience: "Public",
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: fechaExpiracion,
                signingCredentials: signingCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }

        public bool validateUser(User user)
        {
            try
            {
                User data = new();
                data = context.users.FirstOrDefault(
                        x => x.userName.ToLower() == user.userName.ToLower() || x.password == user.password
                    );


                if (data != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
