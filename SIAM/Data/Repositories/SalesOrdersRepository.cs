using TestDB.Data.Models;
using TestDB.Models;
using System.Linq;
using TestDB.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestDB.Data.Repositories
{
    /// <summary>
    /// Репозиторий для работы с заказом
    /// </summary>
    public class SalesOrdersRepository : BaseRepository, ISalesOrders
    {
        public SalesOrdersRepository(AppDBContext appDBContext):base(appDBContext)  {  }

        // Реализация интерфейса ISalesOrders
        #region
        public IQueryable<SalesOrder> GetSalesOrders()
        {
            return appDBContext.SalesOrders.Include(s => s.Customer).Include(s=>s.SalesStatus);
        }

        public void DeleteSalesOrder(int id)
        {
            appDBContext.Remove(new SalesOrder { SalesOrderId = id });
            appDBContext.SaveChanges();
        }

        public SalesOrder GetSalesOrder(int id)
        {
            return appDBContext.SalesOrders .Include(s => s.Customer)
                                            .Include(s => s.SalesStatus)
                                            .FirstOrDefault(s => s.SalesOrderId == id);
        }

        public void SaveSalesOrder(SalesOrder salesOrder)
        {
            if (salesOrder.SalesOrderId == default)
                appDBContext.Entry(salesOrder).State = EntityState.Added;
            else
                appDBContext.Entry(salesOrder).State = EntityState.Modified;
            appDBContext.SaveChanges();
        }

        public async Task<IQueryable<SalesOrder>> GetSalesOrdersAsync()
        {
            return (await appDBContext.SalesOrders.Include(s => s.Customer).Include(s => s.SalesStatus).ToListAsync()).AsQueryable();
        }

        public async Task<SalesOrder> GetSalesOrderAsync(int id)
        {
            return await appDBContext.SalesOrders.Include(s => s.Customer).Include(s => s.SalesStatus).FirstOrDefaultAsync(s => s.SalesOrderId == id);
        }

        public async Task SaveSalesOrderAsync(SalesOrder salesOrder)
        {
            if (salesOrder.SalesOrderId == default)
                appDBContext.Entry(salesOrder).State = EntityState.Added;
            else
                appDBContext.Entry(salesOrder).State = EntityState.Modified;
            await appDBContext.SaveChangesAsync();
        }

        public async Task DeleteSalesOrderAsync(int id)
        {
            appDBContext.Remove(new SalesOrder { SalesOrderId = id });
            await appDBContext.SaveChangesAsync();
        }
        #endregion
    }
}
