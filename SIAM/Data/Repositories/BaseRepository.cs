using SIAM.Models;

namespace SIAM.Data.Repositories
{
    /// <summary>
    /// Базовый класс репозитория
    /// </summary>
    public class BaseRepository
    {
        //ссылка на контект БД 
        protected readonly AppDBContext appDBContext;

        public BaseRepository(AppDBContext appDBContext)
        {
            //внедляем зависимость контектса БД
            this.appDBContext = appDBContext;
        }

    }
}
