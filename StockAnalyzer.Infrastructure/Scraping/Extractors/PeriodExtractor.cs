using StockAnalyzer.Core.FinanceAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StockAnalyzer.Infrastructure.Scraping.Extractors
{
    public class PeriodExtractor
    {
        static Regex periodRegex;
        Period period = new Period();

        public PeriodExtractor()
        {
            string yearWithOptionalQuarterPattern = @"(\d{4})(\\Q\d)?";
            periodRegex = new Regex(yearWithOptionalQuarterPattern, RegexOptions.Compiled);
        }

        public Period Get(string description)
        {
            period = new Period();
            Match yearAndQuarterMatch = periodRegex.Match(description);
            switch (yearAndQuarterMatch.Groups.Count)
            {
                case 1:
                    ExtractYear(yearAndQuarterMatch.Groups[0].Value);
                    break;
                case 2:
                    ExtractYear(yearAndQuarterMatch.Groups[0].Value);
                    ExtractQuarter(yearAndQuarterMatch.Groups[1].Value);
                    break;
                default:
                    CheckNonYearSpecificDescription(description);
                    break;
            }
            return period;
        }
        void ExtractYear(string val)
        {
            if (int.TryParse(val, out int year))
            {
                period.Year = year;
            }
            else
            {
                throw new ArgumentException("Unable to parse Period's Year");
            }
        }
        void ExtractQuarter(string val)
        {
            if (int.TryParse(val, out int quarter))
            {
                period.Quarter = quarter;
            }
            else
            {
                throw new ArgumentException("Unable to parse Period's Quarter");
            }
        }
        void CheckNonYearSpecificDescription(string description)
        {
            if (description == "O4K")
            {
                period.Year = DateTime.Now.Year;
            }
            else
            {
                throw new ArgumentException("Period description format not recognized");
            }
        }
    }
}
