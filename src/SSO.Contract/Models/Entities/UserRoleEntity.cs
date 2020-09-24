using System;
using System.Collections.Generic;
using System.Text;

namespace SSO.Contract.Models.Entities
{
    public class UserRoleEntity
    {
		public int Id { get; set; }

		public int UserId { get; set; }

		public int RoleId { get; set; }

		public DateTime InsertDate { get; set; }

		public DateTime DueDate { get; set; }
	}
}
