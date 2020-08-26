using SIAM.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SIAM.Data.Interfaces
{
    /// <summary>
    /// Интерфейс для работы со статусами заказов
    /// </summary>
    public interface ISalesStatuses
    {
        /// <summary>
        /// Возвращает все статусы заказа
        /// </summary>
        IQueryable<SalesStatus> GetSalesStatuses();

        /// <summary>
        /// Возвращает статус заказа
        /// </summary>
        SalesStatus GetSalesStatus(int id);

        /// <summary>
        /// Возвращает все статусы заказа (асинхронно)
        /// </summary>
        Task<IQueryable<SalesStatus>> GetSalesStatusesAsync();

        /// <summary>
        /// Возвращает статус заказа (асинхронно)
        /// </summary>
        Task<SalesStatus> GetSalesStatusAsync(int id);
    }
}
