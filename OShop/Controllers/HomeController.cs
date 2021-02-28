using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OShop.Repository;
using OShop.ViewModels;
namespace OShop.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepository;
        AgencyRepository agencyRepository;
        public HomeController(UserRepository _userRepository, AgencyRepository _agencyRepository)
        {
            userRepository = _userRepository;
            agencyRepository = _agencyRepository;
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
                HttpContext.Session.SetInt32("RoleId", result.Roleid);
                HttpContext.Session.SetString("Username", result.Loginname);
                HttpContext.Session.SetInt32("Agencyid", result.Agencyid);
                if (result.Roleid != 3) // Admin role
                {
                    actionName = "Dashboard";
                    controllerName = "Home";
                }
                else
                {

                    actionName = "Delivery";
                    controllerName = "User";

                }
                return RedirectToAction(actionName, controllerName);
            }
            else
            {
                loginViewModel.Password = "";
                // Invalid user
                ViewBag.Error = "Invalid credentials !";
                return View(loginViewModel);
            }
        }
        [Services.SessionCheck]
        public IActionResult Dashboard()
        {
            var data = agencyRepository.GetDashboardData(HttpContext.Session.GetInt32("Agencyid").GetValueOrDefault());
            return View(data);
        }
        [Services.SessionCheck]
        public IActionResult DeliveryScreen()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

    }
}
