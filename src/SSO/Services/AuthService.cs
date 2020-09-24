using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SSO.Contract;
using SSO.Contract.Models;
using SSO.Options;
using SSO.Repository;
using SSO.Repository.Queries;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SSO.Exceptions;
using LinqToDB.Common;

namespace SSO.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthDBContext _authDBContext;
        private AuthServiceOptions _options;

        public AuthService(AuthDBContext authDBContext, IOptionsMonitor<AuthServiceOptions> optionsAccessor)
        {
            _authDBContext = authDBContext;
            _options = optionsAccessor.CurrentValue;
            optionsAccessor.OnChange((options, name) => _options = options);
        }

        public async Task<string> Login(LoginModel user)
        {
            await Task.CompletedTask;

            if (user == null || user.Username.IsNullOrEmpty() || user.Password.IsNullOrEmpty())
            {
                throw new AuthInvalidRequestException();
            }

            var userEntity = await _authDBContext.Users.GetUser(user.Username, user.Password);

            if (userEntity == null)
            {
                throw new AuthUserNotFoundException();
            }

            var userRoleQuery = await _authDBContext.GetUserRoles(userEntity.Id);
            var userClaims = new List<Claim>()
            {
                new Claim("Name", $"{userEntity.LastName} {userEntity.FirstName}")
            };
            
            foreach (var userRole in userRoleQuery)
            {
                userClaims.Add(new Claim("Role", userRole.Role));
            }

            var signingCredentials = new SigningCredentials(_options.IssuerSigningKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _options.ValidIssuer,
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
