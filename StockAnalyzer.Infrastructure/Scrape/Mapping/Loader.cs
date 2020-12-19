using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.Mapping
{
    public abstract class Loader<TDataRow, TDomain>
    {
        readonly protected Dictionary<string, PropertyInfo> domainProperties;
        protected List<TDomain> domains;
        Func<TDomain> createDomain;
        public Loader(Func<TDomain> create)
        {
            createDomain = create;
            domainProperties = GetPropertiesToFill(typeof(TDomain));
        }

        public abstract List<TDomain> Load(List<TDataRow> dataRows);

        protected List<TDomain> CreateDomains(int count)
        {
            List<TDomain> domains = new List<TDomain>();
            for (int i = 0; i < count; i++)
            {
                domains.Add(createDomain());
            }
            return domains;
        }
        protected Dictionary<string, PropertyInfo> GetPropertiesToFill(Type type)
        {
            IEnumerable<PropertyInfo> runtimeProperties = type.GetRuntimeProperties();
            return runtimeProperties.ToDictionary(x => x.Name);
        }
    }

}
