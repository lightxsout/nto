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
    /// Контроллер для работы с таблицой
    /// </summary>
    public class TableController : Controller
    {
        /// <summary>
        /// База данных
        /// </summary>
        WaterContext db;

        /// <summary>
        /// Конструктор контроллера таблицы
        /// </summary>
        /// <param name="context"></param>
        public TableController(WaterContext context)
        {
            db = context;
        }

        /// <summary>
        /// Get метод, принимающий дату 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult HistoryTableDate()
        {
            return View();
        }

        /// <summary>
        /// Post метод, отображающий таблицу с данными, если они есть за выбраную дату 
        /// Иначе отображает таблицу с полями для ввода
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult HistoryTable(DateTime date)
        {

            var tableDate = db.Histories.FirstOrDefault(d => d.DateTime.Date == date.Date);

            if (tableDate == null)
            {
                History history = new History();
                history.DateTime = date;
                ViewBag.DateTime = date;
                return View("~/Views/Table/HistoryNew.cshtml", history);

            }

            ViewBag.DateTime = date;
            return View(tableDate);
        }

        /// <summary>
        /// Post метод, для заполнения таблицы новыми значениями и сохранием в бд
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult HistoryNew(History history)
        {
            db.Histories.Add(history);
            db.SaveChanges();
            ViewBag.DateTime = history;
            return View("~/Views/Table/HistoryTable.cshtml", history);
        }

        /// <summary>
        /// Post метод, для отображения таблицы с полями для изменения
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TableEdit(History history)
        {

            ViewBag.DateTime = history.DateTime;
            return View("~/Views/Table/TableEdit.cshtml", history);

        }

        /// <summary>
        /// Post метод, для изменения данных и сохранения в бд 
        /// и отображения таблицы с новыми данными
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public IActionResult HistoryTableEdit(History history)
        {

            db.Histories.Update(history);
            db.SaveChanges();
            ViewBag.DateTime = history.DateTime;
            return View("~/Views/Table/HistoryTable.cshtml", history);
        }
    }
}