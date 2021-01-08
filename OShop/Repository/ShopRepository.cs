using System;
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
        ShopViewModel GetShopById(int id);

        List<ShopCategoryViewModel> GetShopCategories(int agencyId);
        bool AddShopCategory(ShopCategoryViewModel viewModel);
        bool UpdateShopCategory(ShopCategoryViewModel viewModel);
        bool DeleteteShopCategory(int Id);
        ShopCategoryViewModel GetShopCategoryById(int id);
    }
}
