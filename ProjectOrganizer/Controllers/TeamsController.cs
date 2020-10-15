using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOrganizer.Models;
using ProjectOrganizer.Models.WorkspaceModels;

namespace ProjectOrganizer.Controllers
{
	[Authorize]
	public class TeamsController : Controller
	{
		private readonly ApplicationDbContext db;
		private UserManager<ApplicationUser> userManager;

		public TeamsController(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
		{
			db = _db;
			userManager = _userManager;
		}

		public async Task<IActionResult> Index() //show teams
		{
			var user = await userManager.GetUserAsync(this.User);

			List<TeamUser> teams = new List<TeamUser>();

			teams = db.TeamUser.Include(t => t.Team).ThenInclude(t => t.TeamMembers).ThenInclude(u => u.User).Where(tu => tu.UserId == user.Id).ToList();

			return View(teams);
		}
		public async Task<IActionResult> Dashboard(string id) //show teams
		{
			var user = await userManager.GetUserAsync(this.User);
			var teamuser = db.TeamUser.Include(t => t.Team).ThenInclude(t => t.TeamProjects).Include(t => t.Team).ThenInclude(t => t.TeamMembers).ThenInclude(u => u.User).FirstOrDefault(tu => tu.UserId == user.Id && tu.TeamId == id);
			return View(teamuser);
		}


		[HttpPost]
		public async Task<IActionResult> CreateTeam(string name) {
			Team newTeam = new Team() { Name = name };

			TeamUser tu = new TeamUser() { User = await userManager.GetUserAsync(this.User), UserRole = TeamUser.UserRoles.Owner, Team = newTeam };

			db.TeamUser.Add(tu);
			db.SaveChanges();
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteTeam(string teamId, bool deleteProjects) {

			var user = await userManager.GetUserAsync(this.User);



			Team team = db.Team.Include(t => t.TeamMembers).Include(p => p.TeamProjects).ThenInclude(p => p.ProjectUsers).FirstOrDefault(t => t.Id == teamId);
			var member = team.TeamMembers.FirstOrDefault(u => u.UserId == user.Id);

			if (member.UserRole != TeamUser.UserRoles.Owner)
			{
				return NoContent();
			}
			else { 
			

			if (deleteProjects == false)
			{
				foreach (var p in team.TeamProjects)
				{
					var pUsers = new List<ProjectUser>();
					pUsers.Add(new ProjectUser() { Project = p, User = p.ProjectUsers.FirstOrDefault(p => p.UserRole == ProjectUser.UserRoles.Owner).User, UserRole = ProjectUser.UserRoles.Owner });
					
					foreach (var pu in p.ProjectUsers)
					{
						db.ProjectUser.Remove(pu);
					}

					p.ProjectUsers = pUsers;
				}
				db.SaveChanges();
			}
			else {
				foreach (var p in team.TeamProjects)
				{
					foreach (var pu in p.ProjectUsers)
					{
						db.ProjectUser.Remove(pu);
					}
				}

			}
				db.TeamUser.RemoveRange(team.TeamMembers);
				db.Team.Remove(team);

				db.SaveChanges();
			}
			
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> AddUserToTeam(string teamId, string username) {

			//Create User-project for each project in teams
			var user = await userManager.GetUserAsync(this.User);
			var userToAdd = await userManager.FindByNameAsync(username);

			if (userToAdd == null)
			{
				return NoContent();
			}

			Team t = db.Team.Include(p => p.TeamProjects).Include(t => t.TeamMembers).ThenInclude(t => t.User).FirstOrDefault(t => t.Id == teamId);

			var member = t.TeamMembers.FirstOrDefault(u => u.User.Id == user.Id);

			if (member.UserRole == TeamUser.UserRoles.Admin || member.UserRole == TeamUser.UserRoles.Owner)
			{
				db.TeamUser.Add(new TeamUser() { Team = t, User = userToAdd, UserRole = TeamUser.UserRoles.Member });

				foreach (var p in t.TeamProjects)
				{
					p.ProjectUsers.Add(new ProjectUser() { 
						Project = p, 
						User = userToAdd, 
						UserRole = ProjectUser.UserRoles.Editor
					});
				}

				db.SaveChanges();
			}

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> RemoveUserFromTeam(string teamId, string username) {

			//Remove User-project for each project in teams
			var user = await userManager.GetUserAsync(this.User);
			var userToRemove = await userManager.FindByNameAsync(username);

			Team t = db.Team.Include(p => p.TeamProjects).Include(t => t.TeamMembers).FirstOrDefault(t => t.Id == teamId);

			var member = t.TeamMembers.FirstOrDefault(u => u.User.Id == user.Id);

			if (member.UserRole == TeamUser.UserRoles.Admin || member.UserRole == TeamUser.UserRoles.Owner)
			{

				foreach (var p in t.TeamProjects)
				{
					p.ProjectUsers.Remove(p.ProjectUsers.FirstOrDefault(p => p.User.Id == userToRemove.Id));
				}

				t.TeamMembers.Remove(t.TeamMembers.FirstOrDefault(t => t.User.Id == userToRemove.Id));

				db.SaveChanges();
			}

			return NoContent();
		}


		public async Task<IActionResult> AddProjectToTeam(string teamId, string projectId) {
			var user = await userManager.GetUserAsync(this.User);

			Project p = db.Projects.Include(p => p.ProjectUsers).FirstOrDefault(p => p.Id == projectId);

			if (p.ProjectUsers.FirstOrDefault(u => u.User.Id == user.Id).UserRole == ProjectUser.UserRoles.Owner)
			{
				db.Team.FirstOrDefault(t => t.Id == teamId).TeamProjects.Add(p);
			db.SaveChanges();
			}

			return NoContent();
		}

		public IActionResult RemoveProjectFromTeam(string projectId) { // Does not mean delete project

			Project p = db.Projects.Include(p => p.ProjectUsers).Include(p => p.Team).FirstOrDefault(p => p.Id == projectId);

			p.Team.TeamProjects.FirstOrDefault(p => p.Id == p.Id);

			var pUsers = new List<ProjectUser>();
			pUsers.Add(new ProjectUser() { Project = p, User = p.ProjectUsers.FirstOrDefault(p => p.UserRole == ProjectUser.UserRoles.Owner).User, UserRole = ProjectUser.UserRoles.Owner });

			foreach (var pu in p.ProjectUsers)
			{
				db.ProjectUser.Remove(pu);
			}

			p.ProjectUsers = pUsers;

			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> NewProject(string teamId, string name, string description)
		{
			var user = await userManager.GetUserAsync(this.User);

			TeamUser teamuser = db.TeamUser.Include(t => t.Team).ThenInclude(t => t.TeamMembers).ThenInclude(t => t.User).FirstOrDefault(t => t.TeamId == teamId && t.UserId == user.Id);

			if (teamuser.UserRole == TeamUser.UserRoles.Guest || teamuser.UserRole == TeamUser.UserRoles.Member)
			{
				return NoContent();
			}

			if (string.IsNullOrWhiteSpace(name))
			{
				return NoContent();
			}

			var random = new Random();
			var color = String.Format("#{0:X6}", random.Next(0x1000000));

			Project project = new Project();
			project.Name = name;
			project.Description = description;
			project.BackgroundC = color;
			project.ProjectUsers = new List<ProjectUser>();
			project.Team = teamuser.Team;

			foreach (var member in teamuser.Team.TeamMembers)
			{
				if (member.UserRole == TeamUser.UserRoles.Owner)
				{
					project.ProjectUsers.Add(new ProjectUser() { UserRole = ProjectUser.UserRoles.Owner, User = member.User, Project = project });
				}
				else if (member.UserRole == TeamUser.UserRoles.Admin || member.UserRole == TeamUser.UserRoles.Member)
				{
					project.ProjectUsers.Add(new ProjectUser() { UserRole = ProjectUser.UserRoles.Editor, User = member.User, Project = project });
				}
				else if (member.UserRole == TeamUser.UserRoles.Guest)
				{
					project.ProjectUsers.Add(new ProjectUser() { UserRole = ProjectUser.UserRoles.Viewer, User = member.User, Project = project });
				}
			}

			db.Projects.Add(project);
			db.SaveChanges();

			return Json(new { success = true, responseText = project.Id });
		}
	}
}
