using Core.Contracts;
using Core.DTOs;
using Core.Entities;
using Task = System.Threading.Tasks.Task;

namespace Repositories.Repositories;

public class UserRepository: IUserRepository
{
    public Task<User> GetUser(int username)
    {
        throw new NotImplementedException();
    }
    public Task CreateUser(UserDTO user)
    {
        throw new NotImplementedException();
    }
}