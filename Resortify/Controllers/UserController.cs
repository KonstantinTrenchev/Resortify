﻿using Resortify.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resortify.Data.Models;
using Resortify.Services;
using Resortify.Repositories;

namespace Resortify.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ResortifyUser> userManager;

        private readonly SignInManager<ResortifyUser> signInManager;
        private readonly IUserRepository userRepository;

        public UserController(
            UserManager<ResortifyUser> _userManager,
            SignInManager<ResortifyUser> _signInManager,
            IUserRepository _userRepository)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            userRepository = _userRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {            
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ResortifyUser()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = $"{model.FirstName} {model.LastName}",
                UserName = model.UserName
            };


            var madeUser =  await userRepository.MakeUserAsync(user, model.Password);

            if (madeUser == true)
            {
                var madeAdmin = await userRepository.MakeAdminAsync(user);
                if (madeAdmin)
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Login", "User");
            }

            

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

       
    }
}
