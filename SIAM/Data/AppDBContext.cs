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
                    new Customer { CustomerId = 1, Name = "Иванов Иван Иванович" },
                    new Customer { CustomerId = 2, Name = "Петров Петр Петрович" },
                    new Customer { CustomerId = 3, Name = "Сидоров Сидор Сидорович" }
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

            modelBuilder.Entity<SalesOrderDetail>().HasData(
                new SalesOrderDetail { SalesOrderDetailId = 1, SalesOrderId = 1, ProductId = 1, OrderQuantity = 5, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-1) },
                new SalesOrderDetail { SalesOrderDetailId = 2, SalesOrderId = 1, ProductId = 2, OrderQuantity = 10, UnitPrice = 200, ModifyDate = System.DateTime.Now.AddMonths(-1) },
                new SalesOrderDetail { SalesOrderDetailId = 3, SalesOrderId = 1, ProductId = 3, OrderQuantity = 15, UnitPrice = 300, ModifyDate = System.DateTime.Now.AddMonths(-1) },
                new SalesOrderDetail { SalesOrderDetailId = 4, SalesOrderId = 1, ProductId = 4, OrderQuantity = 1, UnitPrice = 400, ModifyDate = System.DateTime.Now.AddMonths(-2) },
                new SalesOrderDetail { SalesOrderDetailId = 5, SalesOrderId = 1, ProductId = 5, OrderQuantity = 2, UnitPrice = 500, ModifyDate = System.DateTime.Now.AddMonths(-3) },
                new SalesOrderDetail { SalesOrderDetailId = 6, SalesOrderId = 1, ProductId = 6, OrderQuantity = 50, UnitPrice = 600, ModifyDate = System.DateTime.Now.AddMonths(-3) },

                new SalesOrderDetail { SalesOrderDetailId = 7, SalesOrderId = 2, ProductId = 1, OrderQuantity = 5, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-2) },
                new SalesOrderDetail { SalesOrderDetailId = 8, SalesOrderId = 2, ProductId = 2, OrderQuantity = 10, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-2) },
                new SalesOrderDetail { SalesOrderDetailId = 9, SalesOrderId = 2, ProductId = 3, OrderQuantity = 20, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-2) },

                new SalesOrderDetail { SalesOrderDetailId = 10, SalesOrderId = 3, ProductId = 1, OrderQuantity = 30, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-1) },
                new SalesOrderDetail { SalesOrderDetailId = 11, SalesOrderId = 3, ProductId = 2, OrderQuantity = 40, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-1) },
                new SalesOrderDetail { SalesOrderDetailId = 12, SalesOrderId = 3, ProductId = 5, OrderQuantity = 50, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-1) },
                new SalesOrderDetail { SalesOrderDetailId = 13, SalesOrderId = 3, ProductId = 6, OrderQuantity = 60, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-1) },

                new SalesOrderDetail { SalesOrderDetailId = 14, SalesOrderId = 4, ProductId = 1, OrderQuantity = 1, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-10) },

                new SalesOrderDetail { SalesOrderDetailId = 15, SalesOrderId = 5, ProductId = 1, OrderQuantity = 10, UnitPrice = 100, ModifyDate = System.DateTime.Now.AddMonths(-10) },
                new SalesOrderDetail { SalesOrderDetailId = 16, SalesOrderId = 5, ProductId = 2, OrderQuantity = 10, UnitPrice = 200, ModifyDate = System.DateTime.Now.AddMonths(-20) },
                new SalesOrderDetail { SalesOrderDetailId = 17, SalesOrderId = 5, ProductId = 3, OrderQuantity = 10, UnitPrice = 300, ModifyDate = System.DateTime.Now.AddMonths(-30) },
                new SalesOrderDetail { SalesOrderDetailId = 18, SalesOrderId = 5, ProductId = 4, OrderQuantity = 10, UnitPrice = 400, ModifyDate = System.DateTime.Now.AddMonths(-40) },
                new SalesOrderDetail { SalesOrderDetailId = 19, SalesOrderId = 5, ProductId = 5, OrderQuantity = 10, UnitPrice = 500, ModifyDate = System.DateTime.Now.AddMonths(-50) },
                new SalesOrderDetail { SalesOrderDetailId = 20, SalesOrderId = 5, ProductId = 6, OrderQuantity = 10, UnitPrice = 600, ModifyDate = System.DateTime.Now.AddMonths(-60) }
               );
        }
    }
}