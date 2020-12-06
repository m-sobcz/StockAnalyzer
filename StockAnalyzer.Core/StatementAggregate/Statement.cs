using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Core.StatementAggregate
{
    public class Statement : BaseEntity, IAggregateRoot
    {
        private Period period;
        private Balance balance;
        private Income income;
        private Cashflow cashflow;

        public Period Period
        {
            get { return period; }
            set { period = value; }
        }

        public Balance Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public Income Income
        {
            get { return income; }
            set { income = value; }
        }

        public Cashflow Cashflow
        {
            get { return cashflow; }
            set { cashflow = value; }
        }
    }
}
