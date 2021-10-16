
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.EntityFrameworkCore;
namespace Classroom
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<classroomContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddMvc();
            services.AddHttpContextAccessor();


            services.AddDistributedMemoryCache();

            services.AddDbContext<classroomContext>(option => option.UseSqlServer("Server=DESKTOP-QGEEUPD;Database=classroom;Trusted_Connection=True;"));
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
                       name: "Main",
                       pattern: "{controller=Index}/{action=Index}"
                );
                endpoints.MapControllerRoute(
                       name: "Tasks",
                       pattern: "{controller=Index}/{action=TasksInGroup}/{id}"
                );
                endpoints.MapControllerRoute(
                       name: "Peoples",
                       pattern: "{controller=Index}/{action=PeopleInGroup}/{id}"
                );
                endpoints.MapControllerRoute(
                       name: "Task",
                       pattern: "{controller=Index}/{action=Task}/{id}"
                );
                endpoints.MapControllerRoute(
                       name: "Reaply",
                       pattern: "{controller=Index}/{action=Reaply}/{id}"
                );
                endpoints.MapControllerRoute(
                       name: "ReaplyDelete",
                       pattern: "{controller=Index}/{action=ReaplyDelete}/{id}"
                );
                endpoints.MapControllerRoute(
                       name: "User",
                       pattern: "{controller=User}/{action=Index}"
                );
                endpoints.MapControllerRoute(
                       name: "file",
                       pattern: "{controller=Index}/{action=DownloadFile}/{id}"
                );
                endpoints.MapControllerRoute(
                       name: "file",
                       pattern: "{controller=Index}/{action=DownloadTaskFile}/{id}"
                );
                
                endpoints.MapControllerRoute(
                    name:"Delete task", 
                    pattern: "{controller=Index}/{action=DeleteTask}/{id}"
                    );
                endpoints.MapControllerRoute(
                    name: "Delete Group",
                    pattern: "{controller=Index}/{action=DeleteGroup}/{id}"
                    );
                endpoints.MapControllerRoute(
                       name: "IndexRL",
                       pattern: "{controller=RegAut}/{action=Index}"
                );
                endpoints.MapControllerRoute(
                    name: "Create task",
                    pattern: "{controller=Index}/{action=CreateTask}/{id}"
                    ); 

            });
        }
    }
}
