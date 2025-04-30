public class Investor : IObserver
{
    private string name;
    private List<string> stocks = new List<string>();

    public Investor(string name)
    {
        this.name = name;
    }

    public void Update(string stockName, double newPrice)
    {
        Console.WriteLine($"Інвестор {name} повідомлений: Акція {stockName} змінила ціну на {newPrice}");
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