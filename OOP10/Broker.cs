public class Broker : IObserver
{
    private string name;
    private List<string> stocks = new List<string>();

    public Broker(string name)
    {
        this.name = name;
    }

    public void Update(string stockName, double newPrice)
    {
        Console.WriteLine($"Брокер {name} повідомлений: Акція {stockName} тепер коштує {newPrice}");
    }

    public void SubscribeToStock(string stockName)
    {
        stocks.Add(stockName);
    }

    public void UnsubscribeFromStock(string stockName)
    {
        stocks.Remove(stockName);
    }

    public List<string> GetSubscribedStocks()
    {
        return stocks;
    }
}