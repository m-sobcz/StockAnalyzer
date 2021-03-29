using KellermanSoftware.CompareNetObjects;
using Moq;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.FinanceLoader;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.Utility;
using System;
using System.Collections.Generic;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape.FinanceLoader
{
    public class FinanceLoaderTests
    {
        private readonly MockRepository mockRepository;

        private readonly Mock<IDeserializer<Period>> mockDeserializer;

        public FinanceLoaderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDeserializer = this.mockRepository.Create<IDeserializer<Period>>();
            mockDeserializer.Setup(x => x.Deserialize(It.IsAny<string>())).Returns<string>((x) => new Period(Convert.ToInt32(x)));
        }

        private FinanceLoader<Income> CreateFinanceLoader()
        {
            return new FinanceLoader<Income>(
                this.mockDeserializer.Object);
        }

        [Fact]
        public void GenerateFinanceWithPeriods_Given2CorrectRows_MapsCorrectly()
        {
            // Arrange
            var financeLoader = this.CreateFinanceLoader();
            FinanceRawData rawData = new FinanceRawData()
            {
                Periods = new List<string>() { "2000", "2010" },
                Rows = new List<FinanceRawData.Row>() {
                    new FinanceRawData.Row() {
                        Label="NetProfit",
                        Vals=new List<string>(){ "1","2"}
                },
                new FinanceRawData.Row() {
                        Label="AdministrationCosts",
                        Vals=new List<string>(){ "10","20"}
                }}
            };

            // Act
            List<Tuple<Income, Period>> result = financeLoader.GenerateFinanceWithPeriods(
                rawData);

            // Assert
            List<Tuple<Income, Period>> expected = new List<Tuple<Income, Period>>() {
                new Tuple<Income, Period>(new Income(){ NetProfit=1,AdministrationCosts=10},new Period(2000)),
                new Tuple<Income, Period>(new Income(){ NetProfit=10,AdministrationCosts=20},new Period(2010))
            };
            CompareLogic compareLogic = new CompareLogic();
            _ = compareLogic.Compare(expected, result);
            this.mockRepository.VerifyAll();
        }
    }
}
