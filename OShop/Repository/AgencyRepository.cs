using System;
using System.Collections.Generic;
using OShop.ViewModels;

namespace OShop.Repository
{
    public interface AgencyRepository
    {
        List<AgencyViewModel> GetAgencies();
        bool AddAgency(AgencyViewModel viewModel);
        bool UpdateAgency(AgencyViewModel viewModel);
        bool DeleteAgency(int id);
        AgencyViewModel GetAgency(int id);
    }
}
