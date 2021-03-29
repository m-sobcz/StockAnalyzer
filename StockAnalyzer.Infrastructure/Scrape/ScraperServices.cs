using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OpenScraping;
using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Core.StockAggregate;
using StockAnalyzer.Infrastructure.Scrape.Deserializer;
using StockAnalyzer.Infrastructure.Scrape.FinanceLoader;
using StockAnalyzer.Infrastructure.Scrape.HtmlSource;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.RawDataExtracting;
using StockAnalyzer.Infrastructure.Scrape.RawDataSource;
using StockAnalyzer.Infrastructure.Scrape.Repository;
using StockAnalyzer.Infrastructure.Scrape.RepositorySource;
using StockAnalyzer.Infrastructure.Scrape.StatementLoad;
using StockAnalyzer.Infrastructure.Scrape.StockMapping;
using StockAnalyzer.Infrastructure.Scrape.Utility;

namespace StockAnalyzer.Infrastructure.Scrape
{
    public static class ScraperServices
    {
        public static void AddScraperServices(this IServiceCollection services)
        {
            AddStockRepository(services);
            AddStatementRepository(services);
        }
        static void AddStockRepository(this IServiceCollection services)
        {
            services.AddScoped<IReadOnlyRepository<long, Stock>, DomainRepository<Stock>>();
            services.AddScoped<IRepositorySource<Stock>, StockSource>();
            services.AddScoped<IStockMapper, StockAutoMapper>();
            services.AddScoped<IRawDataSource<StockRawData>, HtmlRawDataSource<StockRawData>>(sp =>
            new HtmlRawDataSource<StockRawData>(sp.GetService<IDataExtractorFactory<StockRawData>>().CreateFromName(nameof(Stock)),
            new HtmlDownloader("https://www.biznesradar.pl/gielda/akcje_gpw"))
            );
            services.AddScoped<IDataExtractorFactory<StockRawData>, OpenScrapingExtractorFactory<StockRawData>>(serviceProvider =>
            new OpenScrapingExtractorFactory<StockRawData>(configSection =>
            new OpenScrapingDataExtractor<StockRawData>(
                new StructuredDataExtractor(configSection))
                ));
        }
        static void AddStatementRepository(this IServiceCollection services)
        {
            services.AddScoped<IStatementSource, StatementSource>();
            services.AddScoped<IFinanceLoader<Income>, FinanceLoader<Income>>();
            services.AddScoped<IFinanceLoader<Balance>, FinanceLoader<Balance>>();
            services.AddScoped<IFinanceLoader<Cashflow>, FinanceLoader<Cashflow>>();
            services.AddSingleton<IDeserializer<Period>, PeriodDeserializer>();


            services.AddScoped<IRawDataSource<IncomeRawData>, HtmlRawDataSource<IncomeRawData>>(sp =>
                new HtmlRawDataSource<IncomeRawData>(sp.GetService<IDataExtractorFactory<IncomeRawData>>().CreateFromName(nameof(Income)),
                new HtmlDownloader("https://www.biznesradar.pl/raporty-finansowe-rachunek-zyskow-i-strat/"))
            );
            services.AddScoped<IRawDataSource<BalanceRawData>, HtmlRawDataSource<BalanceRawData>>(sp =>
                new HtmlRawDataSource<BalanceRawData>(sp.GetService<IDataExtractorFactory<BalanceRawData>>().CreateFromName(nameof(Balance)),
                new HtmlDownloader("https://www.biznesradar.pl/raporty-finansowe-bilans/"))
            );
            services.AddScoped<IRawDataSource<CashflowRawData>, HtmlRawDataSource<CashflowRawData>>(sp =>
                new HtmlRawDataSource<CashflowRawData>(sp.GetService<IDataExtractorFactory<CashflowRawData>>().CreateFromName(nameof(Cashflow)),
                new HtmlDownloader("https://www.biznesradar.pl/raporty-finansowe-przeplywy-pieniezne/"))
            );


            services.AddScoped<IDataExtractorFactory<IncomeRawData>, OpenScrapingExtractorFactory<IncomeRawData>>(serviceProvider =>
                new OpenScrapingExtractorFactory<IncomeRawData>(configSection =>
                new OpenScrapingDataExtractor<IncomeRawData>(
                new StructuredDataExtractor(configSection))
            ));
            services.AddScoped<IDataExtractorFactory<BalanceRawData>, OpenScrapingExtractorFactory<BalanceRawData>>(serviceProvider =>
    new OpenScrapingExtractorFactory<BalanceRawData>(configSection =>
    new OpenScrapingDataExtractor<BalanceRawData>(
    new StructuredDataExtractor(configSection))
));
            services.AddScoped<IDataExtractorFactory<CashflowRawData>, OpenScrapingExtractorFactory<CashflowRawData>>(serviceProvider =>
    new OpenScrapingExtractorFactory<CashflowRawData>(configSection =>
    new OpenScrapingDataExtractor<CashflowRawData>(
    new StructuredDataExtractor(configSection))
));

        }
    }
}
