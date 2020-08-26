using SIAM.Data.Interfaces;
using SIAM.Data.Models;
using SIAM.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SIAM.Data.Repositories
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
        #endregion 

    }
}
