using System.Threading.Tasks;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
{
    public interface IHtmlSource
    {
        Task<string> GetHtml(string adressSuffix="");
    }
}
