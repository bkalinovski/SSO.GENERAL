﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Contract.Models.Entities
{
    public class UserEntity
    {
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int Age { get; set; }

		public string Phone { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }
	}
}
