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
        /// Возвращает продукт
        /// </summary>
        Product GetProduct(int id);

        /// <summary>
        /// Возвращает продукт (асинхронно)
        /// </summary>
        Task<Product> GetProductAsync(int id);

        /// <summary>
        /// Возвращает все продукты
        /// </summary>
        IQueryable<Product> GetProducts();

        /// <summary>
        /// Возвращает все продукты (асинхронно)
        /// </summary>
        Task<IQueryable<Product>> GetProductsAsync();

        /// <summary>
        /// Изменяет или добавляет продукт
        /// </summary>
        void SaveProduct(Product product);

        /// <summary>
        /// Изменяет или добавляет продкт (асинхронно)
        /// </summary>
        Task SaveProductAsync(Product product);


        /// <summary>
        /// Удаляет продукт
        /// </summary>
        void DeleteProduct(int id);

        /// <summary>
        /// Удаляет продукт (асинхронно)
        /// </summary>
        Task DeleteProductAsync(int id);
    }
}
