using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SSO.Contract;
using SSO.Contract.Models;
using SSO.Exceptions;

namespace SSO.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            try
            {
                string token = await _authService.Login(user);
                return Ok(new { Token = token });
            }
            catch(AuthInvalidRequestException)
            {
                return BadRequest();
            }
            catch (AuthUserNotFoundException)
            {
                return Unauthorized();
            }
        }
    }
}