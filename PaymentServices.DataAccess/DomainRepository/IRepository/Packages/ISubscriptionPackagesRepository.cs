using PaymentServices.Models.Domain.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.IRepository.Packages
{
    public interface ISubscriptionPackagesRepository :IRepository<SubscriptionPackages>
    {
        Task<bool> CreateSubscriptionPackage(SubscriptionPackages package);
          Task<bool> IsValidPackage(int id);
    }
}
