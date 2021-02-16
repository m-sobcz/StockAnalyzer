using AutoMapper;
using StockAnalyzer.Infrastructure.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalyzer.Infrastructure.Scrape.StockMapping
{
    public class MapperFactory <TProfile> : IFactory<IMapper> where TProfile:Profile, new()
    {

        public IMapper Create()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TProfile>());
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
