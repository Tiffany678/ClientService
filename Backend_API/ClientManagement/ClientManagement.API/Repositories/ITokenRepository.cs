using Microsoft.AspNetCore.Identity;

namespace ClientManagement.API.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
