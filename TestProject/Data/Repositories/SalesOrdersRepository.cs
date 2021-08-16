using TestDB.Models;
using System.Linq;
using TestDB.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TestDB.Repositories
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
            return appDBContext.SalesOrders.Include(s => s.Customer).Include(s=>s.SalesStatus).OrderByDescending(s => s.SalesOrderId);
        }

        public void DeleteSalesOrder(int id)
        {
            appDBContext.Remove(new SalesOrder { SalesOrderId = id });
            appDBContext.SaveChanges();
        }

        public SalesOrder GetSalesOrder(int id)
        {
            return appDBContext.SalesOrders.Include(s => s.Customer)
                                           .Include(s => s.SalesStatus)
                                           .Include(s => s.SalesOrderDetails)
                                           .ThenInclude(x => x.Product)
                                           .FirstOrDefault(s => s.SalesOrderId == id);
        }

        public void SaveSalesOrder(SalesOrder salesOrder)
        {
            if (salesOrder.SalesOrderId == default)
                appDBContext.Entry(salesOrder).State = EntityState.Added;
            else
                appDBContext.Entry(salesOrder).State = EntityState.Modified;

            appDBContext.SalesOrderDetails.RemoveRange(appDBContext.SalesOrderDetails.Where(e => e.SalesOrderId == salesOrder.SalesOrderId));
            appDBContext.SaveChanges();

            foreach (SalesOrderDetail item in salesOrder.SalesOrderDetails)
            {
                item.SalesOrderDetailId = default;
                appDBContext.Entry(item).State = EntityState.Added;
            }
            appDBContext.SaveChanges();
        }

        public async Task<IQueryable<SalesOrder>> GetSalesOrdersAsync()
        {
            return (await appDBContext.SalesOrders.Include(s => s.Customer).Include(s => s.SalesStatus).OrderByDescending(s=>s.SalesOrderId).ToListAsync()).AsQueryable();
        }

        public async Task<SalesOrder> GetSalesOrderAsync(int id)
        {
            return await appDBContext.SalesOrders.Include(s => s.Customer)
                                                 .Include(s => s.SalesStatus)
                                                 .Include(s => s.SalesOrderDetails)
                                                 .ThenInclude(x => x.Product)
                                                 .FirstOrDefaultAsync(s => s.SalesOrderId == id);
        }

        public async Task SaveSalesOrderAsync(SalesOrder salesOrder)
        {
            if (salesOrder.SalesOrderId == default)
                appDBContext.Entry(salesOrder).State = EntityState.Added;
            else
                appDBContext.Entry(salesOrder).State = EntityState.Modified;

            appDBContext.SalesOrderDetails.RemoveRange(appDBContext.SalesOrderDetails.Where(e => e.SalesOrderId == salesOrder.SalesOrderId));
            appDBContext.SaveChanges();
            
            foreach (SalesOrderDetail item in salesOrder.SalesOrderDetails)
            {
                item.SalesOrderDetailId = default;
                appDBContext.Entry(item).State = EntityState.Added;
            }

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
