using Core.Contracts;
using Core.DTOs;
using Core.Entities;
using Dapper;
using MySqlConnector;
using Task = System.Threading.Tasks.Task;

namespace Repositories.Repositories;

public class UserRepository: IUserRepository
{
    private readonly MySqlConnection _mySqlConnection;
    public UserRepository(MySqlConnection mysqlConnection)
    {
        _mySqlConnection = mysqlConnection;
    }
    public async Task<User> GetUser(int username)
    {
        var query = @"SELECT * FROM users WHERE username = @username";

        var user = await _mySqlConnection.QueryAsync<User>(query, new { username });
        return user.FirstOrDefault();
    }
    public async Task CreateUser(UserDTO user)
    {
        var query = @"INSERT INTO users (username, email, password)
                      VALUES(@username, @email, @passwrd)";

        await _mySqlConnection.QueryAsync(query, new
        {
            username = user.Username,
            email = user.Email,
            password = user.Password
        });
    }

    public async Task UpdatePassword(UserUpdatePasswordDTO user)
    {
        var query = @"UPDATE users
                        SET password = @password
                        WHERE username = @username";

        await _mySqlConnection.QueryAsync(query, new
        {
            username = user.Username,
            password = user.Password
        });
    }
}