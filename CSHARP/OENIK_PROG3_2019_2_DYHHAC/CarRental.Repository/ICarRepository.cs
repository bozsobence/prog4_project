// <copyright file="ICarRepository.cs" company="PlaceholderCompany">
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
    /// Interface for the CarRepository.
    /// </summary>
    /// <typeparam name="TCar">Generic parameter for Car object.</typeparam>
    public interface ICarRepository<TCar> : IRepository<TCar>
        where TCar : Car
    {
        /// <summary>
        /// Adds a new car to the database.
        /// </summary>
        /// <param name="car">The car object that needs to be added.</param>
        void AddCar(Car car);

        /// <summary>
        /// Updates the battery level of the selected car.
        /// </summary>
        /// <param name="plate">The plate of the car we want tp update.</param>
        /// <param name="battery">The new battery level to be set.</param>
        void UpdateBatteryLevel(string plate, int battery);

        /// <summary>
        /// Updates the extra price of the selected car.
        /// </summary>
        /// <param name="plate">The plate of the car we want tp update.</param>
        /// <param name="extraPrice">The new extra price to be set.</param>
        void UpdateExtraPrice(string plate, int extraPrice);

        /// <summary>
        /// Updates the numberplate of the selected car.
        /// </summary>
        /// <param name="oldPlate">The current plate of the car. This is the primary key.</param>
        /// <param name="newPlate">The new numberplate to be set, must be unique.</param>
        void UpdatePlate(string oldPlate, string newPlate);

        /// <summary>
        /// Deletes a car from the database.
        /// </summary>
        /// <param name="plate">The plate of the car that we want to delete.</param>
        void DeleteCar(string plate);
    }
}
