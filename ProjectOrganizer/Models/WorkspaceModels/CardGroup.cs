using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.WorkspaceModels
{
	public class CardGroup
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string Name { get; set; }
		public int Position { get; set; }
		public string Color { get; set; }
		public virtual Project Project { get; set; }
		public ICollection<Card> Cards { get; set; }
	}
}
