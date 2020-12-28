using StockAnalyzer.Core.StatementAggregate;
using StockAnalyzer.Infrastructure.Scrape.RawData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StockAnalyzer.Infrastructure.Scrape.Mapping
{
    public class FinanceLoader<TDomain> : Loader<FinanceRawData.Row, TDomain> where TDomain : Finance
    {


        public FinanceLoader(Func<TDomain> createFinance) : base(createFinance)
        {
        }

        public override List<TDomain> Load(List<FinanceRawData.Row> dataRows)
        {
            List<TDomain> finances = CreateDomains(dataRows.Count);
            foreach (FinanceRawData.Row row in dataRows)
            {
                if (domainProperties.TryGetValue(row.Label, out PropertyInfo setterMethodInfo))
                {
                    SetFinancesWithDataRow(finances, row, setterMethodInfo);
                }
            }
            return finances;
        }

        void SetFinancesWithDataRow(List<TDomain> finances, FinanceRawData.Row row, PropertyInfo propertyInfo)
        {
            for (int i = 0; i < row.Vals.Count; i++)
            {
                object val = Convert.ChangeType(row.Vals[i], propertyInfo.PropertyType);
                MethodInfo setter = propertyInfo.GetSetMethod();
                setter.Invoke(finances[i], new object[] { val });
            }
        }
    }
}
