using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectOrganizer.Models;
using ProjectOrganizer.Models.ViewModels;

namespace ProjectOrganizer.Controllers
{
	[Authorize]
	public class AccountController : Controller
	{
		private readonly ApplicationDbContext db;
		private UserManager<ApplicationUser> userManager;

		public AccountController(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
		{
			db = _db;
			userManager = _userManager;
		}


		public IActionResult Index(string username)
		{
			var user = userManager.Users.FirstOrDefault(u => u.UserName == username);
			UserViewModel user_model = new UserViewModel() { Username = user.UserName, Email = user.Email, Id = user.Id, ProfilePic = null };
			return View(user_model);
		}

		public async Task<IActionResult> Edit() {

			var user = await userManager.GetUserAsync(this.User);
			UserViewModel user_model = new UserViewModel() { Username = user.UserName, Email = user.Email, Id = user.Id, ProfilePic = null };
			return View(user_model);
		}

		[HttpPost]
		public async Task<IActionResult> GetUser() {

			var user = await userManager.GetUserAsync(this.User);

			string jsonString = JsonConvert.SerializeObject(new UserViewModel() { Email = user.Email, Id = user.Id, Username = user.UserName });
			return Json(new { success = true, responseText = jsonString });
		}
	}
}
