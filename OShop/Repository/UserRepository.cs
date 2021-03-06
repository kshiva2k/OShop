using System;
using System.Collections.Generic;
using System.Linq;
using OShop.ViewModels;

namespace OShop.Repository
{
    public interface UserRepository
    {
        List<UserViewModel> GetUsers(int id);
        UserViewModel ValidateUser(string _loginname, string _password);
        bool CheckDuplicateUser(string name, int Id, int AgencyId);

        List<SelectionItem> GetRoles(int id);

        bool AddUser(UserViewModel viewModel);
    }
}
