using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TicketOnLine_webSite.Hubs;
using TicketOnLine_webSite.Infrastructure;
using TicketOnLine_webSite.Utils;

namespace TicketOnLine_webSite
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

            #region ajout des services pour les sessions
            //-----va permettre de stocker en cache les variables de sessions
            services.AddDistributedMemoryCache();
            services.AddSession(option =>
                {
                    option.IdleTimeout = TimeSpan.FromDays(1);
                    option.Cookie.HttpOnly = true;
                    option.Cookie.IsEssential = true;

                });
            #endregion

            services.AddHttpContextAccessor();//va permettre de l avoir en injection de pépendance dans les session TOOls
            services.AddTransient<ISessionTools, SessionTools>();
            services.AddSingleton<IHascMdp, HascMdp>();
            services.AddSignalR();
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}
