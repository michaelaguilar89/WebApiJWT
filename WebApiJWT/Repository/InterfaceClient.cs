using WebApiJWT.Models;

namespace WebApiJWT.Repository
{
    public interface InterfaceClient
    {
         Task<List<Client>> GetClients();
        Task<string> CreateUpdateClient(Client client);

         Task<Client> getClientById(int id);

        Task<bool> removeClient(int id);

        
    }
}
