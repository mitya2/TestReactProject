using Microsoft.EntityFrameworkCore;
using SIAM.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIAM.Models
{
    /// <summary>
    /// Класс контекста БД
    /// </summary>
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public DbSet<SalesStatus> SalesStatuses { get; set; }

        /// <summary>
        /// Наполняет базу данных значениями по-умолчанию
        /// </summary>
        public static void Initial(AppDBContext appDBContext)
        {
            if (!appDBContext.SalesStatuses.Any())
            {
                appDBContext.SalesStatuses.AddRange(
                    new SalesStatus { Name = "Создан" },
                    new SalesStatus { Name = "Обрабатывается" },
                    new SalesStatus { Name = "Принят" },
                    new SalesStatus { Name = "Оплачен" },
                    new SalesStatus { Name = "Готов к отгрузке" },
                    new SalesStatus { Name = "Отгружен" });
                appDBContext.SaveChanges();
            }

            if (!appDBContext.Products.Any())
            {
                appDBContext.Products.AddRange(
                    new Product { Name = "Картофель", Price = 50 },
                    new Product { Name = "Яблоко", Price = 100, Comment = "Сорт Голден" },
                    new Product { Name = "Банан", Price = 55 },
                    new Product { Name = "Морковь", Price = 40, Comment = "Мытая" },
                    new Product { Name = "Лесной орех", Price = 1200 }
                    );
                appDBContext.SaveChanges();
            }

        }
    }
}