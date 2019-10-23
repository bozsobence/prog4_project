// <copyright file="ILicenseRepository.cs" company="PlaceholderCompany">
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
    /// Interface for the License Repository.
    /// </summary>
    /// <typeparam name="TLicense">Generic parameter for License object.</typeparam>
    public interface ILicenseRepository<TLicense> : IRepository<TLicense, string>
        where TLicense : License
    {
        /// <summary>
        /// Adds a new license to the database.
        /// </summary>
        /// <param name="license">The license to be added.</param>
        void AddLicense(License license);

        /// <summary>
        /// Updates the selected license's category.
        /// </summary>
        /// <param name="id">The license to be updated.</param>
        /// <param name="newCat">The new category to be set.</param>
        void UpdateCategory(string id, string newCat);

        /// <summary>
        /// Updates the selected license's start date.
        /// </summary>
        /// <param name="id">The license to be updated.</param>
        /// <param name="newDate">The new date to be set.</param>
        void UpdateStartDate(string id, DateTime newDate);

        /// <summary>
        /// Updates the selected license's expiry date.
        /// </summary>
        /// <param name="id">The license to be updated.</param>
        /// <param name="newDate">The new date to be set.</param>
        void UpdateExpiryDate(string id, DateTime newDate);

        /// <summary>
        /// Updates the selected license's penalty points.
        /// </summary>
        /// <param name="id">The license to be updated.</param>
        /// <param name="newPoints">The new penalty points to be set.</param>
        void UpdatePenaltyPoints(string id, int newPoints);

        /// <summary>
        /// Deletes the selected license from the database.
        /// </summary>
        /// <param name="id">The license to be deleted.</param>
        void DeleteLicense(string id);

    }
}
