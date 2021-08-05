using TestDB.Models;
using System.Linq;
using System.Threading.Tasks;

namespace TestDB.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с продуктами
    /// </summary>
    public interface IProducts
    {
        /// <summary>
        /// Возвращает все продукты
        /// </summary>
        IQueryable<Product> GetProducts();

        /// <summary>
        /// Возвращает продукт
        /// </summary>
        Product GetProduct(int id);

        /// <summary>
        /// Возвращает все продукты (асинхронно)
        /// </summary>
        Task<IQueryable<Product>> GetProductsAsync();

        /// <summary>
        /// Возвращает продукт (асинхронно)
        /// </summary>
        Task<Product> GetProductAsync(int id);


    }
}
