public interface IObserver
{
    void Update(string stockName, double newPrice);
    void SubscribeToStock(string stockName);
    void UnsubscribeFromStock(string stockName);
    List<string> GetSubscribedStocks();
}