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
    public class SalesOrderDetailsController : ControllerBase
    {
        private readonly ISalesOrderDetails _salesOrderDetailsRep;

        public SalesOrderDetailsController(ISalesOrderDetails SalesOrderDetailsRep)
        {
            _salesOrderDetailsRep = SalesOrderDetailsRep;
        }

        [HttpGet("sales_order_details/{id}")]
        public async Task<IEnumerable<SalesOrderDetail>> GetSalesOrderDetails(int sales_order_id)
        {
            return await _salesOrderDetailsRep.GetSalesOrderDetailsAsync(sales_order_id);
        }

        [HttpGet("sales_order_detail/{id}")]
        public async Task<ActionResult<SalesOrderDetail>> GetSalesOrderDetail(int id)
        {
            var salesOrder = await _salesOrderDetailsRep.GetSalesOrderDetailAsync(id);

            if (salesOrder == null)
            {
                return NotFound();
            }
            return salesOrder;
        }

        [HttpPost("sales_order_details")]
        public async Task UpdateSalesOrderDetail(SalesOrderDetail salesOrderDetail)
        {
            await _salesOrderDetailsRep.SaveSalesOrderDetailAsync(salesOrderDetail);
        }

        [HttpDelete("sales_order_details")]
        public async Task DeleteSalesOrderDetail(int id)
        {

            await _salesOrderDetailsRep.DeleteSalesOrderDetailAsync(id);
        }
    }
}
