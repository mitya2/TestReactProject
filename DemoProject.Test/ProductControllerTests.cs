using NUnit.Framework;
using FakeItEasy;
using System.Threading.Tasks;
using DemoProject.Controllers;
using DemoProject.Interfaces;
using DemoProject.Repositories;
using DemoProject.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Collections.Generic;
using DemoProject.Service;

namespace TestTB.TestProject
{
    [TestFixture]
    public class ProductControllerTests
    {
        ProductsController controller;
        IProducts dataStore;
        DbContextOptionsBuilder<AppDBContext> optionsBuilder;

        [SetUp]
        public void Setup()
        {
            optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Database=VODB; MultipleActiveResultSets=True; Trusted_Connection=True;");
            //AppDBContext dbContext = new AppDBContext(optionsBuilder.Options);

            /*int productsCount = 5;

            // создаем фейковый контекст БД
            dataStore = A.Fake<IProducts>();
            // создаем фейковую выборку объектов
            IQueryable<Product> fakeProducts = A.CollectionOfDummy<Product>(productsCount).AsQueryable();


            fakeProducts.First();
            for (int i = 0; i < 5; i++)
            {
                fakeProducts.ToList()[i].ProductId = i + 1;
                fakeProducts.ToList()[i].Name = "Продукт " + i.ToString();
                fakeProducts.ToList()[i].Price = i * 100;
            }

            // связываем данные с контроллром
            A.CallTo(() => dataStore.GetProductsAsync()).Returns(Task.FromResult(fakeProducts));
            controller = new ProductsController(dataStore);*/
        }

        [Test]
        public async Task GetProducts()
        {
            using (AppDBContext dbContext = new AppDBContext(optionsBuilder.Options))
            {
                controller = new ProductsController(dbContext as IProducts);

                // выполняем тестируемый метод
                var actionResult = await controller.GetProducts();
                var okResult = actionResult.Result as OkObjectResult;
                IQueryable<Product> products = okResult.Value as IQueryable<Product>;

                // проверяем результат
                Assert.IsNotNull(okResult);
                Assert.AreEqual(okResult.StatusCode, 200);
                Assert.AreEqual(products.Count(), 5);
            }
        }

        [Test]
        public void GetProduct_Existing()
        {
            using (AppDBContext dbContext = new AppDBContext(optionsBuilder.Options))
            {
                int product_id = 2;

                // выполняем тестируемый метод
                var actionResult = controller.GetProduct(product_id);
                var okResult = actionResult.Result as OkObjectResult;
                Product product = okResult.Value as Product;

                // проверяем результат
                Assert.IsNotNull(okResult);
                Assert.AreEqual(okResult.StatusCode, 200);
                Assert.IsNotNull(product);
                Assert.AreEqual(product.ProductId, product_id);
            }
        }

    }
}
