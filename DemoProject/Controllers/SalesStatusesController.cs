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
    public class SalesStatusesController : ControllerBase
    {
        private readonly ISalesStatuses _salesStatusesRep;

        public SalesStatusesController(ISalesStatuses SalesStatusesRep)
        {
            _salesStatusesRep = SalesStatusesRep;
        }

        /// <summary>
        /// Возвращает список статусов заказа
        /// </summary>
        /// <returns></returns>
        [HttpGet("sales_statuses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<SalesStatus>>> GetSalesStatuses()
        {
            var salesStatuses = await _salesStatusesRep.GetSalesStatusesAsync();
            if (!salesStatuses.Any())
            {
                return NotFound();
            }
            return Ok(salesStatuses);
        }

        /// <summary>
        /// Возвращает информацию о статусе заказа
        /// </summary>
        /// <param name="id">Идентификатор статуса заказа</param>
        /// <returns></returns>
        [HttpGet("sales_statuses/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SalesStatus>> GetSalesStatus(int id)
        {
            var salesStatus = await _salesStatusesRep.GetSalesStatusAsync(id);

             if (salesStatus == null)
            {
                return NotFound();
            }
            return Ok(salesStatus);
        }
    }
}
