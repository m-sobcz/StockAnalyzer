using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace StockAnalyzer.Core.FinanceAggregate
{
    public abstract class Finance : BaseEntity, IAggregateRoot
    {
        public Period Period { get; set; }

    }
}
