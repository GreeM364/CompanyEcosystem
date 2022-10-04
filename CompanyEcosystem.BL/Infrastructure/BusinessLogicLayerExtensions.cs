using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.BL.Services;
using CompanyEcosystem.DAL.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyEcosystem.BL.Infrastructure
{
    public static class BusinessLogicLayerExtensions
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccessLayer(connectionString);
            services.AddScoped<ILocationService, ServiceLocation>();

            return services;
        }
    }
}
