using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectOrganizer.Models;
using ProjectOrganizer.Models.ViewModels;
using ProjectOrganizer.Models.WorkspaceModels;

namespace ProjectOrganizer.Controllers
{
	[Authorize]
	public class BoardController : Controller
	{
		private readonly ApplicationDbContext db;
		private UserManager<ApplicationUser> userManager;
		public Project project { get; set; }

		public BoardController(ApplicationDbContext _db, UserManager<ApplicationUser> _userManager)
		{
			db = _db;
			userManager = _userManager;
		}

		public async Task<IActionResult> Index(string id)// open project
		{

			var user = await userManager.GetUserAsync(this.User);
			ProjectUser projectUser = db.ProjectUser.FirstOrDefault(p => p.UserId == user.Id && p.ProjectId == id);

			if (projectUser == null)
			{
				return RedirectToAction("Error","Board");
			}

			project = db.Projects.Include(p => p.ProjectUsers).ThenInclude(pu => pu.User).Include(l => l.Labels).Include(c => c.CardGroups).ThenInclude(c => c.Cards).ThenInclude(l => l.LabelCards).FirstOrDefault(u => u.Id == id); //ThenInclude(c=>c.CardModules)

			if (project == null)
			{
				return RedirectToAction("Error", "Board");
			}

			if (project.CardGroups == null || project.CardGroups.Count == 0)
			{

				project.CardGroups = new List<CardGroup>();
				project.CardGroups.Add(new CardGroup()
				{
					Name = "Resources",
					Cards = new List<Card>(),
					Position = 0

				});

				project.CardGroups.Add(new CardGroup()
				{
					Name = "To Do",
					Cards = new List<Card>(),
					Position = 1
				});

				project.CardGroups.Add(new CardGroup()
				{
					Name = "In progress",
					Cards = new List<Card>(),
					Position = 2
				});

				project.CardGroups.Add(new CardGroup()
				{
					Name = "Done",
					Cards = new List<Card>(),
					Position = 3
				});

				db.SaveChanges();
			}
			return View(new BoardViewModel() { ProjectUser = projectUser, Project = project });
		}

		[HttpPost]
		public IActionResult CreateCardGroup(string projectId, string name)
		{
			if (db.Projects.Any(p => p.Id == projectId))
			{

				project = db.Projects.Include(c => c.CardGroups).FirstOrDefault(p => p.Id == projectId);
				project.CardGroups.Add(new CardGroup()
				{
					Name = name,
					Cards = new List<Card>(),
					Position = project.CardGroups.Count
				});

				db.SaveChanges();
			}
			return Json(new { data = project.CardGroups.Last().Id });
		}

		[HttpPost]
		public IActionResult CreateCard(string groupId, string name)
		{
			CardGroup cardGroup = db.CardGroups.Include(c => c.Cards).FirstOrDefault(c => c.Id == groupId);

				Card newCard = new Card()
				{
					Name = name,
					Position = cardGroup.Cards.Count,
					LabelCards = new List<LabelCard>()

				};

				cardGroup.Cards.Add(newCard);

				db.SaveChanges();
			return Json(new { data = cardGroup.Cards.Last().Id });
		}

		[HttpPost]
		public IActionResult MoveCard(string groupId, string newGroupId, string cardId, string siblingId)
		{
				Card cardToMove = db.Cards.FirstOrDefault(c => c.Id == cardId);

				/*foreach (Card card in db.CardGroups.FirstOrDefault(c => c.Id == groupId).Cards)
				{
					if (card.Position > cardToMove.Position)
					{
						card.Position--;
					}
				}*/

			   CardGroup newCardGroup = db.CardGroups.Include(c => c.Cards).FirstOrDefault(c => c.Id == newGroupId);

				if (siblingId == null)//end of list
				{
					cardToMove.Position = newCardGroup.Cards.Count;
				}
				else
				{// insterted somewhere in the list

					cardToMove.Position = newCardGroup.Cards.FirstOrDefault(c => c.Id == siblingId).Position;

					foreach (Card card in newCardGroup.Cards)
					{
						if (card.Position >= cardToMove.Position && card.Id != cardId)
						{
							card.Position++;
						}
					}
				}
			    newCardGroup.Cards.Add(cardToMove);

				db.SaveChanges();

			return NoContent();
		}

		[HttpPost]
		public IActionResult MoveGroup(string groupId, string siblingId)
		{
				CardGroup cardGToMove = db.CardGroups.Include(c => c.Project).ThenInclude(p => p.CardGroups).FirstOrDefault(c => c.Id == groupId);
			project = cardGToMove.Project;
				foreach (CardGroup cardG in project.CardGroups)
				{
					if (cardG.Position > cardGToMove.Position)
					{
						cardG.Position--;
					}
				}

				if (siblingId == null)//end of list
				{
					cardGToMove.Position = project.CardGroups.Count;
				}
				else
				{// insterted somewhere in the list

					cardGToMove.Position = project.CardGroups.FirstOrDefault(c => c.Id == siblingId).Position;

					foreach (CardGroup cardG in project.CardGroups)
					{
						if (cardG.Position >= cardGToMove.Position && cardG.Id != cardGToMove.Id)
						{
							cardG.Position++;
						}
					}
				}

				db.SaveChanges();

			return NoContent();
		}

		public IActionResult AddCardModule()
		{


			return NoContent();
		}

		[HttpPost]
		public IActionResult ChangeColors(string projectId, string bgcolor, bool isUrl)
		{

			if (db.Projects.Any(p => p.Id == projectId))
			{
				project = db.Projects.FirstOrDefault(p => p.Id == projectId);

				project.BackgroundC = bgcolor;

				db.SaveChanges();

			}
			return NoContent();
		}

		public IActionResult GetProjectLabels(string projectId)
		{

			if (db.Projects.Any(p => p.Id == projectId))
			{

				List<LabelModule> labels = db.Projects.Include(l => l.Labels).FirstOrDefault(p => p.Id == projectId).Labels.ToList();

				string jsonString = JsonConvert.SerializeObject(labels);
				return Json(new { success = true, responseText = jsonString });

			}
			return NotFound();
		}

		[HttpPost]
		public IActionResult ChangeGroupName(string groupId, string name)
		{
				if (!string.IsNullOrEmpty(name))
				{
					db.CardGroups.FirstOrDefault(p => p.Id == groupId).Name = name;
					db.SaveChanges();
				}

			return NoContent();
		}

		[HttpPost]
		public IActionResult ChangeCardName(string cardId, string name)
		{
				if (!string.IsNullOrEmpty(name))
				{
					db.Cards.FirstOrDefault(c => c.Id == cardId).Name = name;
					db.SaveChanges();
				}

			return NoContent();
		}
		[HttpPost]
		public IActionResult ChangeCardColor(string cardId, string color)
		{
				if (!string.IsNullOrEmpty(color))
				{
					db.Cards.FirstOrDefault(c => c.Id == cardId).Color = color;
					db.SaveChanges();
				}

			return NoContent();
		}

		[HttpPost]
		public IActionResult ChangeGroupCardColor(string groupId, string color)
		{
				if (!string.IsNullOrEmpty(color))
				{
					db.CardGroups.FirstOrDefault(c => c.Id == groupId).Color = color;
					db.SaveChanges();
				}

			return NoContent();
		}

		[HttpPost]
		public IActionResult DeleteCard(string cardId)
		{
				Card cardToDelete = db.Cards.Include(c => c.LabelCards).Include(c => c.CardGroup).ThenInclude(c => c.Cards).FirstOrDefault(c => c.Id == cardId);

				/*foreach (Card card in cardToDelete.CardGroup.Cards)
				{
					if (card.Position > cardToDelete.Position)
					{
						card.Position--;
					}
				}*/
				cardToDelete.LabelCards.Clear();

				db.Cards.Remove(cardToDelete);
				db.SaveChanges();

			return NoContent();
		}

		[HttpPost]
		public IActionResult DeleteGroup(string groupId)
		{

				var cardGroup = db.CardGroups.Include(c => c.Cards).ThenInclude(lb => lb.LabelCards).FirstOrDefault(c => c.Id == groupId);

			foreach (var card in cardGroup.Cards)
			{ card.LabelCards.Clear(); }

				db.CardGroups.Remove(cardGroup);

				db.SaveChanges();
			return NoContent();
		}
		[HttpPost]
		public IActionResult DeleteLabel(string labelId)
		{
			var label = db.LabelModules.Include(l => l.LabelCards).FirstOrDefault(c => c.Id == labelId);

				foreach (var labelcard in label.LabelCards) { db.LabelCards.Remove(labelcard); }

				db.LabelModules.Remove(label);

				db.SaveChanges();

			return NoContent();
		}

		[HttpPost]
		public IActionResult MakeLabel(string projectId, string name, string color)
		{

			LabelModule newLabel = new LabelModule() { Name = name, Color = color };

			project = db.Projects.Include(p => p.Labels).FirstOrDefault(p => p.Id == projectId);
			if (project.Labels == null)
			{
				project.Labels = new List<LabelModule>();
			}
			project.Labels.Add(newLabel);

			db.SaveChanges();
			string jsonString = JsonConvert.SerializeObject(newLabel);

			return Json(new { success = true, responseText = jsonString });
		}

		[HttpPost]
		public IActionResult AddRemoveLabelToCard(string cardId, string labelId)
		{
			Card card = db.Cards.Include(c => c.LabelCards).FirstOrDefault(c => c.Id == cardId);

			if (card.LabelCards.Any(l => l.LabelId == labelId))
			{
				db.LabelCards.Remove(card.LabelCards.FirstOrDefault(lb => lb.LabelId == labelId));
				db.SaveChanges();
			}
			else
			{
				LabelCard labelCard = new LabelCard();
				labelCard.Card = card;
				labelCard.Label = db.LabelModules.FirstOrDefault(l => l.Id == labelId);

				db.LabelCards.Add(labelCard);
				db.SaveChanges();

				string jsonString = JsonConvert.SerializeObject(labelCard.Label);
				return Json(new { success = true, responseText = jsonString });
			}
			return NoContent();
		}
		[HttpPost]
		public IActionResult ChangeLabelColor(string labelId, string color)
		{
			db.LabelModules.FirstOrDefault(l => l.Id == labelId).Color = color;
			db.SaveChanges();
			return NoContent();
		}
		
		[HttpPost]
		public IActionResult ChangeLabelName(string labelId, string name)
		{
			db.LabelModules.FirstOrDefault(l => l.Id == labelId).Name = name;
			db.SaveChanges();
			return NoContent();
		}
		[HttpPost]
		public IActionResult ChangeProjectName(string projectId, string name)
		{
			db.Projects.FirstOrDefault(l => l.Id == projectId).Name = name;
			db.SaveChanges();
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> ChangeProjectAccessibilty(string projectId,string userId, int userRole, bool removeUser, bool isPublic) {
			var user = await userManager.GetUserAsync(this.User);
			
			project = db.Projects.Include(p => p.ProjectUsers).ThenInclude(pu => pu.User).FirstOrDefault(p => p.Id == projectId);
			var member = project.ProjectUsers.FirstOrDefault(p => p.User.Id == user.Id);// user making the change

			if (userRole == 2 || member == null || member.UserRole == ProjectUser.UserRoles.Viewer)// no access
			{
				return Json(new { success = false});
			}

			if (project.isPublic != isPublic && member.UserRole == ProjectUser.UserRoles.Owner)//make project public
			{
				project.isPublic = isPublic;
				db.SaveChanges();
				return Json(new { success = true });
			}

			if (userId != null && (member.UserRole == ProjectUser.UserRoles.Owner || member.UserRole == ProjectUser.UserRoles.Editor))
			{
			var selectedPU = project.ProjectUsers.FirstOrDefault(p => p.User.Id == userId);//project-user to change
			
				if (selectedPU != null && removeUser == true)
				{
					project.ProjectUsers.Remove(selectedPU);

				}else {
					if (selectedPU == null)//add user
					{
						var userToAdd = await userManager.FindByNameAsync(userId);
						project.ProjectUsers.Add(new ProjectUser() { Project = project, User = userToAdd, UserRole = (ProjectUser.UserRoles)userRole });
						db.SaveChanges();
						string jsonString = JsonConvert.SerializeObject(new UserViewModel() {Username = userToAdd.UserName, Id = userToAdd.Id });
						return Json(new { success = true, responseText = jsonString });
					}
					else //change role
					{
						selectedPU.UserRole = (ProjectUser.UserRoles)userRole;
					}

				}
				db.SaveChanges();
				return Json(new { success = true });
			}


			return Json(new { success = false });
		}


		[HttpPost]
		public async Task<IActionResult> DeleteProject(string projectId) {

			var user = await userManager.GetUserAsync(this.User);
			var projectUser = db.ProjectUser.FirstOrDefault(p => p.ProjectId == projectId && p.UserId == user.Id);
			if (projectUser.UserRole == ProjectUser.UserRoles.Owner)
			{
				project = db.Projects.Include(p => p.ProjectUsers).Include(p => p.CardGroups).ThenInclude(c => c.Cards).ThenInclude(c => c.LabelCards).FirstOrDefault(p => p.Id == projectId);

				foreach (var item in project.ProjectUsers)
				{
					db.ProjectUser.Remove(item);
				}
				foreach (var cg in project.CardGroups)
				{
					foreach (var c in cg.Cards)
					{
						c.LabelCards = null;
						c.LabelCards = null;
					}
					cg.Cards = null;
					
				}
				project.Labels = null;


			db.Projects.Remove(project);
			db.SaveChanges();
			
			}
			return NoContent();
		
		}
		


		[HttpPost]
		public async Task<IActionResult> CreateAttachment(string projectId, string cardId, string aUrl, string aName, string aFileId, string aType, string aEmbedUrl) {
			var user = await userManager.GetUserAsync(this.User);
			var projectUser = db.ProjectUser.FirstOrDefault(p => p.ProjectId == projectId && p.UserId == user.Id);

			if (projectUser.UserRole == ProjectUser.UserRoles.Viewer)
			{
				return NoContent();
			}

			Card card = db.Cards.Include(c => c.AttachmentModules).FirstOrDefault(c => c.Id == cardId);

			AttachmentModule aModule = new AttachmentModule() {
				FileId = aFileId, 
				Name = aName, 
				DocumentType = aType,
				Url = aUrl,
				EmbedUrl = aEmbedUrl,
				Position = card.AttachmentModules.Count 
			};

			card.AttachmentModules.Add(aModule);

			db.SaveChanges();
			string jsonString = JsonConvert.SerializeObject(aModule);
			return Json(new { success = true, responseText = jsonString });
		}

		[HttpPost]
		public async Task<IActionResult> MoveAttachment(string projectId, string cardId, string aId, string otherAId) {
			var user = await userManager.GetUserAsync(this.User);
			var projectUser = db.ProjectUser.FirstOrDefault(p => p.ProjectId == projectId && p.UserId == user.Id);

			if (projectUser.UserRole == ProjectUser.UserRoles.Viewer)
			{
				return NoContent();
			}

			Card card = db.Cards.Include(c => c.AttachmentModules).FirstOrDefault(c => c.Id == cardId);

			AttachmentModule aModule = card.AttachmentModules.FirstOrDefault(a => a.Id == aId);
		
			if (otherAId == null)//end of list
			{
				aModule.Position = project.CardGroups.Count;
			}
			else
			{// insterted somewhere in the list

				aModule.Position = card.AttachmentModules.FirstOrDefault(c => c.Id == otherAId).Position;

				foreach (var am in card.AttachmentModules)
				{
					if (am.Position >= aModule.Position && am.Id != aModule.Id)
					{
						am.Position++;
					}
				}
			}

			db.SaveChanges();
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> DeleteAttachment(string projectId, string aId) {
			var user = await userManager.GetUserAsync(this.User);
			var projectUser = db.ProjectUser.FirstOrDefault(p => p.ProjectId == projectId && p.UserId == user.Id);

			if (projectUser.UserRole == ProjectUser.UserRoles.Viewer)
			{
				return NoContent();
			}

			AttachmentModule aModule = db.AttachmentModules.FirstOrDefault(a => a.Id == aId);
			db.AttachmentModules.Remove(aModule);
			

			db.SaveChanges();
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> GetCardAttachments(string projectId, string cardId)
		{
			var user = await userManager.GetUserAsync(this.User);
			var projectUser = db.ProjectUser.FirstOrDefault(p => p.ProjectId == projectId && p.UserId == user.Id);
			if (projectUser == null)
			{
				return NoContent();
			}

			Card card = db.Cards.Include(c => c.AttachmentModules).FirstOrDefault(c => c.Id == cardId);

			List<AttachmentModule> alist = card.AttachmentModules.OrderBy(a => a.Position).ToList();

			string jsonString = JsonConvert.SerializeObject(alist);
			return Json(new { success = true, responseText = jsonString });
		}



		public IActionResult Error() {

			return View();
		}
	}
}
