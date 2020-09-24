using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace SSO.Repository.Infrastructure
{
    public static class ServiceProviderExtensions
    {
        public static string GetAuthDBConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("AuthDBContext");
        }
    }
}
