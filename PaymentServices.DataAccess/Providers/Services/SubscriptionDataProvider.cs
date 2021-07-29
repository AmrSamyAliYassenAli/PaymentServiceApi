using PaymentServices.DataAccess.DomainRepository;
using PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions;
using PaymentServices.DataAccess.DomainRepository.Repository.Subscriptions;
using PaymentServices.DataAccess.Providers.Contract;
using PaymentServices.Infrastructure.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.Providers.Services
{
    public class SubscriptionDataProvider : ISubscriptionDataProvider
    {
        private readonly MiddlewareDbContext _db;
        private readonly IEncryption _encryption;
        public SubscriptionDataProvider(MiddlewareDbContext db)
        {
            _db = db;
            AccessPermissions = new AccessPermissionsRepository(_db);
            AccessRoles = new AccessRolesRepository(_db);
            CompanyProfile = new CompanyProfileRepository(_db);
            CompanyUsers = new CompanyUsersRepository(_db, _encryption);
            SubscriptionTransaction = new SubscriptionTransactionRepository(_db); 
        }

        public IAccessPermissionsRepository AccessPermissions { get; private set; } 
        public IAccessRolesRepository AccessRoles { get; private set; } 
        public ICompanyProfileRepository CompanyProfile { get; private set; } 
        public ICompanyUsersRepository CompanyUsers { get; private set; } 
        public ISubscriptionTransactionRepository SubscriptionTransaction { get; private set; } 

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
