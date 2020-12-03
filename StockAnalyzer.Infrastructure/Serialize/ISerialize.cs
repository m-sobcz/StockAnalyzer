using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Serialize
{
    interface ISerialize<T>
    {
        string Serialize(T obj);
        T Deserialize(string txt);
    }
}
