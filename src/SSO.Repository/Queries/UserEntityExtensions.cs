using System.Threading.Tasks;
using System.Linq;
using LinqToDB;
using SSO.Contract.Models.Entities;
using System.Collections.Generic;
using SSO.Contract.Models;
using LinqToDB.Linq;
using LinqToDB.Common;

namespace SSO.Repository.Queries
{
    public static class UserEntityExtensions
    {
        public static async Task<UserEntity> GetUser(this ITable<UserEntity> users, string username, string password)
        {
            return await users.Where<UserEntity>(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }

        public static async Task<UserEntity> GetUserById(this ITable<UserEntity> users, int userId)
        {
            return await users.Where<UserEntity>(u => u.Id == userId).FirstOrDefaultAsync();
        }

        public static async Task<UserEntity> GetUserByUsername(this ITable<UserEntity> users, string username)
        {
            return await users.Where<UserEntity>(u => u.Username == username).FirstOrDefaultAsync();
        }

        public static async Task<List<UserEntity>> GetListOfAllUsers(this ITable<UserEntity> users)
        {
            return await users.ToListAsync();
        }

        public static async Task InsertUser(this ITable<UserEntity> users, UserModel user)
        {
            await users
                    .Value(u => u.FirstName, user.FirstName)
                    .Value(u => u.LastName, user.LastName)
                    .Value(u => u.Age, user.Age)
                    .Value(u => u.Phone, user.Phone)
                    .Value(u => u.Username, user.Username)
                    .Value(u => u.Password, user.Password)
                    .InsertAsync();
        }

        public static async Task UpdatetUser(this ITable<UserEntity> users, UserModel user, int userId)
        {
            await users
                    .Where(u => u.Id == userId)
                    .Set(u => u.FirstName, user.FirstName)
                    .Set(u => u.LastName, user.LastName)
                    .Set(u => u.Age, user.Age)
                    .Set(u => u.Phone, user.Phone)
                    .Set(u => u.Username, user.Username)
                    .Set(u => u.Password, user.Password)
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
