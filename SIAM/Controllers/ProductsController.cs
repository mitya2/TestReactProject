using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIAM.Data.Interfaces;
using SIAM.Data.Models;

namespace SIAM.Controllers
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
        public async Task<IEnumerable<Product>> GetProducts()
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
    }
}
