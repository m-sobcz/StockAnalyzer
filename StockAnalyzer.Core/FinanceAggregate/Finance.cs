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
        public HashSet<string> GetDecimalRuntimePropertiesNames() 
        {
            var runtimeProperties = this.GetType().GetRuntimeProperties().Where(x=>x.PropertyType==typeof(decimal));
            HashSet<string> propertiesNames = new HashSet<string>(runtimeProperties.Select(x=>x.Name));
            return propertiesNames;
        }
    }
}
