using SSO.Contract.Models;
using SSO.Contract.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Contract
{
    public interface IUserManagerService
    {
        Task<UserModel> GetUserByCredentials(string username, string password);

        Task<UserModel> GetUserById(int userId);

        Task<List<UserModel>> GetListOfAllUsers();

        Task<List<string>> GetUserRoles(int userId); 

        Task CreateUser(NewUserModel user);

        Task UpdateUserData(NewUserModel user, int userId);

        Task DeleteUserById(int userId);
    }
}
