using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.WorkspaceModels
{
	[JsonObject]
	public class Card
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string  Name { get; set; }
		//public string Description { get; set; }
		public int CardGroupId { get; set; }
		public int Position { get; set; }
		public string Color { get; set; }

		[JsonIgnore]
		public virtual CardGroup CardGroup { get; set; }

		[JsonIgnore]
		public ICollection<LabelCard> LabelCards { get; set; }

		[JsonIgnore]
		public ICollection<CommentModule> CommentModules { get; set; }
		[JsonIgnore]
		public ICollection<AttachmentModule> AttachmentModules { get; set; }

		[NotMapped]
		public List<LabelModule> L_Labels { get; set; }
		[NotMapped]
		public List<CommentModule> L_CommentModules
		{ get { return CommentModules.ToList(); } }
		[NotMapped]
		public List<AttachmentModule> L_AttachmentModules
		{ get { return AttachmentModules.ToList(); } }

		public Card()
		{
			LabelCards = new List<LabelCard>();
			CommentModules = new List<CommentModule>();
			AttachmentModules = new List<AttachmentModule>();
		}
	}
}
