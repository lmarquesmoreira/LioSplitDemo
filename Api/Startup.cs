using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.Repository;
using Microsoft.EntityFrameworkCore;
using Api.Services.Interfaces;
using Api.Services;
using Api.Repository.Interfaces;
using Api.Domain;

namespace Api
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
            //var trueConnectionString = "Server=tcp:rpugg.database.windows.net,1433;Database=SplitMock;User ID=rpuggian;Password=R4f43lPv66;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(@"Server=tcp:rpugg.database.windows.net,1433;Database=SplitMock;User ID=rpuggian;Password=R4f43lPv66;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

            services.AddMvc();

            services.AddTransient<IRepository<Seller>, GenericRepository<Seller>>();
            services.AddTransient<IRepository<SellerTransaction>, GenericRepository<SellerTransaction>>();
            services.AddTransient<IRepository<Transaction>, GenericRepository<Transaction>>();
            services.AddTransient<ISplitService, SplitService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
