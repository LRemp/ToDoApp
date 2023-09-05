using Core.DTOs;
using Core.Entities;
using Task = System.Threading.Tasks.Task;

namespace Core.Contracts;

public interface IUserRepository
{
    public Task<User> GetUser(string username);
    public Task CreateUser(CreateUserDTO user);
    public Task UpdatePassword(UserUpdatePasswordDTO user);
    public Task<bool> GetHasAdminRole(string username);
}