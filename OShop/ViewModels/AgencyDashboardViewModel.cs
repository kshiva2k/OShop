using System;
namespace OShop.ViewModels
{
    public class AgencyDashboardViewModel
    {
        public int OrdersDelivered { get; set; }
        public decimal AmountsCollected { get; set; }
        public int ClientCount { get; set; }
        public decimal OverallBalance { get; set; }
    }
}
