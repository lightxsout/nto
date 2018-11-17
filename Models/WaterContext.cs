using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WaterHistoryApp.Models
{
    public class WaterContext : DbContext
    {
        /// <summary>
        /// Модель класса History
        /// Поля: int HistoryId, string Name, string Season, string NumberEmployees,  
        /// string DayWeek, string PreviouDay, string TimeDelivery, string NumberPumps,
        /// string NumberRepeir, string Vending, string WorkingHours, string UncertainReasons,
        ///  string TemperatureConditions,  int Quantity, DateTime DateTime
        /// </summary>
        public virtual DbSet<History> Histories { get; set; }

        /// <summary>
        /// Конструктор WaterContext с аргументом DbContextOptions<WaterContext>
        /// </summary>
        public WaterContext(DbContextOptions<WaterContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
