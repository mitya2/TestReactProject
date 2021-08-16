using TestDB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TestDB.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с позициями заказа
    /// </summary>
    public interface ISalesOrderDetails
    {
        /// <summary>
        /// Возвращает все позиции заказа
        /// </summary>
        IQueryable<SalesOrderDetail> GetSalesOrderDetails(int SalesOrderId);

        /// <summary>
        /// Возвращает позицию заказа
        /// </summary>
        SalesOrderDetail GetSalesOrderDetail(int id);

        /// <summary>
        /// Изменяет или добавлет позицию заказа 
        /// </summary>
        void SaveSalesOrderDetail(SalesOrderDetail salesOrderDetail);

        /// <summary>
        /// Удаляет позицию заказа 
        /// </summary>
        void DeleteSalesOrderDetail(int id);

        /// <summary>
        /// Возвращает все позиции заказа (асинхронно)
        /// </summary>
        Task<IQueryable<SalesOrderDetail>> GetSalesOrderDetailsAsync(int SalesOrderId);

        /// <summary>
        /// Возвращает позицию заказа (асинхронно)
        /// </summary>
        Task<SalesOrderDetail> GetSalesOrderDetailAsync(int id);

        /// <summary>
        /// Изменяет или добавлет позицию заказа (асинхронно)
        /// </summary>
        Task SaveSalesOrderDetailAsync(SalesOrderDetail salesOrderDetail);

        /// <summary>
        /// Удаляет позицию заказа (асинхронно)
        /// </summary>
        Task DeleteSalesOrderDetailAsync(int id);
    }
}
