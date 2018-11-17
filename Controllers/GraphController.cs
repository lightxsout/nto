using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WaterHistoryApp.Models; // пространство имен WaterContext

namespace WaterHistoryApp.Controllers
{
    /// <summary>
    /// Контроллер для работы с графиком
    /// </summary>
    public class GraphController : Controller
    {
        /// <summary>
        /// База данных
        /// </summary>
        WaterContext db;

        /// <summary>
        /// Конструктор контроллера графика
        /// </summary>
        /// <param name="context"></param>
        public GraphController(WaterContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get метод, принимающий дату для отображения графика
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GraphDate()
        {
            return View();
        }

        /// <summary>
        /// Post метод, отображающий график при наличии данных за выбраный месяц
        /// eсли их нет - отображает страницу с предупреждением и ссылкой на таблицу с просьбой заполнить данные 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public  IActionResult Graph(DateTime date)
        {

            var dateGraph = db.Histories.Where(h => h.DateTime.Month == date.Date.Month && h.DateTime.Year == date.Date.Year).OrderBy(d => d.DateTime);

            if (dateGraph.Count() == 0)
            {
                return View("~/Views/Graph/GraphNull.cshtml");
            }

            ViewBag.DateTime = date;
            ViewBag.Quantity = dateGraph.Select(s => s.Quantity);
            ViewBag.Dates = dateGraph.Select(s => s.DateTime);
            return View("~/Views/Graph/Graph.cshtml", dateGraph);

        }
    }
}