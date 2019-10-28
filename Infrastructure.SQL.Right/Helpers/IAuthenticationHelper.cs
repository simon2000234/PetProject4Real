using Core.Entities;

namespace Infrastructure.SQL.Right.Helpers
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(User user);

    }
}