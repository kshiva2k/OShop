using System;
using System.Collections.Generic;
using System.Linq;
using OShop.Models;
using OShop.ViewModels;
using OShop.Repository;
namespace OShop.Services
{
    public class AgencyService : AgencyRepository
    {
        public List<AgencyViewModel> GetAgencies()
        {
            using (var context = new oshopContext())
            {
                List<AgencyViewModel> records = new List<AgencyViewModel>();
                var agencies = context.GAgencymaster.Where(u => u.Active == 1).ToList();
                foreach(var item in agencies)
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
        }
        public bool AddAgency(AgencyViewModel viewModel)
        {
            using (var context = new oshopContext())
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
        }
        public bool UpdateAgency(AgencyViewModel viewModel)
        {
            using (var context = new oshopContext())
            {
                var record = context.GAgencymaster.Where(x => x.Id == viewModel.Id).FirstOrDefault();
                record.Name = viewModel.Name;
                record.Address = viewModel.Address;
                record.Phoneno = viewModel.Phoneno;
                record.Email = viewModel.Email;
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteAgency(int id)
        {
            using (var context = new oshopContext())
            {
                var record = context.GAgencymaster.Where(x => x.Id == id).FirstOrDefault();
                record.Active = 0;
                context.SaveChanges();
                return true;
            }
        }
        public AgencyViewModel GetAgency(int id)
        {
            using (var context = new oshopContext())
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
        }
    }
}
