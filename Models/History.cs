using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterHistoryApp.Models
{
    /// <summary>
    /// Модель класса History
    /// Поля: int HistoryId, string Name, string Season, string NumberEmployees,  
    /// string DayWeek, string PreviouDay, string TimeDelivery, string NumberPumps,
    /// string NumberRepeir, string Vending, string WorkingHours, string UncertainReasons,
    ///  string TemperatureConditions,  int Quantity, DateTime DateTime
    /// </summary>
    public class History
    {
        public virtual int HistoryId { get; set; }
        public virtual string Season { get; set; }
        public virtual string NumberEmployees { get; set; }
        public virtual string DayWeek { get; set; }
        public virtual string PreviouDay { get; set; }
        public virtual string TimeDelivery { get; set; }
        public virtual string NumberPumps { get; set; }
        public virtual string NumberRepeir { get; set; }
        public virtual string Vending { get; set; }
        public virtual string WorkingHours { get; set; }
        public virtual string UncertainReasons { get; set; }
        public virtual string TemperatureConditions { get; set; }
        public virtual int Quantity { get; set; }
        public virtual DateTime DateTime { get; set; }


    }
}
