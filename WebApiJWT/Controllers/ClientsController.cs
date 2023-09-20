using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiJWT.Dto;
using WebApiJWT.Models;
using WebApiJWT.Repository;

namespace WebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly RepositoryClient repositoryclient;
        protected responseDto response;
        public ClientsController(RepositoryClient repositoryclient)
        {
            this.repositoryclient = repositoryclient;
             response = new responseDto();
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var list = await repositoryclient.GetClients();
                response.Result=list;
                response.DisplayMessages = "List of Clients";
                return Ok(response);
            }
            catch (Exception e)
            {

                response.DisplayMessages = "Error";
                response.errorMessages= new List<string> { e.Message};
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClient(Client client)
        {
            try
            {
                var state = await repositoryclient.CreateUpdateClient(client);
                if (state == "new Client!")
                {
                    response.DisplayMessages = "new Client!";
                    return Ok(response);
                }
                response.DisplayMessages = "Error";
                response.errorMessages = new List<string> { state };
                return BadRequest(response);
            }
            catch (Exception e)
            {

                response.DisplayMessages = "Error";
                response.errorMessages = new List<string> { e.Message };
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClient(Client client)
        {
            try
            {
                var state = await repositoryclient.CreateUpdateClient(client);
                if (state == "update Client!")
                {
                    response.DisplayMessages = "update Client!";
                    return Ok(response);
                }
                response.DisplayMessages = "Error";
                response.errorMessages = new List<string> { state };
                return BadRequest(response);
            }
            catch (Exception e)
            {

                response.DisplayMessages = "Error";
                response.errorMessages = new List<string> { e.Message };
                return BadRequest(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var client = await repositoryclient.getClientById(id);
                if (client!=null)
                {
                    response.Result = client;
                    response.DisplayMessages = "Client Information";
                    return Ok(response);
                }
                response.DisplayMessages = "Error, client not found";
              
                return BadRequest(response);
            }
            catch (Exception e)
            {

                response.DisplayMessages = "Error";
                response.errorMessages = new List<string> { e.Message };
                return BadRequest(response);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveClient(int id)
        {
            try
            {
                var state =await repositoryclient.removeClient(id);
                if (state==true)
                {
                   
                    response.DisplayMessages = "Client removed!";
                    return Ok(response);
                }
                response.DisplayMessages = "Error, client not found";

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
