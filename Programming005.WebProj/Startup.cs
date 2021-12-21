using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Programming005.WebProj.DataAccessLayer;
using Programming005.WebProj.DataAccessLayer.Abstraction;
using Programming005.WebProj.DataAccessLayer.Domain.Entities;
using Programming005.WebProj.Helpers;
using Programming005.WebProj.Helpers.Abstraction;
using Programming005.WebProj.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming005.WebProj
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
            services.AddSingleton<IDatabase, InMemoryDatabase>();
            //services.AddTransient<IDatabase, InMemoryDatabase>();
            //services.AddScoped<IDatabase, InMemoryDatabase>();
            services.AddSingleton<IDatabaseLogHelper, DatabaseLoghelper>();
            services.AddSingleton<IUnitOfWork, InMemoryUnitOfWork>();

            services.AddControllersWithViews();

            services.AddAuthentication();
            services.AddIdentity<Account, Role>();
            services.AddTransient<IUserStore<Account>, UserStore>();
            services.AddTransient<IRoleStore<Role>, RoleStore>();

            services.Configure<IdentityOptions>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequiredLength = 1;
                o.Password.RequireLowercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireUppercase = false;
            });
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

            app.UseAuthentication();
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
