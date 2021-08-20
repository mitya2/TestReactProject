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
using Moq;
using System.Net;
using System.Collections.Generic;
using DemoProject.Service;
using DemoProject.Test;

namespace TestDB.TestProject
{
    [TestFixture]
    public class ProductControllerTests
    {
        TestDatabase testDatabase;

        [OneTimeSetUp]
        public void Setup()
        {
            testDatabase = new TestDatabase();
        }

        [Test]
        public async Task GetProducts_Success()
        {
            int products_count = 14; // 14 записей согласно начальному значению модели
           
            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.GetProducts();
                    var result = actionResult.Result as OkObjectResult;

                    // провер€ем результат
                    Assert.IsNotNull(result);
                    Assert.AreEqual(result.StatusCode, 200);
                    Assert.AreEqual((result.Value as IQueryable<Product>).Count(), products_count);
                }
            }
        }

        [Test]
        public async Task GetProduct_Success()
        {
            int product_id = 1; // от 1 до 14

            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.GetProduct(product_id);
                    var result = actionResult.Result as OkObjectResult;

                    // провер€ем результат
                    Assert.IsNotNull(result);
                    Assert.AreEqual(result.StatusCode, 200);
                    
                    Assert.IsNotNull(result.Value);
                    if (result.Value != null)
                    {
                        Assert.AreEqual((result.Value as Product).ProductId, product_id);
                    }
                }
            }
        }

        [Test]
        public async Task GetProduct_UnSuccess()
        {
            int product_id = 44; // больше 14

            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.GetProduct(product_id);
                    var result = actionResult.Result as NotFoundResult;

                    // провер€ем результат
                    Assert.IsNotNull(result);
                    Assert.AreEqual(result.StatusCode, 404);
                }
            }
        }

        [Test]
        public async Task UpdateProduct_Update_Success()
        {
            int product_id = 10;
            Product product = new Product() { ProductId = product_id, Comment = "“ест", Name = "“ест", Price = 50 };

            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.UpdateProduct(product);
                    var result = actionResult as OkResult;

                    // провер€ем результат
                    Assert.IsNotNull(actionResult);
                    Assert.AreEqual(result.StatusCode, 200);


                    // выполн€ем тестируемый метод
                    var actionResult2 = await controller.GetProduct(product_id);
                    var result2 = actionResult2.Result as OkObjectResult;

                    // провер€ем результат
                    Assert.IsNotNull(result2);
                    Assert.AreEqual(result2.StatusCode, 200);

                    Assert.IsNotNull(result2.Value);
                    if (result2.Value != null)
                    {
                        Assert.AreEqual((result2.Value as Product).Comment, "“ест");
                    }

                }
            }
        }

        [Test]
        public async Task UpdateProduct_Update_UnSuccess()
        {
            int product_id = 100;
            Product product = new Product() { ProductId = product_id, Comment = "“ест", Name = "“ест", Price = 50 };

            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.UpdateProduct(product);
                    var result = actionResult as NotFoundResult;

                    // провер€ем результат
                    Assert.IsNotNull(actionResult);
                    Assert.AreEqual(result.StatusCode, 404);
                }
            }
        }

        [Test]
        public async Task UpdateProduct_Add_Success()
        {
            int products_count = 14; // 14 записей согласно начальному значению модели
            int products_id = default(int);
            Product product = new Product() {ProductId = products_id, Comment = "“ест", Name = "“ест", Price = 50 };

            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.UpdateProduct(product);
                    var result = actionResult as OkResult;

                    // провер€ем результат
                    Assert.IsNotNull(actionResult);
                    Assert.AreEqual(result.StatusCode, 200);


                    // выполн€ем тестируемый метод
                    var actionResult2 = await controller.GetProducts();
                    var result2 = actionResult2.Result as OkObjectResult;

                    // провер€ем результат
                    // провер€ем результат
                    Assert.IsNotNull(result2);
                    Assert.AreEqual(result2.StatusCode, 200);
                    Assert.AreEqual((result2.Value as IQueryable<Product>).Count(), products_count+1); // провер€ем на увеличение количества записей
                }
            }
        }

        [Test]
        public async Task UpdateProduct_Add_UnSuccess()
        {
            int products_id = 15;
            Product product = new Product() { ProductId = products_id, Comment = "“ест", Name = "“ест", Price = 50 };

            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.UpdateProduct(product);
                    var result = actionResult as NotFoundResult;

                    // провер€ем результат
                    Assert.IsNotNull(actionResult);
                    Assert.AreEqual(result.StatusCode, 404);
                }
            }
        }


        [Test]
        public async Task DeleteProduct_UnSuccess()
        {
            int products_id = 15;

            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.DeleteProduct(products_id);
                    var result = actionResult as NotFoundResult;

                    // провер€ем результат
                    Assert.IsNotNull(actionResult);
                    Assert.AreEqual(result.StatusCode, 404);
                }
            }
        }

        [Test]
        public async Task DeleteProduct_Success()
        {
            int product_id = 10;
            using (var transaction = testDatabase.Connection.BeginTransaction())
            {
                using (var context = testDatabase.CreateContext(transaction))
                {
                    IProducts productsRepository = new ProductsRepository(context);
                    ProductsController controller = new ProductsController(productsRepository);

                    // выполн€ем тестируемый метод
                    var actionResult = await controller.DeleteProduct(product_id);
                    var result = actionResult as OkResult;

                    // провер€ем результат
                    Assert.IsNotNull(actionResult);
                    Assert.AreEqual(result.StatusCode, 200);
                }
            }
        }
    }
}
