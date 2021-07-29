using PaymentServices.DataAccess.DomainRepository.IRepository.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.Providers.Contract
{
    public interface ISubscriptionDataProvider : IDisposable
    {
        IAccessPermissionsRepository AccessPermissions { get; }
        IAccessRolesRepository AccessRoles { get; }
        ICompanyProfileRepository CompanyProfile { get; }
        ICompanyUsersRepository CompanyUsers { get; }
        ISubscriptionTransactionRepository SubscriptionTransaction { get; }
    }
}
