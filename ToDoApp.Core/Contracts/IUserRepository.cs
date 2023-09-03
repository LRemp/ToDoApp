using Core.DTOs;
using Core.Entities;
using Task = System.Threading.Tasks.Task;

namespace Core.Contracts;

public interface IUserRepository
{
    public Task<User> GetUser(int username);
    public Task CreateUser(UserDTO user);
}