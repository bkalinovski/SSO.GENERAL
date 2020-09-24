using SSO.Contract.Models.QueryResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using LinqToDB;

namespace SSO.Repository.Queries
{
    public static class AuthContextExtensions
    {
        public static async Task<List<UserRoleQueryResult>> GetUserRoles(this AuthDBContext context, int userId)
        {
            var query = (from ur in context.UserRoles
                         from r in context.Roles.Where(r => r.Id == ur.RoleId)
                         where ur.UserId == userId
                         select new UserRoleQueryResult
                         {
                             Role = r.Name
                         });

            return await query.ToListAsync();
        }
    }
}
