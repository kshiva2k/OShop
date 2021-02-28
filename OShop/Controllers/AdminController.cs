using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OShop.Repository;
using OShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OShop.Controllers
{
    public class AdminController : Controller
    {
        AgencyRepository agencyRepository;
        ShopRepository shopRepository;
        UserRepository userRepository;
        public AdminController(AgencyRepository _agencyRepository, ShopRepository _shopRepository, UserRepository _userRepository)
        {
             agencyRepository = _agencyRepository;
            shopRepository = _shopRepository;
            userRepository = _userRepository;
        }
        [Authorize]
        public IActionResult ShopList()
        {
            return View();
        }
        [Authorize]
        public IActionResult GetShops(int id)
        {
            List<ShopViewModel> list = new List<ShopViewModel>();
            list = shopRepository.GetShops(id);
            return PartialView("_ShopList", list);
        }
        [Authorize]
        public JsonResult GetShopData()
        {
            List<ShopViewModel> list = new List<ShopViewModel>();
            list = shopRepository.GetShops(HttpContext.Session.GetInt32("AgencyId").GetValueOrDefault());
            return Json(list);
        }
        [Authorize]
        public JsonResult GetAgencies()
        {
            var list = agencyRepository.GetAgencies();
            return Json(new { list = list, role = HttpContext.Session.GetInt32("RoleId"), agency = HttpContext.Session.GetInt32("Agencyid") });

        }

        [Authorize]
        public IActionResult AddShop(int id)
        {
            ShopViewModel viewModel = new ShopViewModel();
            viewModel = shopRepository.GetShopById(id);
            ViewData["ShopCategory"] = shopRepository.GetShopCategories(id);
            return PartialView("_Shopmaster", viewModel);
        }

        [Authorize]
        public IActionResult GetUsers(int id)
        {
            List<UserViewModel> list = new List<UserViewModel>();
            list = userRepository.GetUsers(id);
            return PartialView("_UserList", list);
        }

        [Authorize]
        public IActionResult AddUser()
        {
            int id = Convert.ToInt32(HttpContext.Session.GetInt32("RoleId"));
            UserViewModel viewModel = new UserViewModel();
            ViewData["Role"] = userRepository.GetRoles(id);
            return PartialView("_UserMaster", viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ShopMaster(IFormCollection formCollection)
        {
            ShopViewModel viewModel = new ShopViewModel()
            {
                Name = formCollection["Name"],
                Code = formCollection["Code"],
                Address = formCollection["Address"],
                Agencyid = Convert.ToInt32(formCollection["Agencyid"]),
                Amount = Convert.ToDecimal(formCollection["Amount"]),
                Phone = formCollection["Mobile"],
                Email = formCollection["Email"],
                Shopcategoryid = Convert.ToInt32(formCollection["Shopcategoryid"])
            };
            shopRepository.AddShop(viewModel);
            return RedirectToAction("ShopList", "Admin");
        }
        [Authorize]
        [HttpPost]
        public IActionResult ShopCategoryList(IFormCollection formCollection)
        {
            ShopCategoryViewModel viewModel = new ShopCategoryViewModel()
            {
                Name = formCollection["Name"],

                Agencyid = Convert.ToInt32(formCollection["Agencyid"]),

            };
            shopRepository.AddShopCategory(viewModel);
            return RedirectToAction("ShopCategoryList", "Admin");
        }


        [Authorize]
        public IActionResult ShopCategoryList()
        {
            return View();
        }

        [Authorize]
        public IActionResult GetCategorys(int id)
        {
            List<ShopCategoryViewModel> list = new List<ShopCategoryViewModel>();
            list = shopRepository.GetShopCategories(id);
            return PartialView("_CategoryList", list);
        }
        [Authorize]
        public IActionResult AddCategory(int id)
        {

            ShopCategoryViewModel viewModel = new ShopCategoryViewModel();
            return PartialView("_Categorymaster", viewModel);
        }

        [Authorize]
        public IActionResult UserMaster()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UserMaster(IFormCollection formCollection)
        {
            UserViewModel viewModel = new UserViewModel()
            {
                Loginname = formCollection["Loginname"],
                Mobileno = formCollection["Mobileno"],
                Email = formCollection["Email"],
                Agencyid = Convert.ToInt32(formCollection["Agencyid"]),
                Roleid = Convert.ToInt32(formCollection["Roleid"]),

            };
            userRepository.AddUser(viewModel);
            return RedirectToAction("UserMaster", "Admin");
        }
        [Authorize]
        public IActionResult ActivityScreen()
        {
            return View();
        }
        [Authorize]
        public IActionResult Activity()
        {
            ViewData["ShopMaster"] = shopRepository.GetShop(Convert.ToInt32(HttpContext.Session.GetInt32("Agencyid")));
            return View();
        }

        [Authorize]
        public IActionResult ActivityMaster(int id)
        {
            ViewData["ShopMaster"] = shopRepository.GetShop(id);
            
            return PartialView("_ActivityMaster", "");
        }

        [Authorize]
        public IActionResult GetActivityList(string shopno, string shopcode)
        {
         
            
            var list = agencyRepository.GetActivities(Convert.ToInt32(HttpContext.Session.GetInt32("Agencyid")), shopcode, Convert.ToInt32(shopno));
            return PartialView("_ActivityList", list);
        }
        [Authorize]
        public JsonResult ClearBill(long id)
        {
            bool result = agencyRepository.ClearBill(id);
            return Json(result);
        }
    }
}
