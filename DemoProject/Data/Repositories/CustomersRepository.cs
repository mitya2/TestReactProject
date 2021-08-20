using DemoProject.Interfaces;
using DemoProject.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repositories
{
    /// <summary>
    /// Репозиторий для работы с покупателями 
    /// </summary>
    public class CustomersRepository : BaseRepository, ICustomers
    {
        public CustomersRepository(AppDBContext appDBContext) : base(appDBContext) { }

        // Реализация интерфейса ICustomers
        #region

        public Customer GetCustomer(int id)
        {
            return appDBContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await appDBContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<IQueryable<Customer>> GetCustomersAsync()
        {
            return (await appDBContext.Customers.ToListAsync()).AsQueryable();
        }

        public IQueryable<Customer> GetCustomers()
        {
            return appDBContext.Customers.AsQueryable();
        }
        #endregion 

    }
}
