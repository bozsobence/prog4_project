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
        /// Updates the selected license data.
        /// </summary>
        /// <param name="id">The license we want to update.</param>
        /// <param name="accId">The account whom the license belongs to.</param>
        /// <param name="category">The new category of the license.</param>
        /// <param name="startDate">The new start date of the license.</param>
        /// <param name="expiryDate">The new expiry date of the license.</param>
        /// <param name="penaltyPoints">The new value of penalty points.</param>
        void UpdateLicense(string id, int accId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints);

        /// <summary>
        /// Deletes the selected license from the database.
        /// </summary>
        /// <param name="id">The license to be deleted.</param>
        void DeleteLicense(string id);
    }
}
