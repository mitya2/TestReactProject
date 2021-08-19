using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Service
{
    /// <summary>
    /// Клас конфигурации сервиса
    /// </summary>
    public class Config
    {
        public static string ConnectionString { get; set; }
        public static string ProjectName { get; set; }
        public static string Title { get; set; }
    }
}
