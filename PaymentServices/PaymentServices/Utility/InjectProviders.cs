using Microsoft.Extensions.DependencyInjection;
using PaymentServices.DataAccess.Providers;
using PaymentServices.DataAccess.Providers.Contract;
using PaymentServices.DataAccess.Providers.Services;
using PaymentServices.Infrastructure.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.Utility
{
    public static class InjectProviders
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            // Main Providers
            services.AddScoped<IDefaultDataProvider, DefaultDataProvider>();
            services.AddScoped<ILookupsDataProvide, LookupsDataProvide>();
            services.AddScoped<IPackageDataProvider, PackageDataProvider>();
            services.AddScoped<ISecurityDataProvider, SecurityDataProvider>();
            services.AddScoped<ISubscriptionDataProvider, SubscriptionDataProvider>();
            // Helper Providers
            services.AddScoped<IEncryption, Encryption>();
            return services;
        }
    }
}
