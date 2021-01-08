using System;
using System.Collections.Generic;
using System.Linq;
using OShop.Models;
using OShop.ViewModels;
using OShop.Repository;
namespace OShop.Services
{
    public class ShopService : ShopRepository
    {
        public List<ShopViewModel> GetShops(int agencyId)
        {
            using (var context = new oshopContext())
            {
                List<ShopViewModel> records = new List<ShopViewModel>();
                var shops = context.GShopmaster.Where(u => u.Active == 1 && u.Agencyid == agencyId)
                    .ToList();
                foreach (var item in shops)
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
                        Amount = item.Amount.GetValueOrDefault()
                    });
                }
                return records;
            }
        }
        public bool AddShop(ShopViewModel viewModel)
        {
            using (var context = new oshopContext())
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
                    Amount = viewModel.Amount
                });
                context.SaveChanges();
                return true;
            }
        }
        public bool UpdateShop(ShopViewModel viewModel)
        {
            using (var context = new oshopContext())
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
        }
        public bool DeleteteShop(ShopViewModel viewModel)
        {
            using (var context = new oshopContext())
            {
                var record = context.GShopmaster.Where(x => x.Id == viewModel.Id).FirstOrDefault();
                record.Active = 0;
                context.SaveChanges();
                return true;
            }
        }
        public ShopViewModel GetShopById(int id)
        {
            using (var context = new oshopContext())
            {                
                var record = context.GShopmaster.Where(x => x.Id == id).FirstOrDefault();
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
                    Amount = record.Amount
                };
                return viewModel;
            }
        }

        public List<ShopCategoryViewModel> GetShopCategories(int agencyId)
        {
            using (var context = new oshopContext())
            {
                List<ShopCategoryViewModel> records = new List<ShopCategoryViewModel>();
                var shops = context.GShopcategorymaster.Where(u => u.Active == 1 && u.Agencyid == agencyId).ToList();
                foreach(var item in shops)
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
        }
        public bool AddShopCategory(ShopCategoryViewModel viewModel)
        {
            using (var context = new oshopContext())
            {
                context.GShopcategorymaster.Add(new GShopcategorymaster()
                {
                    Name = viewModel.Name                    
                });
                context.SaveChanges();
                return true;
            }
        }
        public bool UpdateShopCategory(ShopCategoryViewModel viewModel)
        {
            using (var context = new oshopContext())
            {
                var record = context.GShopcategorymaster.Where(x => x.Id == viewModel.Id).FirstOrDefault();
                record.Name = viewModel.Name;
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteteShopCategory(int Id)
        {
            using (var context = new oshopContext())
            {
                var record = context.GShopcategorymaster.Where(x => x.Id == Id).FirstOrDefault();
                record.Active = 0;
                context.SaveChanges();
                return true;
            }
        }
        public ShopCategoryViewModel GetShopCategoryById(int id)
        {
            using (var context = new oshopContext())
            {
                var record = context.GShopcategorymaster.Where(x => x.Id == id).FirstOrDefault();
                ShopCategoryViewModel viewModel = new ShopCategoryViewModel()
                {
                    Id = record.Id,
                    Name = record.Name
                };
                return viewModel;
            }
        }
    }
}
