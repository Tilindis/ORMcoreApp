using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ORMcoreApp.DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfficersWebAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OfficersWebAPI", Version = "v1" });
            });
            services.AddControllers().AddNewtonsoftJson();
            services.AddScoped<PoliceManContent>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OfficersWebAPI v1"));
            }

            app.UseMiddleware<MyMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "default", pattern: "api/v2/{controller}/{action}/{id?}"); //GetAll / Get 5 / Delete 5
                endpoints.MapControllerRoute(name: "default", pattern: "api/v2/{controller}/{action}/{gunname}/{gunmodel}/{gunid}"); //Post Gun
                endpoints.MapControllerRoute(name: "default", pattern: "api/v2/{controller}/{action}/{id}/{gunname}/{gunmodel}/{gunid}"); // Put
                endpoints.MapControllerRoute(name: "default", pattern: "api/v2/{controller}/{action}/{id?}/{key?}"); // Patch
            });
        }
    }
}
