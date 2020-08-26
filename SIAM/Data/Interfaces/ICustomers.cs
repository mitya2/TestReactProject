using SIAM.Data.Models;
using System.Threading.Tasks;

namespace SIAM.Data.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с клиентами
    /// </summary>
    public interface ICustomers
    {
        /// <summary>
        /// Возвращает клиента
        /// </summary>
        Customer GetCustomer(int id);

        /// <summary>
        /// Возвращает клиента (асинхронно)
        /// </summary>
        Task<Customer> GetCustomerAsync(int id);
    }
}
