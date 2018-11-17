using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WaterHistoryApp.Models; // пространство имен WaterContext

namespace WaterHistoryApp.Controllers
{
    /// <summary>
    /// Контроллер для отображения главной страницы
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Возвращает главную страницу
        /// </summary>
        public IActionResult Index()
        {
            return View("Index");
        }

    }
}

    