using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Serialize
{
        public interface IDeserializer<T>
        {
            T Deserialize(string txt);
        }  
}
