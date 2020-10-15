using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.WorkspaceModels
{
	

	public class ProjectUser
	{
		public enum UserRoles
		{
			Viewer = 0,
			Editor,
			Owner//owner owns the project
		}
		
		public string ProjectId { get; set; }
		public Project Project { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		public UserRoles UserRole { get; set; }

	}
}
