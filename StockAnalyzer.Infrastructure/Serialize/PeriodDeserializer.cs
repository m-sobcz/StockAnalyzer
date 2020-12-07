using StockAnalyzer.Core.StatementAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StockAnalyzer.Infrastructure.Serialize
{
    public class PeriodDeserializer : IDeserializer<Period>
    {
        static Regex periodRegex;
        readonly string yearGroupName = "year";
        readonly string quarterGroupName = "quarter";
        int periodYear;
        int? periodQuarter;

        public PeriodDeserializer()
        {
            string yearWithOptionalQuarterPattern = @"(?<year>\d{4})(/Q)?(?<quarter>\d)?";
            periodRegex = new Regex(yearWithOptionalQuarterPattern, RegexOptions.Compiled);
        }

        public Period Deserialize(string description)
        {
            Match yearAndQuarterMatch = periodRegex.Match(description);
            if (!yearAndQuarterMatch.Success)
            {
                return null;
            }
            if (yearAndQuarterMatch.Groups[yearGroupName].Length > 0)
            {
                ExtractYear(yearAndQuarterMatch.Groups[yearGroupName].Value);
            }
            if (yearAndQuarterMatch.Groups[quarterGroupName].Length > 0)
            {
                ExtractQuarter(yearAndQuarterMatch.Groups[quarterGroupName].Value);
            }
            return new Period(periodYear, periodQuarter);
        }
        void ExtractYear(string val)
        {
            if (int.TryParse(val, out int year))
            {
                periodYear = year;
            }
            else
            {
                throw new ArgumentException("Unable to deserialize Period's Year");
            }
        }
        void ExtractQuarter(string val)
        {
            if (int.TryParse(val, out int quarter))
            {
                periodQuarter = quarter;
            }
            else
            {
                throw new ArgumentException("Unable to serialize Period's Quarter");
            }
        }
    }
}
