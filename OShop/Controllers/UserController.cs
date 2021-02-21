using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OShop.Repository;
using OShop.ViewModels;
using System;
namespace OShop.Controllers
{
    public class UserController : Controller
    {
        public ShopRepository shopRepository;
        public AgencyRepository agencyRepository;
        public UserController(ShopRepository _shopRepository, AgencyRepository _agencyRepository)
        {
            shopRepository = _shopRepository;
            agencyRepository = _agencyRepository;
        }
        [Services.SessionCheck]
        public IActionResult Delivery()
        {
            ViewData["ShopMaster"] = shopRepository.GetShop(Convert.ToInt32(HttpContext.Session.GetInt32("Agencyid")));
            return View();
        }
        [Services.SessionCheck]
        public JsonResult GetShopDetail(string code,int shopname)
        {
            ShopViewModel viewModel = shopRepository.GetShopByCode(code, shopname);
            return Json(viewModel);
        }
        [Services.SessionCheck]
        public JsonResult AddDelivery(DeliveryViewModel viewModel)
        {
            viewModel.Deliveredby = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            agencyRepository.AddDelivery(viewModel);
            return Json(true);
        }
    }
}
