using DemoProject.Models;
using System.Linq;
using DemoProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DemoProject.Repositories
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

        public int DeleteProduct(int id)
        {
            try
            {
                appDBContext.Remove(new Product { ProductId = id });
                return appDBContext.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            try
            {
                appDBContext.Remove(new Product { ProductId = id });
                return await appDBContext.SaveChangesAsync();
            }
            catch
            {
                return 0;
            }
        }

        public int SaveProduct(Product product)
        {
            try
            {
                if (product.ProductId == default)
                    appDBContext.Entry(product).State = EntityState.Added;
                else
                    appDBContext.Entry(product).State = EntityState.Modified;
                return appDBContext.SaveChanges();
            } catch
            {
                return 0;
            }
        }

        public async Task<int> SaveProductAsync(Product product)
        {
            try
            {
                if (product.ProductId == default)
                    appDBContext.Entry(product).State = EntityState.Added;
                else
                    appDBContext.Entry(product).State = EntityState.Modified;
                return await appDBContext.SaveChangesAsync();
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
