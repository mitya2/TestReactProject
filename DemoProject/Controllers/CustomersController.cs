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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomers _customersRep;

        public CustomersController(ICustomers customersRep)
        {
            _customersRep = customersRep;
        }

        /// <summary>
        /// Возвращает информацию о покупателе
        /// </summary>
        /// <param name="id">Идентификатор покупателя</param>
        /// <returns></returns>
        [HttpGet("customers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customersRep.GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


        /// <summary>
        /// Возвращает список покупателей
        /// </summary>
        /// <returns></returns>        
        [HttpGet("customers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var customers = await _customersRep.GetCustomersAsync();
            if (!customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);
        }
    }
}
