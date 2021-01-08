using System;
using System.Collections.Generic;
using System.Linq;
using OShop.Models;
using OShop.Repository;
using OShop.ViewModels;
namespace OShop.Services
{
    public class UserService : UserRepository
    {
        public List<UserViewModel> GetUsers()
        {
            List<UserViewModel> records = new List<UserViewModel>();
            using (var context = new oshopContext())
            {
                var users = context.GUsermaster.Where(u => u.Active == 1).ToList();
                foreach(var item in users)
                {
                    records.Add(new UserViewModel()
                    {
                        Id = item.Id,
                        Loginname = item.Loginname,
                        Email = item.Email,
                        Mobileno = item.Mobileno,
                        Roleid = item.Roleid,
                        Agencyid = item.Agencyid.GetValueOrDefault()
                    });
                }
                return records;
            }
        }
        public UserViewModel ValidateUser(string _loginname, string _password)
        {
            using (var context = new oshopContext())
            {
                var item = context.GUsermaster.Where(u => u.Active == 1 && u.Loginname == _loginname && u.Password == _password).FirstOrDefault();
                UserViewModel record = new UserViewModel()
                {
                    Id = item.Id,
                    Loginname = item.Loginname,
                    Email = item.Email,
                    Mobileno = item.Mobileno,
                    Roleid = item.Roleid,
                    Agencyid = item.Agencyid.GetValueOrDefault()
                };
                return record;
            }
        }
    }
}
