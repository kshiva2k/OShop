using System;
using System.Collections.Generic;

namespace OShop.Models
{
    public partial class GAgencysubscription
    {
        public int Id { get; set; }
        public int? Agencyid { get; set; }
        public DateTime? Fromdate { get; set; }
        public DateTime? Todate { get; set; }
        public int? Paymenttype { get; set; }
        public decimal? Amount { get; set; }
        public short? Isexpired { get; set; }
        public int? Active { get; set; }

        public virtual GAgencymaster Agency { get; set; }
    }
}
