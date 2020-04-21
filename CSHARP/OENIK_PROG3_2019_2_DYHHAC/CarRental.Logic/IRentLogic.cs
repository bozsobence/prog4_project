// <copyright file="IRentLogic.cs" company="PlaceholderCompany">
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
    /// Defines the public methods of the class responsible for the CRUD operations of the Rents table.
    /// </summary>
    public interface IRentLogic
    {
        /// <summary>
        /// Gets all data from the Rent table.
        /// </summary>
        /// <returns>Returns the data from the Account table in a formatted string.</returns>
        IEnumerable<Rent> GetRentData();

        /// <summary>
        /// Checks if the given rent exists in the database.
        /// </summary>
        /// <param name="id">The ID of the rent.</param>
        /// <returns>True or false.</returns>
        bool IsValidRent(int id);

        /// <summary>
        /// Adds a new rent to the database.
        /// </summary>
        /// <param name="accountId">The user who started the rent.</param>
        /// <param name="carId">The numberplate of the car that was used.</param>
        /// <param name="startTime">The start time of the rent.</param>
        /// <param name="endTime">The end time of the rent.</param>
        /// <param name="distance">The distance driven with the car.</param>
        /// <param name="price">The price paid by the user.</param>
        /// <returns>True or false whether the insertion was successful or not.</returns>
        bool AddNewRent(int accountId, string carId, DateTime startTime, DateTime endTime, int distance, int price);

        /// <summary>
        /// Updates the selected rent data.
        /// </summary>
        /// <param name="id">The rent to be updated.</param>
        /// <param name="accId">The new account who started the rent.</param>
        /// <param name="carId">The new car which the rent was done.</param>
        /// <param name="startTime">The new start time of the rent.</param>
        /// <param name="endTime">The new end time of the rent.</param>
        /// <param name="distance">The new distance of the rent.</param>
        /// <param name="price">The new price paid by the user.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateRentData(int id, int accId, string carId, DateTime startTime, DateTime endTime, int distance, int price);

        /// <summary>
        /// Deletes the selected rent from the database.
        /// </summary>
        /// <param name="id">The rent we want to delete.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteRentData(int id);
    }
}
