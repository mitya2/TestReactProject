using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.Interfaces;
using DemoProject.Models;

namespace DemoProject.Controllers
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

        /// <summary>
        /// Возвращает список товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productsRep.GetProductsAsync();
            if (!products.Any())
            {
                return NotFound();
            }
            return Ok(products);
        }

        /// <summary>
        /// Возвращает информацию о товаре
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns></returns>
        [HttpGet("products/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Product> GetProduct(int id)
        {
            Product product = _productsRep.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        
        /// <summary>
        /// Удаляет товар
        /// </summary>
        /// <param name="id">Идентификатор товара</param>
        /// <returns></returns>
        [HttpDelete("products/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            int result = await _productsRep.DeleteProductAsync(id);
            if (result != 1)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// Добавляет или изменяет товар
        /// </summary>
        /// <param name="product">Товар</param>
        /// <returns></returns>
        [HttpPost("products")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            int result = await _productsRep.SaveProductAsync(product);
            if (result != 1)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
