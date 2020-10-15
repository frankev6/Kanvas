using Microsoft.AspNetCore.Identity;
using ProjectOrganizer.Models.WorkspaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ICollection<ProjectUser> ProjectUsers { get; set; }

		public ICollection<TeamUser> TeamMembers { get; set; }

	}
}
