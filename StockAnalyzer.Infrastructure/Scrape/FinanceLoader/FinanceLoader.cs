using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using StockAnalyzer.Infrastructure.Scrape.StatementLoad;
using StockAnalyzer.Infrastructure.Scrape.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace StockAnalyzer.Infrastructure.Scrape.FinanceLoader
{
    public class FinanceLoader<TFinance> : IFinanceLoader<TFinance> where TFinance : Finance, new()
    {
        readonly Dictionary<string, PropertyInfo> domainProperties;
        readonly IDeserializer<Period> periodDeserializer;

        public FinanceLoader(IDeserializer<Period> periodDeserializer)
        {
            this.periodDeserializer = periodDeserializer;
            domainProperties = GetPropertiesToFill(typeof(TFinance));
        }
        Dictionary<string, PropertyInfo> GetPropertiesToFill(Type type)
        {
            IEnumerable<PropertyInfo> runtimeProperties = type.GetRuntimeProperties();
            return runtimeProperties.ToDictionary(x => x.Name);
        }
        public List<Tuple<TFinance, Period>> GenerateFinanceWithPeriods(FinanceRawData rawData)
        {
            List<Tuple<TFinance, Period>> financesWithPeriods = new List<Tuple<TFinance, Period>>();
            for (int i = 0; i < rawData.Periods.Count; i++)
            {
                TFinance domainObj = new TFinance();
                Period period = periodDeserializer.Deserialize(rawData.Periods[i]);
                Tuple<TFinance, Period> tuple = new Tuple<TFinance, Period>(domainObj, period);
                financesWithPeriods.Add(tuple);
            }
            foreach (var row in rawData.Rows)
            {
                FillFinanceWithData(financesWithPeriods, row);
            }
            return financesWithPeriods;
        }

        void FillFinanceWithData(List<Tuple<TFinance, Period>> financesWithPeriods, FinanceRawData.Row row)
        {
            if (domainProperties.TryGetValue(row.Label, out PropertyInfo setterMethodInfo))
            {
                for (int i = 0; i < (row.Vals?.Count ?? 0); i++)
                {
                    object val = Convert.ChangeType(row.Vals[i], setterMethodInfo.PropertyType);
                    MethodInfo setter = setterMethodInfo.GetSetMethod();
                    setter.Invoke(financesWithPeriods[i].Item1, new object[] { val });
                }
            }
            else
            {
                Debug.WriteLine(@$"Unable to load row: {row.Label} due to lack of matching property in finance: {typeof(TFinance)}!");
            }

        }
    }
}
