using Microsoft.EntityFrameworkCore;
using WebApiJWT.Context;
using WebApiJWT.Models;

namespace WebApiJWT.Repository
{
    public class RepositoryClient : InterfaceClient
    {
        private readonly ApplicationDbContext context;

        public RepositoryClient(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<string> CreateUpdateClient(Client client)
        {
            try
            {
                string state="internal error";
                if (client.id>0)//update
                {
                    context.clients.Update(client);
                    state = "update Client!";
                }
                else//create
                {
                    await context.AddAsync(client);

                    state = "new Client!";
                }
                await context.SaveChangesAsync();
                return state;
            }
            catch (Exception e)
            {

                return e.ToString();
            }
        }

        public async Task<Client> getClientById(int id)
        {
            try
            {
                var client = await context.clients.FindAsync(id);
                if (client!=null)
                {
                    return client;

                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<Client>> GetClients()
        {
            try
            {
                List<Client> clients = await context.clients.ToListAsync();
                return clients;
            }
            catch (Exception)
            {
                return null;
                
            }
        }

        public async Task<bool> removeClient(int id)
        {
            try
            {
                var client = await context.clients.FindAsync(id);
                if (client!=null)
                {
                    context.clients.Remove(client);
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
