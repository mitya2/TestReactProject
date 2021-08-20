using Microsoft.EntityFrameworkCore;
using DemoProject.Interfaces;
using DemoProject.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Repositories
{
    /// <summary>
    /// Репозиторий для работы со статусами заказа
    /// </summary>
    public class SalesStatusesRepository : BaseRepository, ISalesStatuses
    {
        public SalesStatusesRepository(AppDBContext appDBContext):base(appDBContext)  {  }

        // Реализация интерфейса ISalesStatuses
        #region
        public IQueryable<SalesStatus> GetSalesStatuses()
        {
            return appDBContext.SalesStatuses.AsQueryable(); 
        }

        public SalesStatus GetSalesStatus(int id)
        {
            return appDBContext.SalesStatuses.FirstOrDefault(s => s.SalesStatusId == id);
        }

        public async Task<IQueryable<SalesStatus>> GetSalesStatusesAsync()
        {
            return (await appDBContext.SalesStatuses.ToListAsync()).AsQueryable();
        }

        public async Task<SalesStatus> GetSalesStatusAsync(int id)
        {
            return await appDBContext.SalesStatuses.FirstOrDefaultAsync(s => s.SalesStatusId == id);
        }
        #endregion
    }
}
