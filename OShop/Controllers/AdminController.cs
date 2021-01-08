using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OShop.Repository;
using OShop.ViewModels;
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
        public IActionResult ShopList()
        {
            return View();
        }
    }
}
