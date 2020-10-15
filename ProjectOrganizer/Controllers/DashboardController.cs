using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectOrganizer.Models;
using ProjectOrganizer.Models.ViewModels;
using ProjectOrganizer.Models.WorkspaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Controllers.BusinessControllers
{
	[Authorize]
	public class DashboardController : Controller
	{
		


		private readonly ApplicationDbContext db;
		[BindProperty]
		public Project project { get; set; }
		private UserManager<ApplicationUser> userManager;

		public DashboardController(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
		{
			db = _db;
			userManager = _userManager;
		}

		public async Task<IActionResult> Index() {
			var user = await userManager.GetUserAsync(this.User);
			var appUser = userManager.Users.Include(t => t.TeamMembers).ThenInclude(t => t.Team).ThenInclude(t => t.TeamProjects).Include(c => c.ProjectUsers).ThenInclude(pu => pu.Project).ThenInclude(t => t.Team).FirstOrDefault(c => c.Id == user.Id);
			DashboardViewModel dashView = new DashboardViewModel() {

				ProjectUsers = appUser.ProjectUsers.ToList(),
				Teams = appUser.TeamMembers.ToList()
		};

			return View(dashView);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProjects() {
			return Json(new { data = await db.Projects.ToListAsync() });
		}
		
		[HttpPost]
		public async Task<IActionResult> NewProject(string name, string description) {

			if (name == "")
			{
				return NoContent();
			}

			var random = new Random();
			var color = String.Format("#{0:X6}", random.Next(0x1000000));

			project = new Project();
			project.Name = name;
			project.Description = description;
			project.BackgroundC = color;
			project.ProjectUsers = new List<ProjectUser>();
			project.ProjectUsers.Add(new ProjectUser() { UserRole = ProjectUser.UserRoles.Owner, User = await userManager.GetUserAsync(this.User), Project = project });
			db.Projects.Add(project);

			db.SaveChanges();

			return Json(new { success = true, responseText = project.Id });
		}

		

	}

}
