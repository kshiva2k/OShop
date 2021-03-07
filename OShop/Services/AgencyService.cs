using OShop.Models;
using OShop.Repository;
using OShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OShop.Services
{
    public class AgencyService : AgencyRepository
    {
        oshopContext context { get; }
        public AgencyService(oshopContext _oshopContext)
        {
            context = _oshopContext;
        }
        public List<AgencyViewModel> GetAgencies()
        {
            List<AgencyViewModel> records = new List<AgencyViewModel>();
            var agencies = context.GAgencymaster.Where(u => u.Active == 1).ToList();
            foreach (var item in agencies)
            {
                records.Add(new AgencyViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Email = item.Email,
                    Phoneno = item.Phoneno
                });
            }
            return records;
        }
        public bool AddAgency(AgencyViewModel viewModel)
        {
            context.GAgencymaster.Add(new GAgencymaster()
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Phoneno = viewModel.Phoneno,
                Email = viewModel.Email
            });
            context.SaveChanges();
            return true;
        }
        public bool UpdateAgency(AgencyViewModel viewModel)
        {
            var record = context.GAgencymaster.Where(x => x.Id == viewModel.Id).FirstOrDefault();
            record.Name = viewModel.Name;
            record.Address = viewModel.Address;
            record.Phoneno = viewModel.Phoneno;
            record.Email = viewModel.Email;
            context.SaveChanges();
            return true;
        }
        public bool DeleteAgency(int id)
        {
            var record = context.GAgencymaster.Where(x => x.Id == id).FirstOrDefault();
            record.Active = 0;
            context.SaveChanges();
            return true;
        }
        public bool CheckDuplicateAgency(string name, int Id)
        {
            if(Id == 0)  // Add mode
            {
                var record = context.GAgencymaster.Where(x => x.Name == name && x.Active.Value == 1).FirstOrDefault();
                if (record != null || record.Id > 0)
                    return false;  // Duplicate exists
                else
                    return true;  // No Duplication
            }
            else
            {
                var record = context.GAgencymaster.Where(x => x.Name == name && x.Active.Value == 1 && x.Id != Id).FirstOrDefault();
                if (record != null || record.Id > 0)
                    return false;  // Duplicate exists
                else
                    return true;  // No Duplication
            }
        }
        public AgencyViewModel GetAgency(int id)
        {
            var record = context.GAgencymaster.Where(x => x.Id == id).FirstOrDefault();
            AgencyViewModel viewModel = new AgencyViewModel()
            {
                Id = record.Id,
                Name = record.Name,
                Address = record.Address,
                Phoneno = record.Phoneno,
                Email = record.Email
            };
            return viewModel;
        }

        public bool AddDelivery(DeliveryViewModel viewModel)
        {
            var shop = context.GShopmaster.Where(x => x.Id == viewModel.Shopid.GetValueOrDefault()).FirstOrDefault();
            GDelivery deli = new GDelivery()
            {
                Agencyid = viewModel.Agencyid.GetValueOrDefault(),
                Shopid = viewModel.Shopid.GetValueOrDefault(),
                Quantity = viewModel.Quantity.GetValueOrDefault(),
                Invoiceamount = viewModel.Invoiceamount.GetValueOrDefault(),
                Paymentmode = viewModel.Paymentmode,
                Paymentno = viewModel.Paymentno,
                Actualpayment = viewModel.Actualpayment,
                Deliveredby = viewModel.Deliveredby.GetValueOrDefault(),
                Billcleared = viewModel.Paymentmode == "Cash" ? Convert.ToByte(1) : Convert.ToByte(0),
                Returnquantity = viewModel.ReturnQuantity,
                Overallbalance = (viewModel.Paymentmode == "Cash"
                    && viewModel.Actualpayment.GetValueOrDefault() != viewModel.Invoiceamount.GetValueOrDefault()) ?
                    (shop.Overallbalance - (viewModel.Actualpayment.GetValueOrDefault() - viewModel.Invoiceamount.GetValueOrDefault())) : shop.Overallbalance,
                Createddate = DateTime.Now
            };
            context.GDelivery.Add(deli);
            if (viewModel.Paymentmode.Equals("Cash")
                && viewModel.Actualpayment.GetValueOrDefault() != viewModel.Invoiceamount.GetValueOrDefault())
            {
                shop.Overallbalance = shop.Overallbalance - (viewModel.Actualpayment.GetValueOrDefault() - viewModel.Invoiceamount.GetValueOrDefault());
            }
            context.SaveChanges();
            return true;
        }
        public List<DeliveryViewModel> GetActivities(int agencyId, string shopCode, int shopno)
        {
            var shop = context.GShopmaster.Where(u => u.Code == shopCode).FirstOrDefault();
            List<DeliveryViewModel> records = new List<DeliveryViewModel>();
            //var list = context.GDelivery.Where(u => u.Active == 1 && u.Agencyid == agencyId && u.Shopid == (shop != null ? shop.Id : u.Shopid)
            //        && u.Createddate > fromDate && u.Createddate <= toDate).OrderByDescending(o => o.Id).ToList();
            var list = (from a in context.GDelivery
                        join c in context.GShopmaster on a.Shopid equals c.Id
                        where a.Shopid == shopno || c.Code == shopCode
                        orderby a.Id descending
                        select new { a.Id, a.Agencyid, a.Shopid, c.Name, a.Invoiceamount, a.Paymentmode, a.Paymentno, a.Actualpayment, a.Billcleared, a.Createddate, a.Quantity });
            foreach (var item in list)
            {
                records.Add(new DeliveryViewModel()
                {
                    Id = Convert.ToInt64(item.Id),
                    Agencyid = item.Agencyid.GetValueOrDefault(),
                    Shopid = item.Shopid.GetValueOrDefault(),
                    ShopName = item.Name,
                    Invoiceamount = item.Invoiceamount,
                    Paymentmode = item.Paymentmode,
                    Paymentno = item.Paymentno,
                    Actualpayment = item.Actualpayment,
                    Billcleared = item.Billcleared.GetValueOrDefault(),
                    InvoiceDate = item.Createddate.GetValueOrDefault().ToShortDateString(),
                    Quantity = item.Quantity.GetValueOrDefault()
                });
            }
            return records;
        }
        public bool ClearBill(long id)
        {
            var record = context.GDelivery.Where(x => x.Id == id).FirstOrDefault();
            var shop = context.GShopmaster.Where(x => x.Id == record.Shopid).FirstOrDefault();
            if (record.Actualpayment.GetValueOrDefault() != record.Invoiceamount.GetValueOrDefault())
                shop.Overallbalance = shop.Overallbalance.GetValueOrDefault() - (record.Actualpayment.GetValueOrDefault() - record.Invoiceamount.GetValueOrDefault());
            record.Billcleared = Convert.ToByte(1);
            record.Billclearancedate = DateTime.Now;
            context.SaveChanges();
            return true;
        }
        public AgencyDashboardViewModel GetDashboardData(int id)
        {
            AgencyDashboardViewModel viewModel = new AgencyDashboardViewModel();
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            viewModel.OrdersDelivered = context.GDelivery.Where(x => x.Createddate > today).Count();
            viewModel.AmountsCollected = context.GDelivery.Where(x => x.Createddate > today).Select(x => x.Actualpayment).Sum().GetValueOrDefault();
            viewModel.ClientCount = context.GShopmaster.Where(x => x.Agencyid == id).Count();
            viewModel.OverallBalance = context.GShopmaster.Where(x => x.Agencyid == id).Select(x => x.Overallbalance).Sum().GetValueOrDefault();
            return viewModel;
        }
    }
}
