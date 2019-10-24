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
    public interface ICarRepository<TCar> : IRepository<TCar, string>
        where TCar : Car
    {
        /// <summary>
        /// Adds a new car to the database.
        /// </summary>
        /// <param name="car">The car object that needs to be added.</param>
        void AddCar(Car car);

        /// <summary>
        /// Updates the selected car.
        /// </summary>
        /// <param name="plate">The numberplate of the car we want to update.</param>
        /// <param name="brand">The new brand to be set.</param>
        /// <param name="model">The new model to be set.</param>
        /// <param name="battery">The new battery level to be set.</param>
        /// <param name="extraPrice">The new extra price to be set.</param>
        void UpdateCar(string plate, string brand, string model, int battery, int extraPrice);

        /// <summary>
        /// Deletes a car from the database.
        /// </summary>
        /// <param name="plate">The plate of the car that we want to delete.</param>
        void DeleteCar(string plate);
    }
}
