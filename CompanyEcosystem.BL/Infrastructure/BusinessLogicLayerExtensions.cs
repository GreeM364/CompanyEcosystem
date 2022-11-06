using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyEcosystem.BL.Interfaces;
using CompanyEcosystem.BL.Services;
using CompanyEcosystem.DAL.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyEcosystem.BL.Infrastructure
{
    public static class BusinessLogicLayerExtensions
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection service, string connectionString)
        {
            service.AddDataAccessLayer(connectionString);

            service.AddAutoMapper(typeof(AutomapperBLProfile));

            service.AddScoped<ILocationService, LocationService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<IQuestionnaireService, QuestionnaireService>();
            service.AddScoped<IThingService, ThingService>();
            service.AddScoped<IPostService, PostService>();


            return service;
        }
    }
}
