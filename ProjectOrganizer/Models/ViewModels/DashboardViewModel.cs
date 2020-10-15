using ProjectOrganizer.Models.WorkspaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.ViewModels
{
	public class DashboardViewModel
	{
		public List<ProjectUser> ProjectUsers { get; set; }
		public List<TeamUser> Teams { get; set; }
	}
}
