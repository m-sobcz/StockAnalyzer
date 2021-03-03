namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
{
    public interface IDeserializer<T>
    {
        T Deserialize(string txt);
    }
}
