using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.WorkspaceModels
{
	public class LabelModule
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string  Name { get; set; }
		public string Color { get; set; }
		[JsonIgnore]
		public Project Project { get; set; }
		[JsonIgnore]
		public ICollection<LabelCard> LabelCards { get; set; }
	}
}
