namespace StockAnalyzer.Infrastructure.Scrape.RepositorySource
{
    public interface ISerializer<T>
    {
        string Serialize(T obj);
    }
}
