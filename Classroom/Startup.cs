using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddHttpContextAccessor();


            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                       name: "Index",
                       pattern: "{controller=Index}/{action=Index}"
                );
                endpoints.MapControllerRoute(
                       name: "Index",
                       pattern: "{controller=Index}/{action=TasksInGroup}/{id}"
                );
                endpoints.MapControllerRoute(
                       name: "Index",
                       pattern: "{controller=Index}/{action=Task}/{id}"
                );
                endpoints.MapControllerRoute(
                       name: "IndexU",
                       pattern: "{controller=User}/{action=Index}"
                );
                endpoints.MapControllerRoute(
                       name: "IndexRL",
                       pattern: "{controller=RegAut}/{action=Index}"
                );

            });
        }
    }
}
