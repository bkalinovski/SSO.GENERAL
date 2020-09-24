using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SSO.Exceptions
{
    public abstract class AuthException : Exception
    {
        public HttpStatusCode ResultCode { get; set; }

        public AuthException(string message, Exception innerException, HttpStatusCode statusCode) : base(message, innerException)
        {
            ResultCode = statusCode;
        }

        public AuthException(string message, HttpStatusCode statusCode) : this(message, null, statusCode)
        {
        }

        public AuthException(HttpStatusCode statusCode) : this(null, null, statusCode)
        {
        }

        public AuthException() : this(HttpStatusCode.NotFound)
        {
        }
    }
}
