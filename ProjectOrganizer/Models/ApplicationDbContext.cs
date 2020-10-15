using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectOrganizer.Models.WorkspaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOrganizer.Models
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Project> Projects { get; set; }
		public DbSet<CardGroup> CardGroups { get; set; }
		public DbSet<Card> Cards { get; set; }
		public DbSet<LabelModule> LabelModules { get; set; }
		public DbSet<CommentModule> CommentModules { get; set; }
		public DbSet<AttachmentModule> AttachmentModules { get; set; }
		public DbSet<LabelCard> LabelCards { get; set; }
		public DbSet<ProjectUser> ProjectUser { get; set; }
		public DbSet<Team> Team { get; set; }
		public DbSet<TeamUser> TeamUser { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);


			modelBuilder.Entity<Team>()
				.HasMany(c => c.TeamProjects)         //Team-project relationship one to many
				.WithOne(e => e.Team)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<TeamUser>()
				.HasKey(c => new { c.UserId, c.TeamId });//Team-User relationship many to many

			modelBuilder.Entity<TeamUser>()
				.HasOne(p => p.Team)
				.WithMany(pu => pu.TeamMembers)
				.HasForeignKey(c => c.TeamId).OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<TeamUser>()
				.HasOne(u => u.User)
				.WithMany(pu => pu.TeamMembers)
				.HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);




			modelBuilder.Entity<ProjectUser>()
				.HasKey(c => new { c.ProjectId, c.UserId });//Project-User relationship many to many

			modelBuilder.Entity<ProjectUser>()
				.HasOne(p => p.Project)
				.WithMany(pu => pu.ProjectUsers)
				.HasForeignKey(c => c.ProjectId).OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<ProjectUser>()
				.HasOne(u => u.User)
				.WithMany(pu => pu.ProjectUsers)
				.HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.NoAction);





			modelBuilder.Entity<Project>()
				.HasMany(c => c.CardGroups)			//CardGroup-project relationship one to many
				.WithOne(e => e.Project)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Project>()
				.HasMany(c => c.Labels)         //CardGroup-project relationship one to many
				.WithOne(e => e.Project)
				.IsRequired(true)
				.OnDelete(DeleteBehavior.Cascade);



			modelBuilder.Entity<LabelCard>()
				.HasKey(c => new { c.CardId, c.LabelId }); //label- card

			modelBuilder.Entity<LabelCard>()
				.HasOne(c => c.Card)
				.WithMany(lc => lc.LabelCards)
				.HasForeignKey(c => c.CardId).OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<LabelCard>()
				.HasOne(c => c.Label)
				.WithMany(lc => lc.LabelCards)
				.HasForeignKey(c => c.LabelId).OnDelete(DeleteBehavior.NoAction); ;


			modelBuilder.Entity<CardGroup>()
				.HasMany(c => c.Cards)         //Card-cardgroup relationship one to many
				.WithOne(e => e.CardGroup)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Card>()
				.HasMany(c => c.CommentModules)         //Card-cardModule relationship one to many
				.WithOne(e => e.Card)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Card>()
				.HasMany(c => c.AttachmentModules)         //Card-cardModule relationship one to many
				.WithOne(e => e.Card)
				.IsRequired()
				.OnDelete(DeleteBehavior.Cascade);
		}		
	}
}
