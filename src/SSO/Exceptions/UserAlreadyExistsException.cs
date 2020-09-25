using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SSO.Exceptions
{
    public class UserAlreadyExistsException : UserManagementException
    {
        public UserAlreadyExistsException() : base(HttpStatusCode.BadRequest)
        {
        }

        public UserAlreadyExistsException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }

        public UserAlreadyExistsException(string message, Exception innerException) : base(message, innerException, HttpStatusCode.BadRequest)
        {
        }
    }
}
