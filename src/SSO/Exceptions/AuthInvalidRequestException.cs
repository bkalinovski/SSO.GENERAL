using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SSO.Exceptions
{
    public class AuthInvalidRequestException : AuthException
    {
        public AuthInvalidRequestException() : base(HttpStatusCode.BadRequest)
        {
        }

        public AuthInvalidRequestException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }

        public AuthInvalidRequestException(string message, Exception innerException) : base(message, innerException, HttpStatusCode.BadRequest)
        {
        }
    }
}
