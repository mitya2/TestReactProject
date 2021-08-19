using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.Interfaces;
using DemoProject.Models;

namespace DemoProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class SalesOrdersController : ControllerBase
    {
        private readonly ISalesOrders _salesOrdersRep;

        public SalesOrdersController(ISalesOrders SalesOrdersRep)
        {
            _salesOrdersRep = SalesOrdersRep;
        }
        /// <summary>
        /// Возвращает список заказов
        /// </summary>
        /// <returns></returns>
        [HttpGet("sales_orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SalesOrder>>> GetSalesOrders()
        {
            var salesOrders = await _salesOrdersRep.GetSalesOrdersAsync();
            if (!salesOrders.Any())
            {
                return NotFound();
            }
            return Ok(salesOrders);
        }

        /// <summary>
        /// Возвращает информацию о заказе
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <returns></returns>
        [HttpGet("sales_orders/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesOrder>> GetSalesOrder(int id)
        {
            var salesOrder = await _salesOrdersRep.GetSalesOrderAsync(id);

            if (salesOrder == null)
            {
                return NotFound();
            }
            return Ok(salesOrder);
        }

        /// <summary>
        /// Добавляет или изменяет заказ
        /// </summary>
        /// <param name="salesOrder">Заказ</param>
        /// <returns></returns>
        [HttpPost("sales_orders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> UpdateSalesOrder(SalesOrder salesOrder)
        {
            int result = await _salesOrdersRep.SaveSalesOrderAsync(salesOrder);
            if (result != 1)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="id">Идентификатор заказа</param>
        /// <returns></returns>
        [HttpDelete("sales_orders/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> DeleteSalesOrderDetail(int id)
        {
            int result = await _salesOrdersRep.DeleteSalesOrderAsync(id);
            if (result != 1)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
