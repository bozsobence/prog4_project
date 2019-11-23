// <copyright file="CarRepository.cs" company="PlaceholderCompany">
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
    public class CarRepository : IRepository<Car, string>
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
        public void Add(Car car)
        {
            this.db.Cars.Add(car);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(string plate)
        {
            Car c = this.GetOne(plate);
            this.db.Cars.Remove(c);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Car> GetAll()
        {
            return this.db.Cars;
        }

        /// <inheritdoc/>
        public Car GetOne(string id)
        {
            return this.db.Cars.Where(x => x.CarID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void Update(string carID, Car newData)
        {
            Car c = this.GetOne(carID);
            if (newData.Brand != string.Empty)
            {
                c.Brand = newData.Brand;
            }

            if (newData.Model != string.Empty)
            {
                c.Model = newData.Model;
            }

            if (newData.Battery != -1)
            {
                c.Battery = newData.Battery;
            }

            if (newData.ExtraPrice != -1)
            {
                c.ExtraPrice = newData.ExtraPrice;
            }

            this.db.SaveChanges();
        }
    }
}
