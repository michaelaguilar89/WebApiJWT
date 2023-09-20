using WebApiJWT.Models;

namespace WebApiJWT.Repository
{
    public interface InterfaceAuthentication
    {
        bool validateUser(User user);

        string generateToken(DateTime expirationDate, User user);

    }
}
