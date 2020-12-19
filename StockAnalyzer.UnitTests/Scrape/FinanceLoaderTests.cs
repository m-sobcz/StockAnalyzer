using Moq;
using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.Data;
using StockAnalyzer.Infrastructure.Scrape.Mapping;
using System;
using System.Collections.Generic;
using Xunit;

namespace StockAnalyzer.UnitTests.Scrape
{
    public class FinanceLoaderTests
    {
        private MockRepository mockRepository;



        public FinanceLoaderTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private FinanceLoader<Income> CreateFinanceLoader()
        {
            return new FinanceLoader<Income>(() => new Income());
        }

        [Fact]
        public void Load_Incomes_PropertiesEqualToData()
        {
            // Arrange
            var financeLoader = this.CreateFinanceLoader();
            List<FinanceData.Row> dataRows=new List<FinanceData.Row>
            {
                new FinanceData.Row() { Description = "desc1", Label = "InterestIncome", Vals = new List<string>() { "100", "200", "300" } },
                new FinanceData.Row() { Description = "desc2", Label = "EBITDA", Vals = new List<string>() { "123", "456", "789" } },
                new FinanceData.Row() { Description = "desc3", Label = "DiscontinuedProfit", Vals = new List<string>() { "111", "222", "333" } }
            };

            // Act
            var result = financeLoader.Load(
                dataRows);

            // Assert
            Assert.Equal(100, result[0].InterestIncome);
            Assert.Equal(200, result[1].InterestIncome);
            Assert.Equal(300, result[2].InterestIncome);

            Assert.Equal(123, result[0].EBITDA);
            Assert.Equal(456, result[1].EBITDA);
            Assert.Equal(789, result[2].EBITDA);

            Assert.Equal(111, result[0].DiscontinuedProfit);
            Assert.Equal(222, result[1].DiscontinuedProfit);
            Assert.Equal(333, result[2].DiscontinuedProfit);
            this.mockRepository.VerifyAll();
        }
    }
}
