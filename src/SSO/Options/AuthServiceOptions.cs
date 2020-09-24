using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SSO.Options
{
    public class AuthServiceOptions
    {
        public string ValidIssuer { get; set; }
        public string IssuerSigningKeyString { get; set; }
        public SymmetricSecurityKey IssuerSigningKey { get; set; }
    }
}
