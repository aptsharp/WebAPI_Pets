using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pets.API.Model;
using Pets.API.Repository;
using Pets.API.Services;

namespace Pets.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Services add no Swegger 
            services.AddSingleton<OwnerRepository>();
            services.AddSingleton<DogRepository>();
            services.AddSingleton<CatRepository>();

            services.AddTransient<Owner>();
            services.AddTransient<Dog>();
            services.AddTransient<Cat>();

            services.AddTransient<OwnerService>();
            services.AddTransient<DogService>();
            services.AddTransient<CatService>();

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pets API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(p =>
            {
                p.SwaggerEndpoint("swagger/v1/swagger.json", "Bertha ERP API - v1");
                p.RoutePrefix = string.Empty;
            }
            );

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

            /*
             * Swagger cria uma "telinha" com toda a API
             */

        }
    }
}
