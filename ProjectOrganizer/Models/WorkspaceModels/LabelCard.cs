using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.WorkspaceModels
{
	public class LabelCard
	{
		[Key]
		public int Id { get; set; }
		public string LabelId { get; set; }
		public LabelModule Label { get; set; }
		public string CardId { get; set; }
		public Card Card { get; set; }
	}
}
