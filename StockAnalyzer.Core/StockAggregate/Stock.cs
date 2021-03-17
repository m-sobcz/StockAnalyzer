using StockAnalyzer.Core.Interfaces;
using StockAnalyzer.Core.StatementAggregate;
using System;
using System.Collections.Generic;

namespace StockAnalyzer.Core.StockAggregate
{
    public class Stock : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Ticker { get; set; }
        public decimal ActualPrice { get; set; }
        public decimal OpeningPrice { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal Volume { get; set; }
        public decimal Turnover { get; set; }
        public DateTimeOffset UpdateTime { get; set; }
        public string Link { get; set; }

        private readonly List<StockIndex> indexes = new List<StockIndex>();
        private readonly List<Statement> statements = new List<Statement>();
        public IReadOnlyCollection<StockIndex> Indexes => indexes.AsReadOnly();

        public IReadOnlyCollection<Statement> Statements => statements.AsReadOnly();
        public Stock()
        {
        }
        public Stock(long id, string name, string ticker)
        {
            Id = id;
            Name = name;
            Ticker = ticker;
        }

        public void AddIndex(StockIndex stockIndex)
        {
            indexes.Add(stockIndex);
        }
        public void RemoveIndex(StockIndex stockIndex)
        {
            indexes.Remove(stockIndex);
        }
        public void SetStatements(IEnumerable<Statement> statements)
        {
            this.statements.Clear();
            this.statements.AddRange(statements);
        }
        public void AddStatement(Statement statement)
        {
            statements.Add(statement);
        }
        public void RemoveStatement(Statement statement)
        {
            statements.Remove(statement);
        }
    }
}
