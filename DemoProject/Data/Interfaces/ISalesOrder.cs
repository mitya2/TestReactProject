using DemoProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Interfaces
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
        int SaveSalesOrder(SalesOrder salesOrder);

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
        Task<int> SaveSalesOrderAsync(SalesOrder salesOrder);


        /// <summary>
        /// Удаляет заказ
        /// </summary>
        int DeleteSalesOrder(int id);
        
        /// <summary>
        /// Удаляет заказ (асинхронно)
        /// </summary>
        Task<int> DeleteSalesOrderAsync(int id);
    }
}
