using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace StockAnalyzer.Core.StatementAggregate
{
    public abstract class Finance : BaseEntity
    {
        public Period Period { get; set; }

    }
}
