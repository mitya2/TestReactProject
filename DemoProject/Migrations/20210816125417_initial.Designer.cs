﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DemoProject.Models;

namespace DemoProject.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210816125417_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestDB.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Name = "Иванов Иван Иванович"
                        },
                        new
                        {
                            CustomerId = 2,
                            Name = "Петров Петр Петрович"
                        },
                        new
                        {
                            CustomerId = 3,
                            Name = "Сидоров Сидор Сидорович"
                        });
                });

            modelBuilder.Entity("TestDB.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Картофель",
                            Price = 50m
                        },
                        new
                        {
                            ProductId = 2,
                            Comment = "Сорт Голден",
                            Name = "Яблоко",
                            Price = 100m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Банан",
                            Price = 55m
                        },
                        new
                        {
                            ProductId = 4,
                            Comment = "Мытая",
                            Name = "Морковь",
                            Price = 40m
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "Лесной орех",
                            Price = 1200m
                        },
                        new
                        {
                            ProductId = 6,
                            Name = "Лимон",
                            Price = 200m
                        },
                        new
                        {
                            ProductId = 7,
                            Name = "Имбирь",
                            Price = 2000m
                        },
                        new
                        {
                            ProductId = 8,
                            Name = "Зеленый лук",
                            Price = 50m
                        },
                        new
                        {
                            ProductId = 9,
                            Name = "Свекла",
                            Price = 200m
                        },
                        new
                        {
                            ProductId = 10,
                            Name = "Виноград",
                            Price = 399m
                        },
                        new
                        {
                            ProductId = 11,
                            Name = "Персик",
                            Price = 240m
                        },
                        new
                        {
                            ProductId = 12,
                            Name = "Абрикос",
                            Price = 250m
                        },
                        new
                        {
                            ProductId = 13,
                            Name = "Нектарин",
                            Price = 200m
                        },
                        new
                        {
                            ProductId = 14,
                            Name = "Манго",
                            Price = 1000m
                        });
                });

            modelBuilder.Entity("TestDB.Models.SalesOrder", b =>
                {
                    b.Property<int>("SalesOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SalesStatusId")
                        .HasColumnType("int");

                    b.HasKey("SalesOrderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SalesStatusId");

                    b.ToTable("SalesOrders");

                    b.HasData(
                        new
                        {
                            SalesOrderId = 1,
                            Comment = "",
                            CustomerId = 1,
                            OrderDate = new DateTime(2021, 8, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(1050),
                            SalesStatusId = 1
                        },
                        new
                        {
                            SalesOrderId = 2,
                            Comment = "Безналичная оплата",
                            CustomerId = 2,
                            OrderDate = new DateTime(2021, 7, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9753),
                            SalesStatusId = 2
                        },
                        new
                        {
                            SalesOrderId = 3,
                            Comment = "Оплата наличкой",
                            CustomerId = 3,
                            OrderDate = new DateTime(2021, 5, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9833),
                            SalesStatusId = 3
                        },
                        new
                        {
                            SalesOrderId = 4,
                            CustomerId = 1,
                            OrderDate = new DateTime(2021, 6, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9839),
                            SalesStatusId = 4
                        },
                        new
                        {
                            SalesOrderId = 5,
                            CustomerId = 2,
                            OrderDate = new DateTime(2021, 5, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9841),
                            SalesStatusId = 5
                        },
                        new
                        {
                            SalesOrderId = 6,
                            Comment = "Оплата наличкой",
                            CustomerId = 3,
                            OrderDate = new DateTime(2021, 6, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9843),
                            SalesStatusId = 6
                        },
                        new
                        {
                            SalesOrderId = 7,
                            CustomerId = 1,
                            OrderDate = new DateTime(2020, 8, 16, 15, 54, 16, 951, DateTimeKind.Local).AddTicks(9844),
                            SalesStatusId = 5
                        });
                });

            modelBuilder.Entity("TestDB.Models.SalesOrderDetail", b =>
                {
                    b.Property<int>("SalesOrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SalesOrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SalesOrderDetailId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SalesOrderId");

                    b.ToTable("SalesOrderDetails");

                    b.HasData(
                        new
                        {
                            SalesOrderDetailId = 1,
                            ModifyDate = new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1624),
                            OrderQuantity = 5,
                            ProductId = 1,
                            SalesOrderId = 1,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 2,
                            ModifyDate = new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1887),
                            OrderQuantity = 10,
                            ProductId = 2,
                            SalesOrderId = 1,
                            UnitPrice = 200m
                        },
                        new
                        {
                            SalesOrderDetailId = 3,
                            ModifyDate = new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1893),
                            OrderQuantity = 15,
                            ProductId = 3,
                            SalesOrderId = 1,
                            UnitPrice = 300m
                        },
                        new
                        {
                            SalesOrderDetailId = 4,
                            ModifyDate = new DateTime(2021, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1895),
                            OrderQuantity = 1,
                            ProductId = 4,
                            SalesOrderId = 1,
                            UnitPrice = 400m
                        },
                        new
                        {
                            SalesOrderDetailId = 5,
                            ModifyDate = new DateTime(2021, 5, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1896),
                            OrderQuantity = 2,
                            ProductId = 5,
                            SalesOrderId = 1,
                            UnitPrice = 500m
                        },
                        new
                        {
                            SalesOrderDetailId = 6,
                            ModifyDate = new DateTime(2021, 5, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1899),
                            OrderQuantity = 50,
                            ProductId = 6,
                            SalesOrderId = 1,
                            UnitPrice = 600m
                        },
                        new
                        {
                            SalesOrderDetailId = 7,
                            ModifyDate = new DateTime(2021, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1901),
                            OrderQuantity = 5,
                            ProductId = 1,
                            SalesOrderId = 2,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 8,
                            ModifyDate = new DateTime(2021, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1903),
                            OrderQuantity = 10,
                            ProductId = 2,
                            SalesOrderId = 2,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 9,
                            ModifyDate = new DateTime(2021, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1905),
                            OrderQuantity = 20,
                            ProductId = 3,
                            SalesOrderId = 2,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 10,
                            ModifyDate = new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1907),
                            OrderQuantity = 30,
                            ProductId = 1,
                            SalesOrderId = 3,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 11,
                            ModifyDate = new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1909),
                            OrderQuantity = 40,
                            ProductId = 2,
                            SalesOrderId = 3,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 12,
                            ModifyDate = new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1910),
                            OrderQuantity = 50,
                            ProductId = 5,
                            SalesOrderId = 3,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 13,
                            ModifyDate = new DateTime(2021, 7, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1912),
                            OrderQuantity = 60,
                            ProductId = 6,
                            SalesOrderId = 3,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 14,
                            ModifyDate = new DateTime(2020, 10, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1914),
                            OrderQuantity = 1,
                            ProductId = 1,
                            SalesOrderId = 4,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 15,
                            ModifyDate = new DateTime(2020, 10, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1916),
                            OrderQuantity = 10,
                            ProductId = 1,
                            SalesOrderId = 5,
                            UnitPrice = 100m
                        },
                        new
                        {
                            SalesOrderDetailId = 16,
                            ModifyDate = new DateTime(2019, 12, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1918),
                            OrderQuantity = 10,
                            ProductId = 2,
                            SalesOrderId = 5,
                            UnitPrice = 200m
                        },
                        new
                        {
                            SalesOrderDetailId = 17,
                            ModifyDate = new DateTime(2019, 2, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1920),
                            OrderQuantity = 10,
                            ProductId = 3,
                            SalesOrderId = 5,
                            UnitPrice = 300m
                        },
                        new
                        {
                            SalesOrderDetailId = 18,
                            ModifyDate = new DateTime(2018, 4, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1922),
                            OrderQuantity = 10,
                            ProductId = 4,
                            SalesOrderId = 5,
                            UnitPrice = 400m
                        },
                        new
                        {
                            SalesOrderDetailId = 19,
                            ModifyDate = new DateTime(2017, 6, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1924),
                            OrderQuantity = 10,
                            ProductId = 5,
                            SalesOrderId = 5,
                            UnitPrice = 500m
                        },
                        new
                        {
                            SalesOrderDetailId = 20,
                            ModifyDate = new DateTime(2016, 8, 16, 15, 54, 16, 952, DateTimeKind.Local).AddTicks(1925),
                            OrderQuantity = 10,
                            ProductId = 6,
                            SalesOrderId = 5,
                            UnitPrice = 600m
                        });
                });

            modelBuilder.Entity("TestDB.Models.SalesStatus", b =>
                {
                    b.Property<int>("SalesStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SalesStatusId");

                    b.ToTable("SalesStatuses");

                    b.HasData(
                        new
                        {
                            SalesStatusId = 1,
                            Name = "Создан"
                        },
                        new
                        {
                            SalesStatusId = 2,
                            Name = "Обрабатывается"
                        },
                        new
                        {
                            SalesStatusId = 3,
                            Name = "Принят"
                        },
                        new
                        {
                            SalesStatusId = 4,
                            Name = "Оплачен"
                        },
                        new
                        {
                            SalesStatusId = 5,
                            Name = "Готов к отгрузке"
                        },
                        new
                        {
                            SalesStatusId = 6,
                            Name = "Отгружен"
                        });
                });

            modelBuilder.Entity("TestDB.Models.SalesOrder", b =>
                {
                    b.HasOne("TestDB.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestDB.Models.SalesStatus", "SalesStatus")
                        .WithMany()
                        .HasForeignKey("SalesStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("SalesStatus");
                });

            modelBuilder.Entity("TestDB.Models.SalesOrderDetail", b =>
                {
                    b.HasOne("TestDB.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestDB.Models.SalesOrder", null)
                        .WithMany("SalesOrderDetails")
                        .HasForeignKey("SalesOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TestDB.Models.SalesOrder", b =>
                {
                    b.Navigation("SalesOrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}