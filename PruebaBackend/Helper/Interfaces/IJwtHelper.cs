using PruebaBackend.Entities;

namespace PruebaBackend.Helper.Interfaces
{
    public interface IJwtHelper
    {
        string GenerateJwtToken(User user);
    }
}
