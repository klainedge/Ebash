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

        public IActionResult Index()
        {
            ViewData["roller"] = "Случайный бросок 3d6";
            var rand = new Random();
            var Otvet = new DiceValues();
            Otvet.Result = new List<int> { rand.Next(1, 7), rand.Next(1, 7), rand.Next(1, 7) };
            Otvet.Shas = DateTime.Now;
            Otvet.Q = 3;
            Otvet.E = 6;
            return View(Otvet);
        }

        public IActionResult Roll(int Q, int E)
        {
            float S = (Q * ((float)(E + 1) / 2));
            var rand = new Random();
            var Otvet = new DiceValues();
            int Summa = 0;
            List<int> Drop = new List<int>();
            for (int ctr = 0; ctr < Q; ctr++)
            {
                int Y = rand.Next(1, E+1);
                Summa = Summa + Y;
                Drop.Add(Y);
            }
            Otvet.Result = Drop;
            Otvet.Shas = DateTime.Now;
            Otvet.Avg = $"Получилось {Summa}. {S} – среднее значение выпадения при количестве кубиков {Q} и количестве граней {E} (с округлением вниз)";
            Otvet.Q = Q;
            Otvet.E = E;
            return View("Index", Otvet);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
