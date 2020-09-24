using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Options
{
    public class AuthServiceOptionsPostConfigure : IPostConfigureOptions<AuthServiceOptions>
    {
        public void PostConfigure(string name, AuthServiceOptions options)
        {
            if (options.IssuerSigningKey == null)
            {
                options.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.IssuerSigningKeyString));
            }
        }
    }
}
