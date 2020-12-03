using StockAnalyzer.Core.FinanceAggregate;
using StockAnalyzer.Infrastructure.Scrape;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StockAnalyzer.Infrastructure.Serialize
{
    public class FinancePropertiesLoader<T> where T : Finance
    {
        readonly HashSet<string> propertiesToFill;
        public FinancePropertiesLoader()
        {
            propertiesToFill = GetDecimalPropertiesToFill(typeof(T));
        }
        public void LoadFinancesWithData(List<T> finances, ScrapedData scrapedData) 
        {
            foreach (ScrapedData.Row row in scrapedData.Rows)
            {
                FillFinancesWithDataRow(finances, row);
            }
        }
        void FillFinancesWithDataRow(List<T> finances, ScrapedData.Row row)
        {
            if (propertiesToFill.Contains(row.Label))
            {
                PropertyInfo propInfo = typeof(T).GetProperty(row.Label);
                MethodInfo setMethod = propInfo.GetSetMethod();
                for (int i = 0; i < row.Vals.Count; i++)
                {
                    var val = decimal.Parse(row.Vals[i]);
                    setMethod.Invoke(finances[i], new object[] { val });
                }
            }
        }
        HashSet<string> GetDecimalPropertiesToFill(Type type)
        {
            var runtimeProperties = type.GetRuntimeProperties().Where(x => x.PropertyType == typeof(decimal));
            HashSet<string> propertiesNames = new HashSet<string>(runtimeProperties.Select(x => x.Name));
            return propertiesNames;
        }
    }
}
