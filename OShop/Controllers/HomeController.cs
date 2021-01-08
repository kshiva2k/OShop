using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using OShop.Repository;
using OShop.ViewModels;
namespace OShop.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepository;
        public HomeController(UserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public IActionResult Index()
        {
            LoginViewModel viewModel = new LoginViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Index(IFormCollection formCollection)
        {
            string actionName = string.Empty, controllerName = string.Empty;
            LoginViewModel loginViewModel = new LoginViewModel()
            {
                Username = formCollection["Username"],
                Password = formCollection["Password"]
            };
            UserViewModel result = userRepository.ValidateUser(formCollection["Username"], formCollection["Password"]);
            if (result != null && result.Id > 0)
            {
                // Valid user
                HttpContext.Session.SetInt32("UserId", result.Id);
                HttpContext.Session.SetString("Username", result.Loginname);
                if (result.Roleid == 1) // Admin role
                {
                    actionName = "ShopList";
                    controllerName = "Admin";
                }
                return RedirectToAction(actionName, controllerName);
            }
            else
            {
                loginViewModel.Password = "";
                // Invalid user
                ViewData["Error"] = "Invalid credentials !";
                return View(loginViewModel);
            }
        }
    }
}
