using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace CarRental.Web.Models
{
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarRental.Logic.DTO.Account, CarRental.Web.Models.Account>();
            });
            return mapperConfig.CreateMapper();
        }
    }
}