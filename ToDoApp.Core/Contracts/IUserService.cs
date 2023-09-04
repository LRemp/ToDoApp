using Core.DTOs;
using Core.Entities;

namespace Core.Contracts;

public interface IUserService
{
    public Task<UserDTO> GetAsync(string username);
    public Task<User> GetInternalAsync(string username);
    public Task AddAsync(CreateUserDTO user);
    public Task<bool> UpdatePasswordAsync(UserUpdatePasswordDTO user);
    public Task<bool> CheckPasswordAsync(LoginDTO login);
    public Task<List<string>> GetUserRoles(User user);
}