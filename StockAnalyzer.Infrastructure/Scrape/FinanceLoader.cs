using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StockAnalyzer.Infrastructure.Scrape
{
    public class FinanceLoader<T> : IScrapedLoader<T> where T : Finance, new() 
    {
        readonly HashSet<string> propertiesToFill;

        public FinanceLoader()
        {
            propertiesToFill = GetDecimalPropertiesToFill(typeof(T));
        }

        public List<T> Load(List<ScrapedData.Row> dataRows) 
        {
            List<T> finances = CreateFinances(dataRows.Count);
            foreach (ScrapedData.Row row in dataRows)
            {
                SetFinancesPropertiesWithDataRow(finances, row);
            }
            return finances;
        }
        List<T> CreateFinances(int count) 
        {
            List<T> finances = new List<T>();
            for (int i = 0; i < count; i++)
            {
                finances.Add(new T());
            }
            return finances;
        }
        void SetFinancesPropertiesWithDataRow(List<T> finances, ScrapedData.Row row)
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
