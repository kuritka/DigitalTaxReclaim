using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using DTR.Services;
using DTR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using DTR.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DTR
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<Account, IdentityRole>(
                cfg => {
                    cfg.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<ReclaimContext>();

            services.AddDbContext<ReclaimContext>(cfg =>
            {
                cfg.UseSqlServer(_configuration.GetConnectionString("MSSQL"));
            });
            services.AddAutoMapper();
            services.AddScoped<IReclaimRepository, ReclaimRepository>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<ReclaimSeeder>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(cfg => {
                cfg.MapRoute("Default", "{controller}/{action}/{id?}", new { controller = "App", Action="Index"});
            });

            if (env.IsDevelopment())
            {
                using(var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService< ReclaimSeeder >();
                    seeder.Seed().Wait();
                }
                
            }
        }
    }
}
