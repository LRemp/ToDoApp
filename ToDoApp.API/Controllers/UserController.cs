using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Contracts;
using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenService;
        public UserController(IUserService userService, IJwtTokenService jwtTokenService)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDTO createUser)
        {
            var user = await _userService.GetAsync(createUser.Username);
            if (user != null)
            {
                return BadRequest("User already exists");
            }

            await _userService.AddAsync(createUser);

            User createdUser = await _userService.GetInternalAsync(createUser.Username);
            List<string> userRoles = await _userService.GetUserRoles(createdUser);
            var token = _jwtTokenService.CreateAccessToken(createdUser, userRoles);

            var login = new AuthenticatedLoginDTO
            {
                Token = token,
                Username = createdUser.Username
            };
            return Ok(login);
        }
    }
}
