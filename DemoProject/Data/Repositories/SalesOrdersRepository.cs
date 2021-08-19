using DemoProject.Models;
using System.Linq;
using DemoProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DemoProject.Repositories
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

        public int DeleteSalesOrder(int id)
        {
            try
            {
                appDBContext.Remove(new SalesOrder { SalesOrderId = id });
                return appDBContext.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

        public SalesOrder GetSalesOrder(int id)
        {
            return appDBContext.SalesOrders.Include(s => s.Customer)
                                           .Include(s => s.SalesStatus)
                                           .Include(s => s.SalesOrderDetails)
                                           .ThenInclude(x => x.Product)
                                           .FirstOrDefault(s => s.SalesOrderId == id);
        }

        public int SaveSalesOrder(SalesOrder salesOrder)
        {
            try
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
                return appDBContext.SaveChanges();
            }
            catch
            {
                return 0;
            }
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

        public async Task<int> SaveSalesOrderAsync(SalesOrder salesOrder)
        {
            try
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

                return await appDBContext.SaveChangesAsync();
            } 
            catch
            {
                return 0;
            }
        }

        public async Task<int> DeleteSalesOrderAsync(int id)
        {
            try
            {
                appDBContext.Remove(new SalesOrder { SalesOrderId = id });
                return await appDBContext.SaveChangesAsync();
            } catch
            {
                return 0;
            }
        }
        #endregion
    }
}
