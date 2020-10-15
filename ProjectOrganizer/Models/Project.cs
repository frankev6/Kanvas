using ProjectOrganizer.Models.WorkspaceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models
{
	public class Project
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public string BackgroundC { get; set; }
		public ICollection<LabelModule> Labels { get; set; }
		public ICollection<CardGroup> CardGroups { get; set; }
		public ICollection<ProjectUser> ProjectUsers { get; set; }
		
		public Team Team { get; set; }
		public bool isPublic { get; set; }
	}
}
