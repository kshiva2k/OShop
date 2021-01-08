using System;
using System.Collections.Generic;

namespace OShop.Models
{
    public partial class GAgencymaster
    {
        public GAgencymaster()
        {
            GAgencysubscription = new HashSet<GAgencysubscription>();
            GDelivery = new HashSet<GDelivery>();
            GShopcategorymaster = new HashSet<GShopcategorymaster>();
            GShopmaster = new HashSet<GShopmaster>();
            GUsermaster = new HashSet<GUsermaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phoneno { get; set; }
        public string Email { get; set; }
        public int? Active { get; set; }

        public virtual ICollection<GAgencysubscription> GAgencysubscription { get; set; }
        public virtual ICollection<GDelivery> GDelivery { get; set; }
        public virtual ICollection<GShopcategorymaster> GShopcategorymaster { get; set; }
        public virtual ICollection<GShopmaster> GShopmaster { get; set; }
        public virtual ICollection<GUsermaster> GUsermaster { get; set; }
    }
}
