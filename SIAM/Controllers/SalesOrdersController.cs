using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDB.Interfaces;
using TestDB.Models;

namespace TestDB.Controllers
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

        [HttpGet("sales_orders")]
        public async Task<IEnumerable<SalesOrder>> GetSalesOrders()
        {
            return await _salesOrdersRep.GetSalesOrdersAsync();
        }

        [HttpGet("sales_orders/{id}")]
        public async Task<ActionResult<SalesOrder>> GetSalesOrder(int id)
        {
            var salesOrder = await _salesOrdersRep.GetSalesOrderAsync(id);

            if (salesOrder == null)
            {
                return NotFound();
            }
            return salesOrder;
        }

        [HttpPost("sales_orders")]
        public async Task UpdateSalesOrder(SalesOrder salesOrder)
        {
            await _salesOrdersRep.SaveSalesOrderAsync(salesOrder);
        }

        [HttpDelete("sales_orders/{id}")]
        public async Task DeleteSalesOrderDetail(int id)
        {
            await _salesOrdersRep.DeleteSalesOrderAsync(id);
        }
    }
}
