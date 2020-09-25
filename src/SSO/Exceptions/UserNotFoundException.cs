using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SSO.Exceptions
{
    public class UserNotFoundException : UserManagementException
    {
        public UserNotFoundException() : base(HttpStatusCode.NotFound)
        {
        }

        public UserNotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }

        public UserNotFoundException(string message, Exception innerException) : base(message, innerException, HttpStatusCode.NotFound)
        {
        }
    }
}
