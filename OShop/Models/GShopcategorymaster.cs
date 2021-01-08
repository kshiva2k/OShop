using System;
using System.Collections.Generic;

namespace OShop.Models
{
    public partial class GShopcategorymaster
    {
        public GShopcategorymaster()
        {
            GShopmaster = new HashSet<GShopmaster>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Agencyid { get; set; }
        public int? Active { get; set; }

        public virtual GAgencymaster Agency { get; set; }
        public virtual ICollection<GShopmaster> GShopmaster { get; set; }
    }
}
