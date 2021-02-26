using OShop.Models;
using OShop.Repository;
using OShop.ViewModels;
using System.Collections.Generic;
using System.Linq;
namespace OShop.Services
{
    public class ShopService : ShopRepository
    {
        oshopContext context { get; }
        public ShopService(oshopContext _context)
        {
            context = _context;
        }
        public List<ShopViewModel> GetShops(int agencyId)
        {
            List<ShopViewModel> records = new List<ShopViewModel>();
            var shops = context.GShopmaster.Where(u => u.Active == 1 && u.Agencyid == agencyId)
                .ToList();
            var shop1 = from a in context.GShopmaster
                        join b in context.GShopcategorymaster on a.Shopcategoryid equals b.Id
                        where a.Active == 1 && a.Agencyid == agencyId
                        select new
                        {
                            Id = a.Id,
                            Name = a.Name,
                            Code = a.Code,
                            Agencyid = a.Agencyid,
                            Address = a.Address,
                            Email = a.Email,
                            Phone = a.Phone,
                            ShopCategory = b.Name,
                            Amount = a.Amount,
                            Shopcategoryid = a.Shopcategoryid,
                            Overallbalance = a.Overallbalance
                        };


            foreach (var item in shop1)
            {
                records.Add(new ShopViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Code = item.Code,
                    Agencyid = item.Agencyid.GetValueOrDefault(),
                    Address = item.Address,
                    Email = item.Email,
                    Phone = item.Phone,
                    Shopcategoryid = item.Shopcategoryid.GetValueOrDefault(),
                    Amount = item.Amount.GetValueOrDefault(),
                    Shopcategory = item.ShopCategory,
                    OverallAmount = item.Overallbalance.GetValueOrDefault()
                });
            }
            return records;
        }
        public bool AddShop(ShopViewModel viewModel)
        {
            context.GShopmaster.Add(new GShopmaster()
            {
                Name = viewModel.Name,
                Address = viewModel.Address,
                Code = viewModel.Code,
                Email = viewModel.Email,
                Agencyid = viewModel.Agencyid,
                Shopcategoryid = viewModel.Shopcategoryid,
                Phone = viewModel.Phone,
                Amount = viewModel.Amount,
                Overallbalance = 0
            });
            context.SaveChanges();
            return true;
        }
        public bool UpdateShop(ShopViewModel viewModel)
        {
            var record = context.GShopmaster.Where(x => x.Id == viewModel.Id).FirstOrDefault();
            record.Name = viewModel.Name;
            record.Address = viewModel.Address;
            record.Code = viewModel.Code;
            record.Email = viewModel.Email;
            record.Agencyid = viewModel.Agencyid;
            record.Shopcategoryid = viewModel.Shopcategoryid;
            record.Phone = viewModel.Phone;
            record.Amount = viewModel.Amount;
            context.SaveChanges();
            return true;
        }
        public bool DeleteteShop(ShopViewModel viewModel)
        {
            var record = context.GShopmaster.Where(x => x.Id == viewModel.Id).FirstOrDefault();
            record.Active = 0;
            context.SaveChanges();
            return true;
        }
        public bool CheckDuplicateShop(string name, int Id, int AgencyId)
        {
            if (Id == 0)  // Add mode
            {
                var record = context.GShopmaster.Where(x => x.Name == name && x.Agencyid.Value == AgencyId && x.Active.Value == 1).FirstOrDefault();
                if (record != null || record.Id > 0)
                    return false;
                else
                    return true;
            }
            else
            {
                var record = context.GShopmaster.Where(x => x.Name == name && x.Agencyid.Value == AgencyId && x.Active.Value == 1 && x.Id != Id).FirstOrDefault();
                if (record != null || record.Id > 0)
                    return false;
                else
                    return true;
            }
        }
        public ShopViewModel GetShopById(int id)
        {
            var record = context.GShopmaster.Where(x => x.Id == id).FirstOrDefault();
            ShopViewModel viewModel = new ShopViewModel();
            if (record != null)
            {
                viewModel = new ShopViewModel()
                {
                    Id = record.Id,
                    Name = record.Name,
                    Code = record.Code,
                    Address = record.Address,
                    Agencyid = record.Agencyid,
                    Email = record.Email,
                    Shopcategoryid = record.Shopcategoryid,
                    Phone = record.Phone,
                    Amount = record.Amount
                };
            }

            return viewModel;
        }


        public List<ShopCategoryViewModel> GetShopCategories(int agencyId)
        {
            List<ShopCategoryViewModel> records = new List<ShopCategoryViewModel>();
            var shops = context.GShopcategorymaster.Where(u => u.Active == 1 && u.Agencyid == agencyId).ToList();
            foreach (var item in shops)
            {
                records.Add(new ShopCategoryViewModel()
                {
                    Id = item.Id,
                    Agencyid = item.Agencyid.GetValueOrDefault(),
                    Name = item.Name
                });
            }
            return records;
        }
        public bool AddShopCategory(ShopCategoryViewModel viewModel)
        {
            context.GShopcategorymaster.Add(new GShopcategorymaster()
            {
                Name = viewModel.Name
            });
            context.SaveChanges();
            return true;
        }
        public bool UpdateShopCategory(ShopCategoryViewModel viewModel)
        {
            var record = context.GShopcategorymaster.Where(x => x.Id == viewModel.Id).FirstOrDefault();
            record.Name = viewModel.Name;
            context.SaveChanges();
            return true;
        }
        public bool DeleteteShopCategory(int Id)
        {
            var record = context.GShopcategorymaster.Where(x => x.Id == Id).FirstOrDefault();
            record.Active = 0;
            context.SaveChanges();
            return true;
        }
        public bool CheckDuplicateShopCategory(string name, int Id)
        {
            if (Id == 0)  // Add mode
            {
                var record = context.GShopcategorymaster.Where(x => x.Name == name && x.Active.Value == 1).FirstOrDefault();
                if (record != null || record.Id > 0)
                    return false;
                else
                    return true;
            }
            else
            {
                var record = context.GShopcategorymaster.Where(x => x.Name == name && x.Active.Value == 1 && x.Id != Id).FirstOrDefault();
                if (record != null || record.Id > 0)
                    return false;
                else
                    return true;
            }
        }
        public ShopCategoryViewModel GetShopCategoryById(int id)
        {
            var record = context.GShopcategorymaster.Where(x => x.Id == id).FirstOrDefault();
            ShopCategoryViewModel viewModel = new ShopCategoryViewModel()
            {
                Id = record.Id,
                Name = record.Name
            };
            return viewModel;
        }

        public ShopViewModel GetShopByCode(string code, int shopname)
        {
            var record = context.GShopmaster.Where(x => x.Code == code && x.Active == 1 || (x.Id == shopname)).FirstOrDefault();
            ShopViewModel viewModel = new ShopViewModel()
            {
                Id = record.Id,
                Name = record.Name,
                Code = record.Code,
                Address = record.Address,
                Agencyid = record.Agencyid,
                Email = record.Email,
                Shopcategoryid = record.Shopcategoryid,
                Phone = record.Phone,
                Amount = record.Amount,
                OverallAmount = record.Overallbalance.GetValueOrDefault()
            };
            return viewModel;
        }

        public List<SelectionItem> GetShop(int agencyId)
        {
            List<SelectionItem> records = new List<SelectionItem>();
            var shops = context.GShopmaster.Where(u => u.Active == 1 && u.Agencyid == agencyId).ToList();
            foreach (var item in shops)
            {
                records.Add(new SelectionItem()
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return records;
        }
    }
}
