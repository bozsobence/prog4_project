﻿// <copyright file="IAccountRepository.cs" company="PlaceholderCompany">
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
        /// Adds a new account to the database.
        /// </summary>
        /// <param name="accName">The name of the user.</param>
        /// <param name="accEmail">The email of the user.</param>
        /// <param name="accAddress">The city where the user lives.</param>
        /// <param name="bdate">The birth date of the user.</param>
        /// <param name="min">The price per minute the user will pay for the rents.</param>
        /// <param name="month">The monthly price the user will pay for the services.</param>
        void AddAccount(string accName, string accEmail, string accAddress, DateTime bdate, int min, int month);

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
        void UpdateAccount(int id, string name, string email, string address, DateTime bdate, int minute, int monthly);

        /// <summary>
        /// Deletes the selected account from the database.
        /// </summary>
        /// <param name="id">The account to delete.</param>
        void DeleteAccount(int id);
    }
}
