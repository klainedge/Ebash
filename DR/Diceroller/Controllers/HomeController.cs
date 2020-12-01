using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Diceroller.Models;

namespace Diceroller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() // Первое открытие страницы, делается бросок 3d6, который НЕ пишется в базу
        {
            ViewData["roller"] = "Случайный бросок 3d6 (не сохраняется)";
            var rand = new Random();
            var Otvet = new DiceValues();
            Otvet.Result = new List<int> { rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7) };
            Otvet.Shas = DateTime.Now;
            Otvet.Q = 3;
            Otvet.E = 6;
            return View(Otvet);
        }

        public IActionResult Roll(int Q, int E, string Igrok)
        {
            var Otvet = new DiceValues();
            Otvet.Shas = DateTime.Now;
            List<int> Drop = new List<int>();
            if (Q < 1) // Проверяем, что количество количество кубиков
            {
                ViewData["roller"] = "Для броска нужно взять хотя бы 1 кость";
                Drop.Add(0);
                Otvet.Result = Drop;
                Otvet.Q = 3;
                Otvet.E = 6;
                return View("Index", Otvet);
            }
            else if (E < 2) // Проверяем, что количество количество граней
            {
                ViewData["roller"] = "Минимальное количество граней для эмуляции у монетки и равно 2. Максимальное кость с 999 граням";
                Drop.Add(0);
                Otvet.Result = Drop;
                Otvet.Q = 3;
                Otvet.E = 6;
                return View("Index", Otvet);
            }
            if (Igrok != null) // Проверяем, что указано имя игрока
            {   ViewData["roller"] = $"{Igrok}, Ваш случайный бросок {Q}d{E} (сохранён)";   }
            else
            {   ViewData["roller"] = $"Ваш случайный бросок {Q}d{E} (сохранён)";    }
            float S = (Q * ((float)(E + 1) / 2));  // Считаем средний бросок
            var rand = new Random();
            int Summa = 0;
            for (int ctr = 0; ctr < Q; ctr++) // Собираем кубики для броска и кидаем в цикле
            {
                Otvet.Y = rand.Next(1, E + 1);
                Summa = Summa + Otvet.Y;
                Drop.Add(Otvet.Y);
                using (ApplicationContext db = new ApplicationContext())  // Записываем каждый кубик в базу данных
                {
                    toSQL toDB = new toSQL { RollTime = DateTime.Now, RollResult = Otvet.Y, DiceInRoll = Q, EdgeCount = E, Player = Igrok };
                    db.DiceDB.Add(toDB);
                    db.SaveChanges();
                }
            }
            // Собираем данные для представления (для случая, когда все данные адекватны)
            Otvet.Result = Drop;
            Otvet.Shas = DateTime.Now;
            Otvet.Avg = $"Получилось {Summa}. {S} – среднее значение выпадения при количестве кубиков {Q} и количестве граней {E}";
            Otvet.Q = Q;
            Otvet.E = E;
            Otvet.Player = Igrok;
            return View("Index", Otvet);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RollList()  // Забираем данные из SQL
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var fromSQL = db.DiceDB.OrderByDescending(x=>x.RollTime).Take(100).ToList();
                return View(fromSQL);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
