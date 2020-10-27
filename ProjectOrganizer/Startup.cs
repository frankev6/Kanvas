using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectOrganizer.Models;

namespace ProjectOrganizer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;

		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>
				(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


			services.AddIdentity<ApplicationUser, IdentityRole>(config =>
			{
				config.Password.RequiredLength = 7;
				config.Password.RequireDigit = false;
				config.Password.RequireNonAlphanumeric = false;
				config.Password.RequireUppercase = false;
				


			}).AddEntityFrameworkStores<ApplicationDbContext>()
			  .AddDefaultTokenProviders();

			services.ConfigureApplicationCookie(config =>
			{
				config.Cookie.Name = "IdentityServer.LOGIN_INFO";
				config.LoginPath = "/Auth/Login";
				config.LogoutPath = "/Auth/Logout";
				
			});

			var assembly = typeof(Startup).Assembly.GetName().ToString();


			services.AddIdentityServer()
				.AddAspNetIdentity<ApplicationUser>()
				.AddConfigurationStore(options=>
				{
					options.ConfigureDbContext = b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
						sql => sql.MigrationsAssembly(assembly));
				})
				.AddOperationalStore(options =>
				{
					options.ConfigureDbContext = b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
						sql => sql.MigrationsAssembly(assembly));
				}
				)
				//.AddInMemoryIdentityResources(IS4Configuration.GetIdentityResources())
				//.AddInMemoryClients(IS4Configuration.GetClients())
				.AddDeveloperSigningCredential();

			services.AddAuthentication().AddGoogle(config => {

				config.ClientId = "286961498643-b11hr09emksrm6hnaq3nomjddvgiqt9q.apps.googleusercontent.com";
				config.ClientSecret = "ez8fjpHTUS_PQtmyyy6ENNas";

			}).AddMicrosoftAccount(config => {

				config.ClientId = "153d63b1-b281-4d68-90ae-d8f9fc870312";
				config.ClientSecret = "8M2uB1~d_QvWg8C~s4_QEVek6bVi-ejhrv";

			});
			
			services.AddControllersWithViews().AddRazorRuntimeCompilation();
		}
		
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");

				app.UseHsts();
			}
			app.UseRouting();
			app.UseIdentityServer();
			app.UseStaticFiles();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
