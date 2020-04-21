// <copyright file="IBusinessLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;
    using CarRental.Repository;

    /// <summary>
    /// Defines the public methods of the business logic.
    /// </summary>
    public interface IBusinessLogic
    {
        /// <summary>
        /// Gets the daily income of each month.
        /// </summary>
        /// <returns>Returns <see cref="IEnumerable{DailyIncomeResult}"/>.</returns>
        IEnumerable<DailyIncomeResult> GetDailyIncome();

        /// <summary>
        /// Gets the overall income and the daily average price of the rents.
        /// </summary>
        /// <returns>Returns <see cref="OverallIncomeResult"/>.</returns>
        OverallIncomeResult GetOverallIncome();

        /// <summary>
        /// Gets the people who started the most rents.
        /// </summary>
        /// <returns>Returns <see cref="IEnumerable{RentsByUserResult}"/>.</returns>
        RentsByUserResult GetUserWithMostRents();

        /// <summary>
        /// Gets the distance driven with each car.
        /// </summary>
        /// <returns>Returns <see cref="IEnumerable{DistancesByCarResult}"/>.</returns>
        IEnumerable<DistancesByCarResult> GetDistanceByCar();

        /// <summary>
        /// Gets the users who are excluded from starting rents.
        /// </summary>
        /// <returns>Returns <see cref="IEnumerable{RentsByUserResult}"/>.</returns>
        IEnumerable<RentsByUserResult> GetRentsByUser();

        /// <summary>
        /// Gets the statistics of the selected car.
        /// </summary>
        /// <param name="id">The numberplate of the car.</param>
        /// <returns>Returns <see cref="CarStats"/>.</returns>
        CarStats GetCarStats(string id);

        /// <summary>
        /// Gets the recommended subscription and cars from the Java servlet based on the input data.
        /// </summary>
        /// <param name="minutes">The minutes the user plans to drive per month.</param>
        /// <param name="size">The preferred size of the car.</param>
        /// <param name="category">The preferred price category of the car.</param>
        /// <returns>Returns a string with the result from the Java servlet.</returns>
        string GetRecommendationFromJava(int minutes, int size, int category);
    }
}
