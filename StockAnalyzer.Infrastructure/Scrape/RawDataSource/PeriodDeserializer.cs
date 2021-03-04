using StockAnalyzer.Core.StatementAggregate;
using System;
using System.Text.RegularExpressions;

namespace StockAnalyzer.Infrastructure.Scrape.RawDataSource
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
            string yearWithOptionalQuarterPattern = @"(?<year>\d{4})(/Q?<quarter>\d)?";
            periodRegex = new Regex(yearWithOptionalQuarterPattern, RegexOptions.Compiled);
        }

        public Period Deserialize(string description)
        {
            Match yearAndQuarterMatch = periodRegex.Match(description);
            VerifyMatch(yearAndQuarterMatch, description.Length);
            ExtractPeriod(yearAndQuarterMatch);
            return new Period(periodYear, periodQuarter);
        }
        void VerifyMatch(Match match, int expectedMatchLength) 
        {
            if (!match.Success)
            {
                throw new ArgumentException("No match with yearWithOptionalQuarterPattern!");
            }
            if (match.Length < expectedMatchLength)
            {
                throw new ArgumentException("Match found is shorter than inputs length!");
            }
        }
        void ExtractPeriod(Match match) 
        {
            if (match.Groups[yearGroupName].Length > 0)
            {
                ExtractYear(match.Groups[yearGroupName].Value);
            }
            if (match.Groups[quarterGroupName].Length > 0)
            {
                ExtractQuarter(match.Groups[quarterGroupName].Value);
            }
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
