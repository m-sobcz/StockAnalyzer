using System;

namespace StockAnalyzer.Core.StatementAggregate
{
    public class Period : BaseEntity, IEquatable<Period>, IComparable<Period>
    {
        public int Year { get; set; }
        public int? Quarter { get; set; }
        public bool IsYearly => !Quarter.HasValue;
        public bool IsQuarterly => Quarter.HasValue;
        public Period(int year, int? quarter = null)
        {
            Year = year;
            Quarter = quarter;
        }

        public bool Equals(Period other)
        {
            return Year == other.Year && Quarter == other.Quarter;
        }
        public override int GetHashCode()
        {
            return new { Year, Quarter }.GetHashCode();
        }

        public int CompareTo(Period other)
        {
            if (Equals(other)) return 0;
            else if (Year != other.Year)
            {
                return Year - other.Year;
            }
            else
            {
                return Quarter ?? 0 - other.Quarter ?? 0;
            }
        }
    }

}
