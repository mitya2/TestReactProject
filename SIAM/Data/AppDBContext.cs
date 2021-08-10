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

            modelBuilder.Entity<SalesStatus>().HasData(
                    new SalesStatus { SalesStatusId = 1, Name = "Создан" },
                    new SalesStatus { SalesStatusId = 2, Name = "Обрабатывается" },
                    new SalesStatus { SalesStatusId = 3, Name = "Принят" },
                    new SalesStatus { SalesStatusId = 4, Name = "Оплачен" },
                    new SalesStatus { SalesStatusId = 5, Name = "Готов к отгрузке" },
                    new SalesStatus { SalesStatusId = 6, Name = "Отгружен" }
                    );

            modelBuilder.Entity<Customer>().HasData(
                    new Customer { CustomerId = 1, Name = "Иванов" },
                    new Customer { CustomerId = 2, Name = "Петров" },
                    new Customer { CustomerId = 3, Name = "Сидоров" }
                    );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, Name = "Картофель", Price = 50 },
                    new Product { ProductId = 2, Name = "Яблоко", Price = 100, Comment = "Сорт Голден" },
                    new Product { ProductId = 3, Name = "Банан", Price = 55 },
                    new Product { ProductId = 4, Name = "Морковь", Price = 40, Comment = "Мытая" },
                    new Product { ProductId = 5, Name = "Лесной орех", Price = 1200 },
                    new Product { ProductId = 6, Name = "Лимон", Price = 200 },
                    new Product { ProductId = 7, Name = "Имбирь", Price = 2000 },
                    new Product { ProductId = 8, Name = "Зеленый лук", Price = 50 },
                    new Product { ProductId = 9, Name = "Свекла", Price = 200 },
                    new Product { ProductId = 10, Name = "Виноград", Price = 399 },
                    new Product { ProductId = 11, Name = "Персик", Price = 240 },
                    new Product { ProductId = 12, Name = "Абрикос", Price = 250 },
                    new Product { ProductId = 13, Name = "Нектарин", Price = 200 },
                    new Product { ProductId = 14, Name = "Манго", Price = 1000 }
                    );

            modelBuilder.Entity<SalesOrder>().HasData(
                    new SalesOrder
                    {
                        SalesOrderId = 1,
                        OrderDate = System.DateTime.Now,
                        CustomerId = 1,
                        SalesStatusId = 1,
                        Comment = ""
                    },
                    new SalesOrder
                    {
                        SalesOrderId = 2,
                        OrderDate = System.DateTime.Now.AddMonths(-1),
                        CustomerId = 2,
                        SalesStatusId = 2,
                        Comment = "Безналичная оплата"
                    },
                    new SalesOrder
                    {
                        SalesOrderId = 3,
                        OrderDate = System.DateTime.Now.AddMonths(-3),
                        CustomerId = 3,
                        SalesStatusId = 3,
                        Comment = "Оплата наличкой"
                    },
                    new SalesOrder
                    {
                        SalesOrderId = 4,
                        OrderDate = System.DateTime.Now.AddMonths(-2),
                        CustomerId = 1,
                        SalesStatusId = 4
                    },
                    new SalesOrder
                    {
                        SalesOrderId = 5,
                        OrderDate = System.DateTime.Now.AddMonths(-3),
                        CustomerId = 2,
                        SalesStatusId = 5
                    },
                    new SalesOrder
                    {
                        SalesOrderId = 6,
                        OrderDate = System.DateTime.Now.AddMonths(-2),
                        CustomerId = 3,
                        SalesStatusId = 6,
                        Comment = "Оплата наличкой"
                    },
                    new SalesOrder
                    {
                        SalesOrderId = 7,
                        OrderDate = System.DateTime.Now.AddMonths(-12),
                        CustomerId = 1,
                        SalesStatusId = 5
                    }
                    );
        }
    }
}