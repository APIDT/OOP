public class ObserverPatternExample
{
    public static void Main(string[] args)
    {
        StockExchange stockExchange = new StockExchange();

        IObserver investor1 = new Investor("Олександр");
        IObserver investor2 = new Investor("Марія");
        IObserver broker1 = new Broker("Компанія 'ТрейдМакс'");
        IObserver broker2 = new Broker("Брокер Іван");

        stockExchange.Attach(investor1);
        stockExchange.Attach(investor2);
        stockExchange.Attach(broker1);
        stockExchange.Attach(broker2);

        investor1.SubscribeToStock("Apple");
        investor1.SubscribeToStock("Google");

        investor2.SubscribeToStock("Google");

        broker1.SubscribeToStock("Microsoft");

        broker2.SubscribeToStock("Apple");
        broker2.SubscribeToStock("Microsoft");

        Console.WriteLine("\n--- Зміна курсу акцій ---");
        stockExchange.SetStockPrice("Apple", 145.50);
        stockExchange.SetStockPrice("Google", 2730.20);
        stockExchange.SetStockPrice("Microsoft", 310.00);

        Console.WriteLine("\n--- Відписка Інвестора 1 від Google ---");
        investor1.UnsubscribeFromStock("Google");
        stockExchange.SetStockPrice("Google", 2800.00);

        Console.WriteLine("\n--- Відписка Брокера 2 від Apple ---");
        broker2.UnsubscribeFromStock("Apple");
        stockExchange.SetStockPrice("Apple", 150.00); 

        Console.WriteLine("\n--- Кінець тестів ---");
    }
}