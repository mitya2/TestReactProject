using NUnit.Framework;
using FakeItEasy;
using System.Threading.Tasks;
using DemoProject.Controllers;
using DemoProject.Interfaces;
using DemoProject.Models;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace TestTB.TestProject
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ProductsController_GetProducts()
        {
            IProducts productsDataStore = A.Fake<IProducts>();
            var fakeProducts = A.CollectionOfDummy<Product>(5).AsQueryable();

            A.CallTo(() => productsDataStore.GetProducts()).Returns(fakeProducts);
            ProductsController controller = new ProductsController(productsDataStore);

            var ActionResult = await controller.GetProducts();
        }
    }

    internal interface IQuerable
    {
    }
}