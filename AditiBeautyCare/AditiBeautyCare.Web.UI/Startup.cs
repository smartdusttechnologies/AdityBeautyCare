using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AditiBeautyCare.Business.Core.Interfaces;
using AditiBeautyCare.Business.Core.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository;
using AditiBeautyCare.Business.Data.Repository.BeautyCareService;
using AditiBeautyCare.Business.Data.Repository.Interfaces;
using AditiBeautyCare.Business.Data.Repository.Interfaces.BeautyCareService;
using AditiBeautyCare.Business.Infrastructure;
using AditiBeautyCare.Business.Services;
using AditiBeautyCare.Business.Services.BeautyCareService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AditiBeautyCare.Web.UI
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
            services.AddControllersWithViews();
            //Services
            services.AddScoped<ISampleService, SampleService>();
            services.AddScoped<IBeautyCareService, BeautyCareService>();
            services.AddScoped<IGetInTouchService, GetInTouchService>();
            services.AddScoped<IEmailService, EmailService>();

            //Repository
            services.AddScoped<IConnectionFactory, AditiBeautyCare.Business.Infrastructure.ConnectionFactory>();
            services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<IBeautyCareServiceRepository, BeautyCareRepository>();
            services.AddScoped<IGetInTouchRepository, GetInTouchRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
