using TestDB.Models;

namespace TestDB.Repositories
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
