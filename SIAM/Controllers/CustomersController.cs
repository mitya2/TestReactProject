using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDB.Data.Interfaces;
using TestDB.Data.Models;

namespace TestDB.Controllers
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

        [HttpGet("customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customersRep.GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
    }
}
