﻿namespace StockAnalyzer.Core.StockAggregate
{
    public class StockIndex : BaseEntity
    {
        public string Name { get; private set; }
        public StockIndex(string name)
        {
            Name = name;
        }
    }
}
