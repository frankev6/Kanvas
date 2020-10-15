using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models
{
	public class Team
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }

		public string Name { get; set; }
		public ICollection<TeamUser> TeamMembers { get; set; }

		public ICollection<Project> TeamProjects { get; set; }
	}
}
