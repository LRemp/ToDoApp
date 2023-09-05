using AutoMapper;
using Core.Contracts;
using Core.DTOs;
using Core.Entities;

namespace Services.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<UserDTO> GetAsync(string username)
    {
        var user = await _userRepository.GetUser(username);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<User> GetInternalAsync(string username)
    {
        User user = await _userRepository.GetUser(username);
        return user;
    }

    public async Task AddAsync(CreateUserDTO user)
    {
        var password = BCrypt.Net.BCrypt.HashPassword(user.Password);

        await _userRepository.CreateUser(new CreateUserDTO()
        {
            Username = user.Username,
            Email = user.Email,
            Password = password
        });
    }

    public async Task<bool> UpdatePasswordAsync(UserUpdatePasswordDTO user)
    {
        var isPasswordCorrect = await CheckPasswordAsync(new LoginDTO
        {
            Username = user.Username,
            Password = user.Password
        });
        if(!isPasswordCorrect)
        {
            return false;
        }

        await _userRepository.UpdatePassword(user);
        return true;
    }

    public async Task<bool> CheckPasswordAsync(LoginDTO login)
    {
        var user = await _userRepository.GetUser(login.Username);
        return BCrypt.Net.BCrypt.Verify(login.Password, user.Password);
    }

    public async Task<List<string>> GetUserRoles(User user)
    {
        List<string> roles = new List<string>
        {
            "User"
        };
        var hasAdminRole = await _userRepository.GetHasAdminRole(user.Username);
        if (hasAdminRole) roles.Add("Admin");
        return roles;
    }
}