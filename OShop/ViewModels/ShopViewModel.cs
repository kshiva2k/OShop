using System;
namespace OShop.ViewModels
{
    public class ShopViewModel
    {
        public int Id { get; set; }
        public int? Agencyid { get; set; }
        public int? Shopcategoryid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Amount { get; set; }
    }
}
