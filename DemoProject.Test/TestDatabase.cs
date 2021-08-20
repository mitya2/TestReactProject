using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoProject.Models;

namespace DemoProject.Test
{
    public class TestDatabase : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;

        public DbConnection Connection { get; }

        public TestDatabase()
        {
            // создаем подклчение к тестовой базе данных
            Connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;Database=VODBTest;Trusted_Connection=True");

            // наполняем данными согласно текущей модели
            InitTstDatabase();

            Connection.Open();
        }

        public AppDBContext CreateContext(DbTransaction transaction = null)
        {
            var context = new AppDBContext(new DbContextOptionsBuilder<AppDBContext>().UseSqlServer(Connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }

        private void InitTstDatabase()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public void Dispose() => Connection.Dispose();
    }
}
