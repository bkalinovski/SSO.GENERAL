using SSO.Contract.Models;
using System;
using System.Threading.Tasks;

namespace SSO.Contract
{
    public interface IAuthService
    {
        Task<string> Login(LoginModel user);
    }
}
