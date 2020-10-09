using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSO.Contract;
using SSO.Contract.Models;
using SSO.Contract.Models.Entities;
using SSO.Exceptions;

namespace SSO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminRolePolicy")]
    public class UserController : ControllerBase
    {
        private readonly IUserManagerService _userManagerService;

        public UserController(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int userId)
        {
            try 
            {
                var user = await _userManagerService.GetUserById(userId);
                return Ok(user);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewUserModel user)
        {
            try
            {
                await _userManagerService.CreateUser(user);
            }
            catch(UserAlreadyExistsException)
            {
                return BadRequest(new { error = "This username already exists"});
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NewUserModel user, [FromQuery] int userId)
        {
            try
            {
                await _userManagerService.UpdateUserData(user, userId);
            }
            catch (UserNotFoundException)
            {
                return NotFound(new { error = $"User with Id {userId} was not found" });
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int userId)
        {
            try
            {
                await _userManagerService.DeleteUserById(userId);
            }
            catch (UserNotFoundException)
            {
                return NotFound(new { error = $"User with Id {userId} was not found" });
            }

            return Ok();
        }
    }
}