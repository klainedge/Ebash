using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Diceroller.Models;
using System.Globalization;

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
        public IActionResult Display(int ID, string Igrok, string Password)
        {
            using (ApplicationContext db = new ApplicationContext()) // Забираем данные из SQL
            {
                IQueryable<ToSQL> query = db.DiceDB;
                if (ID < 1)
                { 
                    ID = 1;
                    ViewData["Error"] = " не найдена"; 
                }
                var Individual = query.FirstOrDefault(x => x.Id == ID);
                if (Password == "iNe3dA#th0riza71onPol1cy")
                { 
                    Individual.Player = Igrok;
                    db.SaveChanges();
                }
                return View("Display", Individual);
            }
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
                    ToSQL toDB = new ToSQL { RollTime = DateTime.Now, RollResult = Otvet.Y, DiceInRoll = Q, EdgeCount = E, Player = Igrok };
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

        public IActionResult RollList(int SkipPages, int RollsperPage, int FltrRollResult, int FltrEdgeCount, int FltrDiceInRoll, string FltrRollTime, string FltrPlayer)  
        {
            using (ApplicationContext db = new ApplicationContext()) // Забираем данные из SQL
            {
                IQueryable <ToSQL> query = db.DiceDB;
                if  (FltrPlayer != null)
                {
                    query = query.Where(p => p.Player.Contains($"{FltrPlayer}"));
                    ViewData["FltrPlayer"] = FltrPlayer; 
                }
                if (FltrRollResult > 0)
                { 
                    query = query.Where(p => p.RollResult.Equals(FltrRollResult));
                    ViewData["FltrRollResult"] = FltrRollResult;
                }
                if (FltrEdgeCount > 0)
                { 
                    query = query.Where(p => p.EdgeCount.Equals(FltrEdgeCount));
                    ViewData["FltrEdgeCount"] = FltrEdgeCount;
                }
                if (FltrDiceInRoll > 0)
                { 
                    query = query.Where(p => p.DiceInRoll.Equals(FltrDiceInRoll));
                    ViewData["FltrDiceInRoll"] = FltrDiceInRoll;
                }
                DateTime SQLtime;
                if (FltrRollTime != null)
                {
                    if (DateTime.TryParseExact(FltrRollTime, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out SQLtime))
                    {
                        SQLtime = DateTime.ParseExact(FltrRollTime, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                        query = query.Where(p => p.RollTime.Date == SQLtime.Date);
                        ViewData["FltrRollTime"] = FltrRollTime.Substring(0, 10);
                    }
                    else
                    {
                        ViewData["FltrRollTime"] = "DD.MM.YYYY";
                    }

                }
                else
                {
                    ViewData["FltrRollTime"] = "DD.MM.YYYY";
                }
                /* Для человекочитаемости страницы всегда идут с первой, 
                 * поэтому будем считать, что "нулевая" это первая страница, 
                 * заодно ошибки отсечём */
                if (RollsperPage <= 1)
                { RollsperPage = 100; }
                if (SkipPages <= 0) 
                { SkipPages = 1; }
                int countfromSQL = query.Count();
                int LastPage = ((countfromSQL - (countfromSQL % RollsperPage)) / RollsperPage) + 1;
                if (SkipPages * RollsperPage > countfromSQL) // Ensure you won't get blank page
                { SkipPages = LastPage; }
                int Z = RollsperPage * --SkipPages; //Decrement for Computer
                ViewData["CurrentPage"] = ++SkipPages; //Increment for Human
                ViewData["NextPage"] = SkipPages + 1;
                ViewData["PrevPage"] = SkipPages - 1;
                var fromSQL = query
                  .OrderByDescending(p => p.RollTime)
                  .Skip(Z)
                  .Take(RollsperPage)
                  .ToList();
                ViewData["Count"] = countfromSQL;
                if (countfromSQL < 100)
                { ViewData["MaxCount"] = 100; }
                else
                { ViewData["MaxCount"] = countfromSQL; }
                ViewData["LastPage"] = LastPage;
                ViewData["RollsperPage"] = RollsperPage;
                if (SkipPages != LastPage)
                { ViewData["RollsonPage"] = RollsperPage;  }
                else 
                { ViewData["RollsonPage"] = countfromSQL % RollsperPage; }
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
