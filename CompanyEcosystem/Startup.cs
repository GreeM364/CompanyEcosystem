using Microsoft.OpenApi.Models;
using CompanyEcosystem.BL.Infrastructure;
using AutoMapper;
using CompanyEcosystem.PL.Middlewares;

namespace CompanyEcosystem.PL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection service)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            service.AddControllers();
            service.AddBusinessLogicLayer(connectionString);

            service.AddAutoMapper(typeof(AutomapperWebProfile));

            service.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}