using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OpenScraping;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.HtmlSource;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RawDataExtracting;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;
using StockAnalyzer.Infrastructure.Scrape.StockMapping;
using StockAnalyzer.Infrastructure.Utility;

namespace StockAnalyzer.Infrastructure.Scrape
{
    public static class ScraperServices
    {
        public static void AddScraperServices(this IServiceCollection services)
        {
            //Stock repository
            services.AddScoped<IReadOnlyRepository<long, Stock>, DomainRepository<Stock>>();
            services.AddScoped<IRepositorySource<Stock>, StockSource>();
            services.AddScoped<IStockMapper, StockAutoMapper>();
            services.AddScoped<IRawDataSource<StockRawData>, HtmlDataSource<StockRawData>>(sp =>
            new HtmlDataSource<StockRawData>(sp.GetService<IDataExtractorFactory<StockRawData>>().CreateFromName(nameof(Stock)),
            new HtmlDownloader("https://www.biznesradar.pl/gielda/akcje_gpw"))
            );
            services.AddScoped<IDataExtractorFactory<StockRawData>, OpenScrapingExtractorFactory<StockRawData>>(serviceProvider =>
            new OpenScrapingExtractorFactory<StockRawData>(configSection =>
            new OpenScrapingDataExtractor<StockRawData>(
                new StructuredDataExtractor(configSection))
                ));
            //Statement repository

        }
    }
}
