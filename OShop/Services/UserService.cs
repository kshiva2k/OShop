using OShop.Models;
using OShop.Repository;
using OShop.ViewModels;
using System.Collections.Generic;
using System.Linq;
namespace OShop.Services
{
    public class UserService : UserRepository
    {
        oshopContext context { get; }
        public UserService(oshopContext _context)
        {
            context = _context;
        }
        public bool AddUser(UserViewModel viewModel)
        {
            context.GUsermaster.Add(new GUsermaster()
            {
                Loginname = viewModel.Loginname,
                Password = "Pass@123",
                Mobileno = viewModel.Mobileno,
                Email = viewModel.Email,
                Agencyid = viewModel.Agencyid,
                Roleid = viewModel.Roleid,
                Active = 1

            });
            context.SaveChanges();
            return true;

        }
        public bool CheckDuplicateUser(string name, int Id, int AgencyId)
        {
            if (Id == 0)  // Add mode
            {
                var record = context.GUsermaster.Where(x => x.Loginname == name && x.Agencyid == AgencyId && x.Active.Value == 1).FirstOrDefault();
                if (record != null )
                    return false;  // Duplicate exists
                else
                    return true;  // No Duplication
            }
            else
            {
                var record = context.GUsermaster.Where(x => x.Loginname == name && x.Active.Value == 1 && x.Id != Id).FirstOrDefault();
                if (record != null || record.Id > 0)
                    return false;  // Duplicate exists
                else
                    return true;  // No Duplication
            }
        }
        public List<UserViewModel> GetUsers(int id)
        {
            List<UserViewModel> records = new List<UserViewModel>();
            var users = (from a in context.GUsermaster
                         join b in context.GRolemaster on a.Roleid equals b.Id
                         where (a.Active == 1 && a.Agencyid == id)
                         select new { a.Id, a.Loginname, a.Email, a.Mobileno, b.Name, a.Agencyid, a.Roleid }).ToList();
            foreach (var item in users)
            {
                records.Add(new UserViewModel()
                {
                    Id = item.Id,
                    Loginname = item.Loginname,
                    Email = item.Email,
                    Mobileno = item.Mobileno,
                    Roleid = item.Roleid,
                    Agencyid = item.Agencyid.GetValueOrDefault(),
                    RoleName = item.Name
                });
            }
            return records;

        }
        public UserViewModel ValidateUser(string _loginname, string _password)
        {
            var item = context.GUsermaster.Where(u => u.Active == 1 && u.Loginname == _loginname && u.Password == _password).FirstOrDefault();
            UserViewModel record = new UserViewModel();
            if (item != null)
                record = new UserViewModel()
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

        public List<SelectionItem> GetRoles(int id)
        {


            List<SelectionItem> records = new List<SelectionItem>();

            if (id == 1)
            {
                var shops = context.GRolemaster.Where(u => u.Active == 1).ToList();
                foreach (var item in shops)
                {
                    records.Add(new SelectionItem()
                    {
                        Id = item.Id,

                        Name = item.Name
                    });
                }
            }
            else
            {
                var shops = context.GRolemaster.Where(u => u.Active == 1 && u.Id != 1).ToList();
                foreach (var item in shops)
                {
                    records.Add(new SelectionItem()
                    {
                        Id = item.Id,

                        Name = item.Name
                    });
                }
            }


            return records;

        }
    }
}
