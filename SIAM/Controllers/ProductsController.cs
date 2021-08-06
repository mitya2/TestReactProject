using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDB.Interfaces;
using TestDB.Models;

namespace TestDB.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _productsRep;

        public ProductsController(IProducts ProductsRep)
        {
            _productsRep = ProductsRep;
        }

        [HttpGet("products")]
        public async Task<IQueryable<Product>> GetProducts()
        {
            return await _productsRep.GetProductsAsync();
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productsRep.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpDelete("products/{id}")]
        public async Task DeleteProduct(int id)
        {
            await _productsRep.DeleteProductAsync(id);
        }

        [HttpPost("products")]
        public async Task UpdateProduct(Product product)
        {
            await _productsRep.SaveProductAsync(product);
        }
    }
}
