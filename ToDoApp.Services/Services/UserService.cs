using Core.Contracts;
using Core.DTOs;
using Core.Entities;

namespace Services.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<UserDTO> GetAsync(string username)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetInternalAsync(string username)
    {
        User user = await _userRepository.GetUser(username);
        return user;
    }

    public Task UpdatePasswordAsync(UserUpdatePasswordDTO user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckPasswordAsync(LoginDTO login)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> GetUserRoles(string username)
    {
        throw new NotImplementedException();
    }
}