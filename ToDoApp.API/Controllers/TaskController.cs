using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Contracts;
using Core.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;
        public TaskController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }
        // GET: api/Task
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userService.GetInternalAsync(username);
            var tasks = await _taskService.GetAsync(user.Id);
            return Ok(tasks);
        }
        // GET: api/Task/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST: api/Task
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        // PUT: api/Task/
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> Put(TaskItemDTO task)
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userService.GetInternalAsync(username);
            
            await _taskService.AddAsync(task, user);

            return Ok();
        }
        // DELETE: api/Task/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
