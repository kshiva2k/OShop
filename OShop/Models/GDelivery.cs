using System;
using System.Collections.Generic;

namespace OShop.Models
{
    public partial class GDelivery
    {
        public long Id { get; set; }
        public int? Agencyid { get; set; }
        public int? Shopid { get; set; }
        public int? Quantity { get; set; }
        public decimal? Invoiceamount { get; set; }
        public string Paymentmode { get; set; }
        public string Paymentno { get; set; }
        public decimal? Actualpayment { get; set; }
        public int? Deliveredby { get; set; }
        public short? Billcleared { get; set; }
        public int? Active { get; set; }
        public DateTime? Createddate { get; set; }
        public DateTime? Billclearancedate { get; set; }

        public virtual GAgencymaster Agency { get; set; }
        public virtual GShopmaster Shop { get; set; }
    }
}
