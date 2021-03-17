namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
{
    public interface IHtmlSource
    {
        string GetHtml(string adressSuffix="");
    }
}
