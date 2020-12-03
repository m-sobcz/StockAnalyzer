using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StockAnalyzer.Core.FinanceAggregate
{
    public class Period : BaseEntity
    {
        public int Year { get; set; }
        public int? Quarter { get; set; }
        public bool IsYearly => !Quarter.HasValue;
        public bool IsQuarterly => Quarter.HasValue;
        public Period(int year, int? quarter=null)
        {
            Year = year;
            Quarter = quarter;
        }
    }

}
