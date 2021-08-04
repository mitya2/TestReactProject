using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TestDB.Models;
using TestDB.Service;
using TestDB.Data.Interfaces;
using TestDB.Data.Repositories;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

namespace TestDB
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //���������� ����� ����������� �� appsettings.json
            Configuration.Bind("Project", new Config());

            // ����������� �������� ������ � ��
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Config.ConnectionString));
            
            // ������������� �����������
            services.AddTransient<IProducts, ProductsRepository>();
            services.AddTransient<ICustomers, CustomersRepository>();
            services.AddTransient<ISalesOrders, SalesOrdersRepository>();
            services.AddTransient<ISalesOrderDetails, SalesOrderDetailsRepository>();
            services.AddTransient<ISalesStatuses, SalesStatusesRepository>();
            
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "client-app/build";
            });

            // ����������� ��������� ���������� �������� MVC
            services.AddMvc();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ��������� �������� ������ � ��
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext appDBContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();

                // �������������� �� ���������� �� ���������
                AppDBContext.Initial(appDBContext);
            }

            //app.UseCors();

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
                spa.Options.SourcePath = "client-app";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}