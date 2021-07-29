using PaymentServices.Models.ViewModels.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.ViewModels.Subscriptions
{
    public class ProfileDetailsVM
    {
        public ProfileVM ProfileVM { get; set; }
        // Count Number of users in this Company
        public int NoOfUsers { get; set; }
        // Subscription Package
        public SubscriptionPackagesVM SubscriptionPackagesVM { get; set; }       
    }
}
