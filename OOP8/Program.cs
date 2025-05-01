using System;
using System.Collections.Generic;
using System.Text;

    public class CafeOrderWithoutSolid
    {
        private Dictionary<string, double> menu = new Dictionary<string, double>()
           {
               {"Кава", 25.00},
               {"Чай", 20.00},
               {"Тістечко", 30.00},
               {"Суп", 40.00},
               {"Салат", 50.00}
           };

        private List<(string страва, int кількість)> orderItems = new List<(string, int)>();
        private double total = 0.0;

        public void ПрийнятиЗамовлення(string страва, int кількість)
        {
            if (menu.ContainsKey(страва))
            {
                orderItems.Add((страва, кількість));
                Console.WriteLine($"{кількість} x {страва} додано до замовлення.");
            }
            else
            {
                Console.WriteLine($"Страва '{страва}' відсутня в меню.");
            }
        }

        public double РозрахуватиСуму()
        {
            total = 0.0;
            foreach (var item in orderItems)
            {
                total += menu[item.страва] * item.кількість;
            }
            ЗастосуватиЗнижку(); 
            return total;
        }

        public void ЗастосуватиЗнижку()
        {
            bool hasSoup = orderItems.Exists(item => item.страва == "Суп");
            if (total > 100)
            {
                total *= 0.9;
                Console.WriteLine("Застосовано знижку 10% (сума > 100).");
            }
            else if (hasSoup)
            {
                total *= 0.95;
                Console.WriteLine("Застосовано знижку 5% (є суп у замовленні).");
            }
        }

        public string ЗгенеруватиЧек()
        {
            StringBuilder чек = new StringBuilder();
            чек.AppendLine("--- Чек ---");
            foreach (var item in orderItems)
            {
                чек.AppendLine($"{item.страва} x {item.кількість} = {menu[item.страва] * item.кількість} грн.");
            }
            чек.AppendLine($"Загалом: {total} грн.");
            чек.AppendLine("--- Кінець чека ---");
            return чек.ToString();
        }

        public void ВивестиМеню()
        {
            Console.WriteLine("--- Меню ---");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Key} - {item.Value} грн.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CafeOrderWithoutSolid order = new CafeOrderWithoutSolid();

            order.ВивестиМеню();

            order.ПрийнятиЗамовлення("Кава", 2);
            order.ПрийнятиЗамовлення("Тістечко", 1);
            order.ПрийнятиЗамовлення("Суп", 1);

            double total = order.РозрахуватиСуму();
            Console.WriteLine($"\nСума замовлення: {total} грн.");

            string чек = order.ЗгенеруватиЧек();
            Console.WriteLine("\n" + чек);
        }
    }
