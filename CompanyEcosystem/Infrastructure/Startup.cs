using Microsoft.OpenApi.Models;
using CompanyEcosystem.BL.Infrastructure;
using CompanyEcosystem.PL.Middlewares;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

namespace CompanyEcosystem.PL.Infrastructure
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
            service.AddCors();

            service.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Api", Version = "v1" }));

            service.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            //app.UseMiddleware<ExceptionHandlingMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"img")),
                RequestPath = new PathString("/img")
            });
            app.UseRouting();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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