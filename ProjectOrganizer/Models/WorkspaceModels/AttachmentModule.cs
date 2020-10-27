using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.WorkspaceModels
{
	public class AttachmentModule
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public string Id { get; set; }
		public string FileId { get; set; }//document.id, can be null
		public string Name { get; set; }//document.Name
		public string EmbedUrl { get; set; }
		public string Url { get; set; }//document.url
		public string DocumentType { get; set; }//document.type, or link
		public string CardId { get; set; }
		[JsonIgnore]
		public Card Card { get; set; }
		public int Position { get; set; }
	}
}
