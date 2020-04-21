// <copyright file="MapperFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;

    /// <summary>
    /// This class is responsible for the configuration of the <see cref="IMapper"/>.
    /// </summary>
    public static class MapperFactory
    {
        /// <summary>
        /// Creates a mapper for the data transfer objects.
        /// </summary>
        /// <returns>Returns <see cref="IMapper"/>.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CarRental.Data.Account, CarRental.Logic.DTO.Account>();
                cfg.CreateMap<CarRental.Data.Car, CarRental.Logic.DTO.Car>();
                cfg.CreateMap<CarRental.Data.Complaint, CarRental.Logic.DTO.Complaint>();
                cfg.CreateMap<CarRental.Data.License, CarRental.Logic.DTO.License>();
                cfg.CreateMap<CarRental.Data.Rent, CarRental.Logic.DTO.Rent>();
            });
            return config.CreateMapper();
        }
    }
}
