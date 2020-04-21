// <copyright file="IAccountLogic.cs" company="PlaceholderCompany">
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
    /// Defines the public methods of the class responsible for the CRUD operations of the Accounts table.
    /// </summary>
    public interface IAccountLogic
    {
        /// <summary>
        /// Gets all data from the Account table.
        /// </summary>
        /// <returns>Returns the data from the Account table in a formatted string.</returns>
        IQueryable<Account> GetAccountData();

        /// <summary>
        /// Checks if the given account exists in the database.
        /// </summary>
        /// <param name="id">The ID of the account.</param>
        /// <returns>True or false.</returns>
        bool IsValidAccount(int id);

        /// <summary>
        /// Adds a new account to the database.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="address">The city where the user lives.</param>
        /// <param name="bdate">The birth date of the user.</param>
        /// <param name="minute">The price per minute the user will pay for the rents.</param>
        /// <param name="monthly">The monthly price the user will pay for the services.</param>
        /// <returns>True or false whether on the insertion was successful or not.</returns>
        bool AddNewAccount(string name, string email, string address, DateTime bdate, int minute, int monthly);

        /// <summary>
        /// Updates an account data.
        /// </summary>
        /// <param name="id">The account to be updated.</param>
        /// <param name="name">The new name to be set.</param>
        /// <param name="email">The new email to be set. </param>
        /// <param name="address">The new address to be set.</param>
        /// <param name="bdate">The new birth date to be set.</param>
        /// <param name="minute">The new price per minute to be set.</param>
        /// <param name="monthly">The new monthly price to be set.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateAccountData(int id, string name, string email, string address, DateTime bdate, int minute, int monthly);

        /// <summary>
        /// Deletes the selected account from the database.
        /// </summary>
        /// <param name="accountId">The account to be deleted.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteAccountData(int accountId);
    }
}
