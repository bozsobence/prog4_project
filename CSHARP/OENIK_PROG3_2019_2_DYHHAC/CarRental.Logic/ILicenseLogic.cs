// <copyright file="ILicenseLogic.cs" company="PlaceholderCompany">
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

    /// <summary>
    /// Defines the public methods of the class responsible for the CRUD operations of the Licenses table.
    /// </summary>
    public interface ILicenseLogic
    {
        /// <summary>
        /// Gets all data from the License table.
        /// </summary>
        /// <returns>Returns the data from the Account table in a formatted string.</returns>
        IQueryable<License> GetLicenseData();

        /// <summary>
        /// Checks if the given license exists in the database.
        /// </summary>
        /// <param name="licenseId">The ID of the license.</param>
        /// <returns>True or false.</returns>
        bool IsValidLicense(string licenseId);

        /// <summary>
        /// Adds a new license to the database.
        /// </summary>
        /// <param name="licenseId">The number of the license. Contains numbers and letters.</param>
        /// <param name="accountId">The user whom the license belongs to.</param>
        /// <param name="category">The highest category of the license.</param>
        /// <param name="startDate">The license is valid from this date.</param>
        /// <param name="expiryDate">The expiration date of the license.</param>
        /// <param name="penaltyPoints">The penalty points the user has. Issued by authorities.</param>
        /// <returns>True or false whether the insertion was successful or not.</returns>
        bool AddNewLicense(string licenseId, int accountId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints);

        /// <summary>
        /// Updates the selected license data.
        /// </summary>
        /// <param name="id">The license we want to update.</param>
        /// <param name="accId">The account whom the license belongs to.</param>
        /// <param name="category">The new category of the license.</param>
        /// <param name="startDate">The new start date of the license.</param>
        /// <param name="expiryDate">The new expiry date of the license.</param>
        /// <param name="penaltyPoints">The new value of penalty points.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateLicenseData(string id, int accId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints);

        /// <summary>
        /// Deletes the selected license from the database.
        /// </summary>
        /// <param name="licenseId">The license we want to delete.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteLicenseData(string licenseId);
    }
}
