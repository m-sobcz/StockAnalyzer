using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenScraping;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RawDataExtracting;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;
using StockAnalyzer.Infrastructure.Scrape.StockMapping;
using StockAnalyzer.Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape
{
    public class ScrapeService
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Stock repository
            services.AddSingleton<ConfigRepository>();
            services.AddScoped<IReadOnlyRepository<long, Stock>, DomainRepository<Stock>>();
            services.AddScoped<IRepositorySource<Stock>, StockSource>();
            services.AddScoped<IStockMapper, StockAutoMapper>().AddScoped<IFactory<IMapper>,MapperFactory<StockMapProfile>>();
            services.AddScoped<IRawDataSource<StockRawData>, HtmlDataSource<StockRawData>>();
            services.AddScoped<IDeserializer<StockRawData>, Scraper<StockRawData>>()
                .AddScoped(ServiceProviderServiceExtensions => new ScraperConfig("Stocks"));
            services.AddScoped<IDataExtractorFactory<StockRawData>, OpenScrapingExtractorFactory<StockRawData>>(serviceProvider => 
            new OpenScrapingExtractorFactory<StockRawData>(configSection => 
            new OpenScrapingDataExtractor<StockRawData>(
                new StructuredDataExtractor(configSection)),
                serviceProvider.GetService<ConfigRepository>())
                );



            //Statement repository

        }
    }
}
