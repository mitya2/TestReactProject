using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SIAM.Models;
using SIAM.Service;
using SIAM.Data.Interfaces;
using SIAM.Data.Repositories;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

namespace SIAM
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем класс конфигуации из appsettings.json
            Configuration.Bind("Project", new Config());

            // настраиваем контекст работы с БД
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Config.ConnectionString));
            
            // устанавливаем зависимости
            services.AddTransient<IProducts, ProductsRepository>();
            services.AddTransient<ICustomers, CustomersRepository>();
            services.AddTransient<ISalesOrders, SalesOrdersRepository>();
            services.AddTransient<ISalesOrderDetails, SalesOrderDetailsRepository>();
            services.AddTransient<ISalesStatuses, SalesStatusesRepository>();
            
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client_app/build";
            });

            // настраиваем поддержку механизмов паттерна MVC
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // формируем контекст работв с БД
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext appDBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();

                // инициалихируем БД значениями по умолчанию
                AppDBContext.Initial(appDBContext);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();


            /*app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client_app";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });



        }
    }
}