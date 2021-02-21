using System;
namespace OShop.ViewModels
{
    public class DeliveryViewModel
    {
        public long Id { get; set; }
        public int? Agencyid { get; set; }
        public int? Shopid { get; set; }
        public string ShopName { get; set; }
        public int? Quantity { get; set; }
        public decimal? Invoiceamount { get; set; }
        public string Paymentmode { get; set; }
        public string Paymentno { get; set; }
        public decimal? Actualpayment { get; set; }
        public int? Deliveredby { get; set; }
        public short? Billcleared { get; set; }
        public string InvoiceDate { get; set; }
        public int ReturnQuantity { get; set; }
    }
}
