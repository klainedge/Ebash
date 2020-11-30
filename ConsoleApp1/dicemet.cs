using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Введите количество граней у кубика (монетки)");
            var die1 = Console.ReadLine();
            Int32.TryParse(die1, out int die);
            while (die <= 1)
            {
                Console.WriteLine("Введите корректное количество граней (2 и более)");
                die1 = Console.ReadLine();
                Int32.TryParse(die1, out die);
            }
            die++;
            Console.WriteLine("Введите количество кубиков");
            var rand = new Random();
            var t = Console.ReadLine();
            Int32.TryParse(t, out int A);
            while (A <= 0)
            {
                Console.WriteLine("Введите корректное количество кубиков");
                t = Console.ReadLine();
                Int32.TryParse(t, out A);
            }
            Console.WriteLine($"Вы бросили {A} кубиков:");
            for (int ctr = 0; ctr < A; ctr++)
                Console.Write("{0:N0} ", rand.Next(1, die));
            Console.WriteLine();
        }
    }
}
