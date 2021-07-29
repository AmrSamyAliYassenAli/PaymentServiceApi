using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentServices.Utility
{
    public static class SwaggerMiddelware
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Payment Middleware Services",
                    Version = "v1",
                    Description = "this service is to handel payments Operations",
                });
            });
            return services;
        }
    }
}
