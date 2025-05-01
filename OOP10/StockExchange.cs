public class StockExchange : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private Dictionary<IObserver, List<string>> subscribedStocks = new Dictionary<IObserver, List<string>>();

    public void SetStockPrice(string stockName, double newPrice)
    {
        NotifyObservers(stockName, newPrice);
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
        subscribedStocks[observer] = new List<string>();
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
        subscribedStocks.Remove(observer);
    }

    public void NotifyObservers(string stockName, double newPrice)
    {
        foreach (var pair in subscribedStocks)
        {
            if (pair.Value.Contains(stockName))
            {
                pair.Key.Update(stockName, newPrice);
            }
        }
    }
}