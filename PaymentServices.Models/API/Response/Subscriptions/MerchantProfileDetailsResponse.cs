using PaymentServices.Models.ViewModels.Packages;
using PaymentServices.Models.ViewModels.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.Models.API.Response.Subscriptions
{
    public class MerchantProfileDetailsResponse
    {
        public ProfileVM ProfileVM { get; set; }
        // Count Number of users in this Company
        public int NoOfUsers { get; set; }
        // Subscription Package
        public SubscriptionPackagesVM SubscriptionPackagesVM { get; set; }
    }
}
