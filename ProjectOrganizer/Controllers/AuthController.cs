using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectOrganizer.Models;
using ProjectOrganizer.Models.ViewModels;

namespace ProjectOrganizer.Controllers
{
	public class AuthController : Controller
	{
		private SignInManager<ApplicationUser> _signInManager;
		private UserManager<ApplicationUser> _userManager;

		public AuthController(SignInManager<ApplicationUser> signInManager,
			UserManager<ApplicationUser> userManager) {
			
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Login(string returnUrl)
		{
			return View(new LoginViewModel { ReturnUrl = returnUrl});
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel vm) {

			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			

			var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);

			if (result.Succeeded) {
				return Redirect(vm.ReturnUrl != null ? vm.ReturnUrl : "localhost:44343/Dashboard");
			}

			return View(vm);
		}

		[HttpGet]
		public IActionResult Register(string returnUrl)
		{
			if (string.IsNullOrEmpty(returnUrl))
			{
				returnUrl = "localhost:44343/Dashboard";
			}
			return View(new RegisterViewModel { ReturnUrl = returnUrl });
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel vm)
		{
			if (!ModelState.IsValid) {
				return View(vm);
			}

			var user = new ApplicationUser() { UserName = vm.Username, Email = vm.Email };
			var result = await _userManager.CreateAsync(user, vm.Password);

			if (result.Succeeded)
			{
				await _signInManager.SignInAsync(user, true);

				return Redirect(vm.ReturnUrl != null ? vm.ReturnUrl : "localhost:44343/Dashboard");
			}

			return View();
		}


		public async Task<IActionResult> ExternalLogin(string provider, string returnUrl) { 
		
			var redirectUri = Url.Action(nameof(ExternalLoginCallback), "Auth", new {returnUrl });
			var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUri);

			return Challenge(properties, provider);
		}

		public async Task<IActionResult> ExternalLoginCallback(string returnUrl) {

			var info = await _signInManager.GetExternalLoginInfoAsync();
			if (info == null)
			{//nothing happened
				return RedirectToAction("Login");
			}
			var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,info.ProviderKey,true);

			if (result.Succeeded)//user is registered
			{
				return Redirect(returnUrl);
			}

			var username = info.Principal.FindFirst(ClaimTypes.Name).Value.Replace(" ", "_");
			string email = info.Principal.FindFirst(ClaimTypes.Email).Value;
			return View("ExternalRegister", new ExternalRegisterViewModel {Username = username, ReturnUrl = returnUrl, Email = email });
		}

		public async Task<IActionResult> ExternalRegister(ExternalRegisterViewModel vm) {

			var info = await _signInManager.GetExternalLoginInfoAsync();
			if (info == null)
			{//nothing happened
				return RedirectToAction("Login");
			}


			var user = new ApplicationUser() { UserName = vm.Username, Email = vm.Email };

			var result = await _userManager.CreateAsync(user);

			if (!result.Succeeded)//user is registered
			{
				return View(vm);
			}

			result = await _userManager.AddLoginAsync(user, info);

			if (!result.Succeeded)//user is registered
			{
				return View(vm);
			}

			await _signInManager.SignInAsync(user,true);


			return Redirect(vm.ReturnUrl != null ? vm.ReturnUrl : "localhost:44343/Dashboard");
		}

	}
}
