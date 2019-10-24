// <copyright file="IAccountRepository.cs" company="PlaceholderCompany">
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
    /// The interface for the Account Repository.
    /// </summary>
    /// <typeparam name="TAccount">Generic parameter for an Account object.</typeparam>
    public interface IAccountRepository<TAccount> : IRepository<TAccount, int>
        where TAccount : Account
    {
        /// <summary>
        /// Adds a new account to the database.
        /// </summary>
        /// <param name="account">The account to be added.</param>
        void AddAccount(Account account);

        /// <summary>
        /// Updates the selected account's name.
        /// </summary>
        /// <param name="id">The account to be updated.</param>
        /// <param name="newName">The new name to be set.</param>
        void UpdateName(int id, string newName);

        /// <summary>
        /// Updates the selected account's email.
        /// </summary>
        /// <param name="id">The account to be updated.</param>
        /// <param name="newMail">The new mail to be set.</param>
        void UpdateEmail(int id, string newMail);

        /// <summary>
        /// Updates the selected account's address.
        /// </summary>
        /// <param name="id">The account to be updated.</param>
        /// <param name="newAddress">The new address to be set.</param>
        void UpdateAddress(int id, string newAddress);

        /// <summary>
        /// Updates the price per minute value of the selected account.
        /// </summary>
        /// <param name="id">The account to be updated.</param>
        /// <param name="newMinute">The new price per minute value to be set.</param>
        void UpdateMinute(int id, int newMinute);

        /// <summary>
        /// Updates the monthly subscription price of the selected account.
        /// </summary>
        /// <param name="id">The account to be updated.</param>
        /// <param name="newMonth">The new price per month value to be set.</param>
        void UpdateMonthly(int id, int newMonth);

        /// <summary>
        /// Deletes the selected account from the database.
        /// </summary>
        /// <param name="id">The account to delete.</param>
        void DeleteAccount(int id);
    }
}
