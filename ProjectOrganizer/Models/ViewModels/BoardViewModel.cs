using ProjectOrganizer.Models.WorkspaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.ViewModels
{
	public class BoardViewModel
	{
		public ProjectUser ProjectUser { get; set; }
		//as of now its really ugly to have to use include then include 1mil times
		// so ill just do this instead :(
		public Project Project { get; set; }
	}
}
