using System;
using System.Collections.Generic;

namespace OShop.Models
{
    public partial class GShopmaster
    {
        public GShopmaster()
        {
            GDelivery = new HashSet<GDelivery>();
        }

        public int Id { get; set; }
        public int? Agencyid { get; set; }
        public int? Shopcategoryid { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Overallbalance { get; set; }
        public short? Active { get; set; }

        public virtual GAgencymaster Agency { get; set; }
        public virtual GShopcategorymaster Shopcategory { get; set; }
        public virtual ICollection<GDelivery> GDelivery { get; set; }
    }
}
