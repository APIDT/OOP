using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeOrderWithSolid
{
    // Інтерфейс для стратегій знижок (OCP, DIP)
    public interface IDiscountStrategy
    {
        double CalculateDiscount(IEnumerable<(string страва, int кількість, double ціна)> orderItems, double total);
    }

    // Клас для управління замовленнями (SRP)
    public class OrderManager
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
            double total = 0.0;
            foreach (var item in orderItems)
            {
                total += menu[item.страва] * item.кількість;
            }
            return total;
        }

        public IEnumerable<(string страва, int кількість, double ціна)> ОтриматиПозиціїЗамовлення()
        {
            return orderItems.Select(item => (item.страва, item.кількість, menu[item.страва] * item.кількість));
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

    // Клас для розрахунку знижок (SRP, OCP, DIP)
    public class DiscountCalculator
    {
        private IDiscountStrategy discountStrategy;

        public DiscountCalculator(IDiscountStrategy strategy)
        {
            this.discountStrategy = strategy;
        }

        public double CalculateDiscount(IEnumerable<(string страва, int кількість, double ціна)> orderItems, double total)
        {
            return discountStrategy.CalculateDiscount(orderItems, total);
        }
    }

    // Клас для генерації чека (SRP, DIP)
    public class ReceiptGenerator
    {
        public string GenerateReceipt(IEnumerable<(string страва, int кількість, double ціна)> orderItems, double total, double discount)
        {
            StringBuilder чек = new StringBuilder();
            чек.AppendLine("--- Чек ---");
            foreach (var item in orderItems)
            {
                чек.AppendLine($"{item.страва} x {item.кількість} = {item.ціна} грн.");
            }
            чек.AppendLine($"Загалом: {total:F2} грн.");
            if (discount > 0)
            {
                чек.AppendLine($"Знижка: -{discount:F2} грн.");
                чек.AppendLine($"Сума до сплати: {(total - discount):F2} грн.");
            }
            чек.AppendLine("--- Кінець чека ---");
            return чек.ToString();
        }
    }

    // Клас для конкретної стратегії знижки (OCP, LSP)
    public class VolumeDiscount : IDiscountStrategy
    {
        private double discountPercent;
        private double threshold;

        public VolumeDiscount(double discountPercent, double threshold)
        {
            this.discountPercent = discountPercent;
            this.threshold = threshold;
        }

        public double CalculateDiscount(IEnumerable<(string страва, int кількість, double ціна)> orderItems, double total)
        {
            if (total > threshold)
            {
                return total * (discountPercent / 100.0);
            }
            return 0.0;
        }
    }

    // Клас для знижки "Купи X, отримай Y у подарунок" (OCP, LSP)
    public class BuyXGetYFreeDiscount : IDiscountStrategy
    {
        private string freeItemName;
        private int buyQuantity;
        private int freeQuantity;

        public BuyXGetYFreeDiscount(string freeItemName, int buyQuantity, int freeQuantity)
        {
            this.freeItemName = freeItemName;
            this.buyQuantity = buyQuantity;
            this.freeQuantity = freeQuantity;
        }

        public double CalculateDiscount(IEnumerable<(string страва, int кількість, double ціна)> orderItems, double total)
        {
            double discount = 0.0;
            int freeItemsCount = orderItems.Where(item => item.страва == freeItemName).Sum(item => item.кількість);
            int discountableItems = (int)Math.Floor((double)freeItemsCount / buyQuantity) * freeQuantity;

            if (discountableItems > 0)
            {
                discount = orderItems.Where(item => item.страва == freeItemName).First().ціна * discountableItems;
            }

            return discount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderManager orderManager = new OrderManager();
            ReceiptGenerator receiptGenerator = new ReceiptGenerator();

            orderManager.ВивестиМеню();

            orderManager.ПрийнятиЗамовлення("Кава", 2);
            orderManager.ПрийнятиЗамовлення("Тістечко", 1);
            orderManager.ПрийнятиЗамовлення("Суп", 1);
            orderManager.ПрийнятиЗамовлення("Чай", 3); // Для тестування знижки "Купи 2, отримай 1 у подарунок"

            double total = orderManager.РозрахуватиСуму();
            var orderItems = orderManager.ОтриматиПозиціїЗамовлення();
            double discount = 0.0;

            // Вибір стратегії знижки (OCP)
            IDiscountStrategy volumeDiscount = new VolumeDiscount(10, 100);  // 10% знижка, якщо сума > 100
            IDiscountStrategy buy2Get1FreeTea = new BuyXGetYFreeDiscount("Чай", 2, 1); // Купи 2 чаї, отримай 1 у подарунок

            DiscountCalculator discountCalculator = new DiscountCalculator(volumeDiscount);
            discount = discountCalculator.CalculateDiscount(orderItems, total);

            // Застосування другої знижки, якщо потрібно
            double teaDiscount = new DiscountCalculator(buy2Get1FreeTea).CalculateDiscount(orderItems, total);
            discount = Math.Max(discount, teaDiscount); // Беремо більшу знижку, або можна їх комбінувати

            Console.WriteLine($"\nСума замовлення: {total:F2} грн.");
            Console.WriteLine($"Знижка: {discount:F2} грн.");
            Console.WriteLine($"Сума до сплати: {(total - discount):F2} грн.");

            string чек = receiptGenerator.GenerateReceipt(orderItems, total, discount);
            Console.WriteLine("\n" + чек);
        }
    }
}