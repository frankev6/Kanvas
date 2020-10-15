using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.WorkspaceModels
{
	public class CommentModule
	{
		[Key]
		public int Id { get; set; }
		public string Comment { get; set; }
		public string  Date { get; set; }
		public Card Card { get; set; }

		public CommentModule()
		{
			Date = DateTime.Now.ToString();
		}
	}
}
