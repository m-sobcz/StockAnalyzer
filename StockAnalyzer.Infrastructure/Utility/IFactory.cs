using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Utility
{
    public interface IFactory<T>
    {
        T Create();
    }
}
