using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SSO.Exceptions
{
    public abstract class UserManagementException : Exception
    {
        public HttpStatusCode ResultCode { get; set; }

        public UserManagementException(string message, Exception innerException, HttpStatusCode statusCode) : base(message, innerException)
        {
            ResultCode = statusCode;
        }

        public UserManagementException(string message, HttpStatusCode statusCode) : this(message, null, statusCode)
        {
        }

        public UserManagementException(HttpStatusCode statusCode) : this(null, null, statusCode)
        {
        }

        public UserManagementException() : this(HttpStatusCode.NotFound)
        {
        }
    }
}
