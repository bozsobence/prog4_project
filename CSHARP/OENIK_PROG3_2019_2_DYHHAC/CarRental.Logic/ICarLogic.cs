// <copyright file="ICarLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Logic.DTO;

    /// <summary>
    /// Defines the public methods of the class responsible for the CRUD operations of the Cars table.
    /// </summary>
    public interface ICarLogic
    {
        /// <summary>
        /// Gets all data from the Car table.
        /// </summary>
        /// <returns>Returns the data from the Car table in a formatted string.</returns>
        IEnumerable<Car> GetCarData();

        /// <summary>
        /// Checks if the given car exists in the database.
        /// </summary>
        /// <param name="id">The numberplate of the car.</param>
        /// <returns>True or false.</returns>
        bool IsValidCar(string id);

        /// <summary>
        /// Adds a new car to the database.
        /// </summary>
        /// <param name="id">The numberplate of the car. This is the primary key.</param>
        /// <param name="brand">The brand of the car.</param>
        /// <param name="model">The model of the car.</param>
        /// <param name="battery">The battery level of the car.</param>
        /// <param name="extraPrice">The additional per minute fee paid by the user when using this car.</param>
        /// <returns>True or false whether the insertion was successful or not.</returns>
        bool AddNewCar(string id, string brand, string model, int battery, int extraPrice);

        /// <summary>
        /// Updates the selected car data.
        /// </summary>
        /// <param name="id">The numberplate of the car we want to update.</param>
        /// <param name="brand">The new brand to be set.</param>
        /// <param name="model">The new model to be set.</param>
        /// <param name="battery">The new battery level to be set.</param>
        /// <param name="extraPrice">The new extra price to be set.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateCarData(string id, string brand, string model, int battery, int extraPrice);

        /// <summary>
        /// Deletes the selected car from the database.
        /// </summary>
        /// <param name="plate">The numberplate of the car which we want to delete.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteCarData(string plate);
    }
}
