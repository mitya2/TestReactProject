using Microsoft.EntityFrameworkCore;
using TestDB.Models;
using System.Linq;

namespace TestDB.Models
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(obj => obj.Price).HasPrecision(18, 2);
            modelBuilder.Entity<SalesOrderDetail>().Property(obj => obj.UnitPrice).HasPrecision(18, 2);
        }

        /// <summary>
        /// Наполняет базу данных значениями по умолчанию
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
                    new Product { Name = "Лесной орех", Price = 1200 },
                    new Product { Name = "Лимон", Price = 200 },
                    new Product { Name = "Имбирь", Price = 2000 },
                    new Product { Name = "Зеленый лук", Price = 50 },
                    new Product { Name = "Свекла", Price = 200 },
                    new Product { Name = "Виноград", Price = 399 },
                    new Product { Name = "Персик", Price = 240 },
                    new Product { Name = "Абрикос", Price = 250 },
                    new Product { Name = "Нектарин", Price = 200 },
                    new Product { Name = "Манго", Price = 1000 }
                    );
                appDBContext.SaveChanges();
            }
        }
    }
}