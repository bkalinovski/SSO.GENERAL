using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SSO.Exceptions
{
    public class AuthUserNotFoundException : AuthException
    {
        public AuthUserNotFoundException() : base(HttpStatusCode.NotFound)
        {
        }

        public AuthUserNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }

        public AuthUserNotFoundException(string message, Exception innerException) : base(message, innerException, HttpStatusCode.NotFound)
        {
        }
    }
}
