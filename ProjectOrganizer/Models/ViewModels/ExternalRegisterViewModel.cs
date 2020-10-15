using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models.ViewModels
{
	public class ExternalRegisterViewModel
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Email { get; set; }
		public string ReturnUrl { get; set; }
	}
}
