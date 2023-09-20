using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApiJWT.Context;
using WebApiJWT.Dto;
using WebApiJWT.Models;
using WebApiJWT.Repository;

namespace WebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RepositoryAuthentication authentication;
        protected responseDto response;
        public UsersController(ApplicationDbContext context, RepositoryAuthentication authentication)
        {
            _context = context;
            this.authentication = authentication;
            response = new responseDto();
        }
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> login(UserDto user)
        {
            try
            {
                var myUser = await _context.users.FirstOrDefaultAsync(
                               x=>x.userName.ToLower()==user.userName.ToLower() && x.password==user.password
                    );
                if (myUser!=null)
                {
                    response.DisplayMessages = "User Data";
                    var expirationDate = DateTime.UtcNow.AddHours(3);
                    var token = authentication.generateToken(expirationDate, myUser);
                    userParametersDto userParameters = new();
                    userParameters.userName = myUser.userName;
                    userParameters.role = myUser.role;
                    userParameters.Token = token;
                    userParameters.expirationDate = expirationDate;
                    response.Result = userParameters;
                    return Ok(response);
                    
                }
                response.DisplayMessages = "User not found";
                return BadRequest(response);
            }
            catch (Exception e)
            {
                response.DisplayMessages = "Error";
                response.errorMessages = new List<string> { e.Message};
                return BadRequest(response);

                
            }

        }
        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                var myresponse =  authentication.validateUser(user);
                if (myresponse==true)
                {
                    response.DisplayMessages = "Error,invalid username or password or in use";
                 
                    return BadRequest(response);

                }
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
                response.DisplayMessages = "User Register!!";
                var expirationDate = DateTime.UtcNow.AddHours(3);
                var token = authentication.generateToken(expirationDate, user);
                userParametersDto userParameters = new();
                userParameters.userName = user.userName;
                userParameters.role = user.role;
                userParameters.Token = token;
                userParameters.expirationDate = expirationDate;
                response.Result = userParameters;
                return Ok(response);

            }
            catch (Exception e)
            {
                response.DisplayMessages = "Error";
                response.errorMessages = new List<string> { e.Message };
                return BadRequest(response);


            }
        }
        
       
        [Authorize]
        [Route("getSummaries")]
        [HttpGet]

        public Object getSummaries()
        {
            string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"

        };
            return Summaries;
        }
        [Route("getUsersList")]       
        [HttpGet]
        public async Task<IActionResult> get()
        {
            try
            {
                var list = await _context.users.ToListAsync();
                if (list!=null)
                {
                    response.DisplayMessages = "List of Users";
                    response.Result = list;
                    return Ok(response);


                }
                response.DisplayMessages = "Error, data not found";
                return BadRequest(response);


            }
            catch (Exception e)
            {
                response.DisplayMessages = "Error";
                response.errorMessages = new List<string> { e.Message };
                return BadRequest(response);


            }
        }
    }
}
