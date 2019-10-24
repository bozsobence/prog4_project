﻿// <copyright file="CarRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;

    /// <summary>
    /// This repository handles the Car table in the database.
    /// </summary>
    public class CarRepository : ICarRepository<Car>
    {
        private CarRentalDatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarRepository"/> class.
        /// </summary>
        /// <param name="db">The database entities object.</param>
        public CarRepository(CarRentalDatabaseEntities db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public void AddCar(Car car)
        {
            this.db.Car.Add(car);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteCar(string plate)
        {
            Car c = this.GetOne(plate);
            this.db.Car.Remove(c);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Car> GetAll()
        {
            return this.db.Car;
        }

        /// <inheritdoc/>
        public Car GetOne(string id)
        {
            return this.db.Car.Where(x => x.plate == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateBatteryLevel(string plate, int battery)
        {
            Car c = this.GetOne(plate);
            c.battery = battery;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateExtraPrice(string plate, int extraPrice)
        {
            Car c = this.GetOne(plate);
            c.extraPrice = extraPrice;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdatePlate(string oldPlate, string newPlate)
        {
            Car c = this.GetOne(oldPlate);
            c.plate = newPlate;
            this.db.SaveChanges();
        }
    }
}