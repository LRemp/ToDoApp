using Core.Entities;

namespace Core.Contracts;

public interface IJwtTokenService
{
    public string CreateAccessToken(User user, List<string> roles);
}