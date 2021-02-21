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

        bool AddDelivery(DeliveryViewModel viewModel);
        List<DeliveryViewModel> GetActivities(int agencyId, string shopCode, int shopno);
        bool ClearBill(long id);
        AgencyDashboardViewModel GetDashboardData(int id);
    }
}
