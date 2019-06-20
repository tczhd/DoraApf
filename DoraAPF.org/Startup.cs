using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoraAPF.org.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DoraAPF.org.Facade.Interfaces.Repository;
using DoraAPF.org.Data.Repository.Base;
using DoraAPF.org.Facade.Interfaces;
using DoraAPF.org.Facade.Services;
using DoraAPF.org.Facade.Interfaces.Payment;
using DoraAPF.org.Facade.Services.Payment;
using DoraAPF.org.Models.Payment.Helcim;

namespace DoraAPF.org
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
            //services.AddDistributedMemoryCache();

            //services.AddSession(options =>
            //{
            //    // Set a short timeout for easy testing.
            //    options.IdleTimeout = TimeSpan.FromDays(1);
            //    options.Cookie.HttpOnly = true;
            //    // Make the session cookie essential
            //    options.Cookie.IsEssential = true;
            //});

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));


            services.AddDbContext<DoraAPFContext>(options =>
       options.UseSqlServer(
           Configuration.GetConnectionString("DefaultConnection")
           , b => b.MigrationsAssembly("DoraAPF.org")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")
                    , b => b.MigrationsAssembly("DoraAPF.org")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDefaultIdentity<IdentityUser > ()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

            services.AddScoped<IVisitorService, VisitorService>();
            services.AddScoped<IThirdPartyPaymentService, HelcimPaymentService>();

            services.Configure<HelcimAccount>(Configuration.GetSection("Helcim"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
           // app.UseSession();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
