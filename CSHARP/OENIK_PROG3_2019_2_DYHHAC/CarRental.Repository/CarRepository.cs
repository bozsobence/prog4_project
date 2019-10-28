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

        /// <summary>
        /// Gets the content of the table.
        /// </summary>
        /// <returns>Returns a formatted string with the table data.</returns>
        public string GetCarData()
        {
            List<Car> carData = this.GetAll().ToList();
            string formatted = string.Empty;
            foreach (var car in carData)
            {
                formatted += string.Format($">> Numberplate: {car.plate} | Brand: {car.brand} | Model: {car.model} | Battery level: {car.battery} | Extra price: {car.extraPrice}\n");
            }

            return formatted;
        }

        /// <inheritdoc/>
        public void AddCar(Car car)
        {
            this.db.Car.Add(car);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddCar(string carPlate, string carBrand, string carModel, int carBattery, int carExtraPrice)
        {
            Car car = new Car()
            {
                plate = carPlate,
                brand = carBrand,
                model = carModel,
                battery = carBattery,
                extraPrice = carExtraPrice,
            };
            this.AddCar(car);
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
        public void UpdateCar(string plate, string brand, string model, int battery, int extraPrice)
        {
            Car c = this.GetOne(plate);
            c.brand = brand;
            c.model = model;
            c.battery = battery;
            c.extraPrice = extraPrice;
            this.db.SaveChanges();
        }
    }
}
