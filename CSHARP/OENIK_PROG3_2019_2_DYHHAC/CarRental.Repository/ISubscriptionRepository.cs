// <copyright file="ISubscriptionRepository.cs" company="PlaceholderCompany">
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
    /// Interface for Subcription Repository.
    /// </summary>
    /// <typeparam name="TSubscription">Generic parameter for Subscription object.</typeparam>
    public interface ISubscriptionRepository<TSubscription> : IRepository<TSubscription, int>
        where TSubscription : Subscription
    {
        /// <summary>
        /// Adds a new subscription to the database.
        /// </summary>
        /// <param name="subscription">The subscription to be added.</param>
        void AddSubscription(Subscription subscription);

        /// <summary>
        /// Updates the price per minute for the selected subscription.
        /// </summary>
        /// <param name="id">The subscription to be updated.</param>
        /// <param name="newMinute">The new price per minute to be set.</param>
        void UpdateMinute(int id, int newMinute);

        /// <summary>
        /// Updates the price per month for the selected subscription.
        /// </summary>
        /// <param name="id">The subscription to be updated.</param>
        /// <param name="newMonthly">The new price per month to be set.</param>
        void UpdateMonthly(int id, int newMonthly);

        /// <summary>
        /// Updates whether this subscription is a corporate subscription or not.
        /// </summary>
        /// <param name="id">The subscription to be updated.</param>
        /// <param name="company">The new value of the company to be set. Must be 0 or 1.</param>
        void UpdateCompany(int id, int company);

        /// <summary>
        /// Deletes the selected subscription.
        /// </summary>
        /// <param name="id">The subscription to be deleted.</param>
        void DeleteSubscription(int id);
    }
}
