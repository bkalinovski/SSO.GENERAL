using SSO.Contract;
using SSO.Contract.Models.Entities;
using SSO.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SSO.Repository.Queries;
using LinqToDB;
using SSO.Contract.Models;
using SSO.Exceptions;

namespace SSO.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly AuthDBContext _authDBContext;

        public UserManagerService(AuthDBContext authDBContext)
        {
            _authDBContext = authDBContext;
        }

        public async Task CreateUser(NewUserModel user)
        {
            var userEntity = await _authDBContext.Users.GetUserByUsername(user.FirstName);

            if(userEntity != null)
            {
                throw new UserAlreadyExistsException();
            }

            await _authDBContext.Users.InsertUser(user);
        }

        public async Task DeleteUserById(int userId)
        {
            var userEntity = await _authDBContext.Users.GetUserById(userId);

            if (userEntity == null)
            {
                throw new UserNotFoundException();
            }

            await _authDBContext.Users.DeleteUserById(userId);
        }

        public Task<List<UserModel>> GetListOfAllUsers()
        {
            return _authDBContext.Users.GetListOfAllUsers();
        }

        public async Task<UserModel> GetUserByCredentials(string username, string password)
        {
            return await _authDBContext.Users.GetUser(username, password);
        }

        public async Task<UserModel> GetUserById(int userId)
        {
            var userEntity = await _authDBContext.Users.GetUserById(userId);

            if (userEntity == null)
            {
                throw new UserNotFoundException();
            }

            return userEntity;
        }

        public async Task<List<string>> GetUserRoles(int userId)
        {
            return await _authDBContext.GetUserRoles(userId);
        }

        public async Task UpdateUserData(NewUserModel user, int userId)
        {
            var userEntity = await _authDBContext.Users.GetUserById(userId);

            if (userEntity == null)
            {
                throw new UserNotFoundException();
            }

            await _authDBContext.Users.UpdatetUser(user, userId);
        }
    }
}
