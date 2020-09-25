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
        Task<UserEntity> GetUserByCredentials(string username, string password);

        Task<UserEntity> GetUserById(int userId);

        Task<List<UserEntity>> GetListOfAllUsers();

        Task<List<string>> GetUserRoles(int userId); 

        Task CreateUser(UserModel user);

        Task UpdateUserData(UserModel user, int userId);

        Task DeleteUserById(int userId);
    }
}
