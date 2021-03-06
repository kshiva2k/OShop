﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OShop.ViewModels;
namespace OShop.Repository
{
    public interface ShopRepository
    {
        List<ShopViewModel> GetShops(int agencyId);
        bool AddShop(ShopViewModel viewModel);
        bool UpdateShop(ShopViewModel viewModel);
        bool DeleteteShop(ShopViewModel viewModel);
        bool CheckDuplicateShop(string Code, int Id, int AgencyId);
        ShopViewModel GetShopById(int id);

        List<ShopCategoryViewModel> GetShopCategories(int agencyId);
        bool AddShopCategory(ShopCategoryViewModel viewModel);
        bool UpdateShopCategory(ShopCategoryViewModel viewModel);
        bool DeleteteShopCategory(int Id);
        bool CheckDuplicateShopCategory(string Name, int Id, int AgencyId);
        ShopCategoryViewModel GetShopCategoryById(int id);


        ShopViewModel GetShopByCode(string code, int shopname);

        List<SelectionItem> GetShop(int agencyId);
    }
}
