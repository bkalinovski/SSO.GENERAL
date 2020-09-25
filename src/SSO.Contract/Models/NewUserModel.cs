using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Contract.Models
{
    public class NewUserModel : UserModel
    {
        public string Password { get; set; }
    }
}
