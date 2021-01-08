using System;
using System.Collections.Generic;
using System.Linq;
using OShop.ViewModels;

namespace OShop.Repository
{
    public interface UserRepository
    {
        List<UserViewModel> GetUsers();
        UserViewModel ValidateUser(string _loginname, string _password);
    }
}
