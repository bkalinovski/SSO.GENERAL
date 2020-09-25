using System.Threading.Tasks;
using System.Linq;
using LinqToDB;
using SSO.Contract.Models.Entities;
using System.Collections.Generic;
using SSO.Contract.Models;
using LinqToDB.Linq;
using LinqToDB.Common;
using SSO.Repository.Infrastructure;

namespace SSO.Repository.Queries
{
    public static class UserEntityExtensions
    {
        public static async Task<UserModel> GetUser(this ITable<UserEntity> users, string username, string password)
        {

            return await users
                            .Where(u => u.Username == username && u.Password == PasswordEncoder.Encrypt(password))
                            .Select(u => new UserModel
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Age = u.Age,
                                Phone = u.Phone,
                                Username = u.Username

                            })
                            .FirstOrDefaultAsync();
        }

        public static async Task<UserModel> GetUserById(this ITable<UserEntity> users, int userId)
        {
            return await users
                            .Where(u => u.Id == userId)
                            .Select(u => new UserModel
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Age = u.Age,
                                Phone = u.Phone,
                                Username = u.Username

                            })
                            .FirstOrDefaultAsync();
        }

        public static async Task<string> GetDecodedUserPassword(this ITable<UserEntity> users, int userId)
        {
            return await users.Where(u => u.Id == userId).Select(u => PasswordEncoder.Decrypt(u.Password)).FirstOrDefaultAsync();
        }

        public static async Task<UserModel> GetUserByUsername(this ITable<UserEntity> users, string username)
        {
            return await users
                            .Where(u => u.Username == username)
                            .Select(u => new UserModel
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Age = u.Age,
                                Phone = u.Phone,
                                Username = u.Username

                            })
                            .FirstOrDefaultAsync();
        }

        public static async Task<List<UserModel>> GetListOfAllUsers(this ITable<UserEntity> users)
        {
            return await users
                            .Select(u => new UserModel
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Age = u.Age,
                                Phone = u.Phone,
                                Username = u.Username

                            }).
                            ToListAsync();
        }

        public static async Task InsertUser(this ITable<UserEntity> users, NewUserModel user)
        {
            await users
                    .Value(u => u.FirstName, user.FirstName)
                    .Value(u => u.LastName, user.LastName)
                    .Value(u => u.Age, user.Age)
                    .Value(u => u.Phone, user.Phone)
                    .Value(u => u.Username, user.Username)
                    .Value(u => u.Password, PasswordEncoder.Encrypt(user.Password))
                    .InsertAsync();
        }

        public static async Task UpdatetUser(this ITable<UserEntity> users, NewUserModel user, int userId)
        {
            await users
                    .Where(u => u.Id == userId)
                    .Set(u => u.FirstName, user.FirstName)
                    .Set(u => u.LastName, user.LastName)
                    .Set(u => u.Age, user.Age)
                    .Set(u => u.Phone, user.Phone)
                    .Set(u => u.Username, user.Username)
                    .Set(u => u.Password, PasswordEncoder.Encrypt(user.Password))
                    .UpdateAsync();           
        }

        public static async Task DeleteUserById(this ITable<UserEntity> users, int userId)
        {
            await users
                .Where(u => u.Id == userId)
                .DeleteAsync();
        }
    }
}
