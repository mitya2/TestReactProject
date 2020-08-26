using SIAM.Data.Models;
using SIAM.Models;
using System.Linq;
using SIAM.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SIAM.Data.Repositories
{
    /// <summary>
    /// Репозиторий для работы с позициями заказа
    /// </summary>
    public class SalesOrderDetailsRepository : BaseRepository, ISalesOrderDetails
    {
        public SalesOrderDetailsRepository(AppDBContext appDBContext):base(appDBContext)  {  }

        // Реализация интерфейса ISalesOrderDetails
        #region
        public IQueryable<SalesOrderDetail> GetSalesOrderDetails(int SalesOrderId)
        {
            return appDBContext.SalesOrderDetails.Where(s => s.SalesOrderId == SalesOrderId).Include(s => s.Product);
        }

        public void DeleteSalesOrderDetail(int id)
        {
            appDBContext.Remove(new SalesOrderDetail { Id = id });
            appDBContext.SaveChanges();
        }

        public SalesOrderDetail GetSalesOrderDetail(int id)
        {
            return appDBContext.SalesOrderDetails.Include(s => s.Product).FirstOrDefault(s => s.Id == id);
        }

        public void SaveSalesOrderDetail(SalesOrderDetail salesOrderDetail)
        {
            if (salesOrderDetail.Id == default)
                appDBContext.Entry(salesOrderDetail).State = EntityState.Added;
            else
                appDBContext.Entry(salesOrderDetail).State = EntityState.Modified;
            appDBContext.SaveChanges();
        }

        public async Task<IQueryable<SalesOrderDetail>> GetSalesOrderDetailsAsync(int SalesOrderId)
        {
            return (await appDBContext.SalesOrderDetails.Where(s => s.SalesOrderId == SalesOrderId).Include(s => s.Product).ToListAsync()).AsQueryable();
        }

        public async Task<SalesOrderDetail> GetSalesOrderDetailAsync(int id)
        {
            return await appDBContext.SalesOrderDetails.Include(s => s.Product).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task SaveSalesOrderDetailAsync(SalesOrderDetail salesOrderDetail)
        {
            if (salesOrderDetail.Id == default)
                appDBContext.Entry(salesOrderDetail).State = EntityState.Added;
            else
                appDBContext.Entry(salesOrderDetail).State = EntityState.Modified;
            await appDBContext.SaveChangesAsync();
        }

        public async Task DeleteSalesOrderDetailAsync(int id)
        {
            appDBContext.Remove(new SalesOrderDetail { Id = id });
            await appDBContext.SaveChangesAsync();
        }
        #endregion
    }
}
