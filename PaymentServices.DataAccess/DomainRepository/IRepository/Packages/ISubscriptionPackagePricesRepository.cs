using PaymentServices.Models.Domain.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository.IRepository.Packages
{
    public interface ISubscriptionPackagePricesRepository : IRepository<SubscriptionPackagePrices>
    {
        Task DeleteMany(List<SubscriptionPackagePrices> packages); 
        Task AddManyItems(List<SubscriptionPackagePrices> packages);
        Task<List<SubscriptionPackagePrices>> GetPricesOfPackage(int id);
    }
}
