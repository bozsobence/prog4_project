// <copyright file="IRentRepository.cs" company="PlaceholderCompany">
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
    /// Interface for the Rent Repository.
    /// </summary>
    /// <typeparam name="TRent">Generic parameter for the Rent object.</typeparam>
    public interface IRentRepository<TRent> : IRepository<TRent, int>
        where TRent : Rent
    {
        /// <summary>
        /// Adds a new rent to the database.
        /// </summary>
        /// <param name="rent">The rent to be added.</param>
        void AddRent(Rent rent);

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
        void UpdateRent(int id, int accId, string carId, DateTime startTime, DateTime endTime, int distance, int price);

        /// <summary>
        /// Deletes the selected rent from the database.
        /// </summary>
        /// <param name="id">The rent to be deleted.</param>
        void DeleteRent(int id);
    }
}
