using CompanyEcosystem.BL;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

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
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}