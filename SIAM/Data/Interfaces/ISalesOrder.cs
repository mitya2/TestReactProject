using TestDB.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TestDB.Data.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с заказами
    /// </summary>
    public interface ISalesOrders
    {
        /// <summary>
        /// Возвращает все заказы
        /// </summary>
        IQueryable<SalesOrder> GetSalesOrders();

        /// <summary>
        /// Возвращает заказ
        /// </summary>
        SalesOrder GetSalesOrder(int id);

        /// <summary>
        /// Изменяет или добавляет заказ
        /// </summary>
        void SaveSalesOrder(SalesOrder salesOrder);

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        void DeleteSalesOrder(int id);

        /// <summary>
        /// Возвращает все заказы (асинхронно)
        /// </summary>
        Task<IQueryable<SalesOrder>> GetSalesOrdersAsync();

        /// <summary>
        /// Возвращает заказ (асинхронно)
        /// </summary>
        Task<SalesOrder> GetSalesOrderAsync(int id);

        /// <summary>
        /// Изменяет или добавляет заказ (асинхронно)
        /// </summary>
        Task SaveSalesOrderAsync(SalesOrder salesOrder);

        /// <summary>
        /// Удаляет заказ (асинхронно)
        /// </summary>
        Task DeleteSalesOrderAsync(int id);
    }
}
