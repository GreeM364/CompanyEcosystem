using CompanyEcosystem.DAL.EF;
using CompanyEcosystem.DAL.Entities;
using CompanyEcosystem.DAL.Interfaces;
using CompanyEcosystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyEcosystem.DAL.Infrastructure
{
    public static class DataAccessLayerExtensions
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CompanyEcosystemContext>(options => options.UseSqlServer(connectionString));
            

            services.AddScoped<IRepository<Location>, LocationRepository>();
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<IRepository<Questionnaire>, QuestionnaireRepository>();

            return services;
        }
    }
}
