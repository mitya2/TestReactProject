using TestDB.Models;
using System.Linq;
using TestDB.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestDB.Repositories
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

        public void DeleteProduct(int id)
        {
            appDBContext.Remove(new Product { ProductId = id });
            appDBContext.SaveChanges();
        }

        public async Task DeleteProductAsync(int id)
        {
            appDBContext.Remove(new Product { ProductId = id });
            await appDBContext.SaveChangesAsync();
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == default)
                appDBContext.Entry(product).State = EntityState.Added;
            else
                appDBContext.Entry(product).State = EntityState.Modified;
            appDBContext.SaveChanges();
        }

        public async Task SaveProductAsync(Product product)
        {
            if (product.ProductId == default)
                appDBContext.Entry(product).State = EntityState.Added;
            else
                appDBContext.Entry(product).State = EntityState.Modified;
            await appDBContext.SaveChangesAsync();
        }
        #endregion
    }
}
