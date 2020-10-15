using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models
{
	public class TeamUser
	{

		public enum UserRoles
		{
			Guest,//can view
			Member,//cant delete projects
			Admin,//all permissions
			Owner
		}

		public string TeamId { get; set; }
		public Team Team { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
		public UserRoles UserRole { get; set; }
	}
}
