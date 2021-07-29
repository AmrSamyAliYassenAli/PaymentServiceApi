using PaymentServices.DataAccess.DomainRepository;
using PaymentServices.DataAccess.DomainRepository.IRepository.Packages;
using PaymentServices.DataAccess.DomainRepository.Repository.Packages;
using PaymentServices.DataAccess.Providers.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.Providers.Services
{
    public class PackageDataProvider : IPackageDataProvider
    {
        private readonly MiddlewareDbContext _db;

        public PackageDataProvider(MiddlewareDbContext db)
        {
            _db = db;
            SubscriptionPackagePrices = new SubscriptionPackagePricesRepository(_db);
            SubscriptionPackages = new SubscriptionPackagesRepository(_db);
        }

        public ISubscriptionPackagePricesRepository SubscriptionPackagePrices { get; private set; }
        public ISubscriptionPackagesRepository SubscriptionPackages { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
