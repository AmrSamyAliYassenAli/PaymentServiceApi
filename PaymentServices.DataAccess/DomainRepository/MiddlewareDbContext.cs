using Microsoft.EntityFrameworkCore;
using PaymentServices.Models.Domain.Lookups;
using PaymentServices.Models.Domain.Packages;
using PaymentServices.Models.Domain.Security;
using PaymentServices.Models.Domain.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentServices.DataAccess.DomainRepository
{
    public class MiddlewareDbContext : DbContext
    {
        public MiddlewareDbContext(DbContextOptions<MiddlewareDbContext> options)
            : base(options)
        {
        }

        #region Security

        public DbSet<WhitelistCountry> WhitelistCountry { get; set; }
        public DbSet<WhitelistIP> WhitelistIP { get; set; }
        public DbSet<BlockCountry> BlockCountry { get; set; }
        public DbSet<BlockIP> BlockIP { get; set; }
        public DbSet<BlockDomain> BlockDomain { get; set; }

        #endregion

        #region Country & Currencies & Languages

        public DbSet<Currency> Currency { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Language> Language { get; set; }

        #endregion

        #region Payment Packages

        public DbSet<SubscriptionPackages> SubscriptionPackages { get; set; }
        public DbSet<SubscriptionPackagePrices> SubscriptionPackagePrices { get; set; }

        #endregion

        #region Subscription

        public DbSet<SubscriptionTransaction> SubscriptionTransaction { get; set; }
        public DbSet<CompanyUsers> CompanyUsers { get; set; }
        public DbSet<CompanyProfile> CompanyProfile { get; set; }
        public DbSet<AccessRoles> AccessRoles { get; set; }
        public DbSet<AccessPermissions> AccessPermissions { get; set; }

        #endregion
    }
}
