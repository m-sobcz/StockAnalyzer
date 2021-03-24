namespace StockAnalyzer.Infrastructure.Scrape.Utility
{
    public interface IDeserializer<T>
    {
        T Deserialize(string txt);
    }
}
