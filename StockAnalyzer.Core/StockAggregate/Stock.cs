﻿using StockAnalyzer.Core.Interfaces;
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

        private readonly List<StockIndex> indexes = new List<StockIndex>();
        public IReadOnlyCollection<StockIndex> Indexes => indexes.AsReadOnly();
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
    }
}
