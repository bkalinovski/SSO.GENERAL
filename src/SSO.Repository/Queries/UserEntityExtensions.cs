using System.Threading.Tasks;
using System.Linq;
using LinqToDB;
using SSO.Contract.Models.Entities;

namespace SSO.Repository.Queries
{
    public static class UserEntityExtensions
    {
        public static async Task<UserEntity> GetUser(this ITable<UserEntity> users, string username, string password)
        {
            return await users.Where<UserEntity>(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
        }
    }
}
