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
    public class SalesStatusesController : ControllerBase
    {
        private readonly ISalesStatuses _salesStatusesRep;

        public SalesStatusesController(ISalesStatuses SalesStatusesRep)
        {
            _salesStatusesRep = SalesStatusesRep;
        }

        [HttpGet("sales_statuses")]
        public async Task<IEnumerable<SalesStatus>> GetSalesStatuses()
        {
            return await _salesStatusesRep.GetSalesStatusesAsync();
        }

        [HttpGet("sales_statuses/{id}")]
        public async Task<ActionResult<SalesStatus>> GetSalesStatus(int id)
        {
            var salesStatus = await _salesStatusesRep.GetSalesStatusAsync(id);

            if (salesStatus == null)
            {
                return NotFound();
            }
            return salesStatus;
        }
    }
}
