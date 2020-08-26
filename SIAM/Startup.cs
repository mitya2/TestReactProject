using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SIAM.Models;
using SIAM.Service;
using SIAM.Data.Interfaces;
using SIAM.Data.Repositories;

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

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
