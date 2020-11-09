using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Core.StockAggregate
{
    public class Stock : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Abbreviaton { get; private set; }
        private readonly List<StockIndex> indexes = new List<StockIndex>();
        public IReadOnlyCollection<StockIndex> Indexes => indexes.AsReadOnly();

        public Stock(string name, string abbreviation)
        {
            Name = name;
            Abbreviaton = abbreviation;
        }
        public void AddIndex(StockIndex stockIndex)
        {
            indexes.Add(stockIndex);
        }
        public void RemoveIndex(StockIndex stockIndex)
        {
            indexes.Remove(stockIndex);
        }
    }
}
