using PaymentServices.DataAccess.DomainRepository.IRepository.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.Providers.Contract
{
    public interface IPackageDataProvider : IDisposable
    {
        ISubscriptionPackagePricesRepository SubscriptionPackagePrices  {get; }
        ISubscriptionPackagesRepository SubscriptionPackages  {get; }
    }
}
