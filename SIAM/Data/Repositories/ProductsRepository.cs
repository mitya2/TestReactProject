using TestDB.Data.Models;
using TestDB.Models;
using System.Linq;
using TestDB.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestDB.Data.Repositories
{
    /// <summary>
    /// Репозиторий для работы с продуктами 
    /// </summary>
    public class ProductsRepository : BaseRepository, IProducts
    {
        public ProductsRepository(AppDBContext appDBContext):base(appDBContext)  {  }

        // Реализация интерфейса IProducts
        #region
        public IQueryable<Product> GetProducts()
        {
            return appDBContext.Products;
        }

        public async Task<IQueryable<Product>> GetProductsAsync()
        {
            return (await appDBContext.Products.ToListAsync()).AsQueryable();
        }

        public Product GetProduct(int id)
        {
            return appDBContext.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await appDBContext.Products.FirstOrDefaultAsync(p => p.ProductId == id);
        }
        #endregion
    }
}
