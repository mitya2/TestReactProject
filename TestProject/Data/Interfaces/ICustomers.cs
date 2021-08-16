using TestDB.Models;
using System.Threading.Tasks;
using System.Linq;

namespace TestDB.Interfaces
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


        /// <summary>
        /// Возвращает всех клиентов
        /// </summary>
       IQueryable<Customer> GetCustomers();

        /// <summary>
        /// Возвращает всех клиентов (асинхронно)
        /// </summary>
        Task<IQueryable<Customer>> GetCustomersAsync();

    }
}
