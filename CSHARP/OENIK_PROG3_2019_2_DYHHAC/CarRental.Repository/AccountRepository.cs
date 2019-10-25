// <copyright file="AccountRepository.cs" company="PlaceholderCompany">
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
    /// The repository that handles the Accounts table in the database.
    /// </summary>
    public class AccountRepository : IAccountRepository<Account>
    {
        private CarRentalDatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountRepository"/> class.
        /// </summary>
        /// <param name="db">The database entities object.</param>
        public AccountRepository(CarRentalDatabaseEntities db)
        {
            this.db = db;
        }

        /// <summary>
        /// Gets the content of the table.
        /// </summary>
        /// <returns>Returns a formatted string with the table data.</returns>
        public string GetAccountData()
        {
            List<Account> accData = this.GetAll().ToList();
            string formatted = string.Empty;
            foreach (var acc in accData)
            {
                formatted += string.Format($">>ID: {acc.accountID} | Name: {acc.name} | Email: {acc.email} | Address: {acc.address} | Birth date: {acc.birthdate.ToString()} | Price per minute: {acc.minute} | Monthly price: {acc.monthly}\n");
            }

            return formatted;
        }

        /// <inheritdoc/>
        public void AddAccount(Account account)
        {
            this.db.Account.Add(account);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Adds a new account to the database.
        /// </summary>
        /// <param name="accName">The name of the user.</param>
        /// <param name="accEmail">The email of the user.</param>
        /// <param name="accAddress">The city where the user lives.</param>
        /// <param name="bdate">The birth date of the user.</param>
        /// <param name="min">The price per minute the user will pay for the rents.</param>
        /// <param name="month">The monthly price the user will pay for the services.</param>
        public void AddAccount(string accName, string accEmail, string accAddress, DateTime bdate, int min, int month)
        {
            Account acc = new Account()
            {
                name = accName,
                email = accEmail,
                address = accAddress,
                birthdate = bdate,
                minute = min,
                monthly = month,
            };
            this.AddAccount(acc);
        }

        /// <inheritdoc/>
        public void DeleteAccount(int id)
        {
            Account acc = this.GetOne(id);
            this.db.Account.Remove(acc);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Account> GetAll()
        {
            return this.db.Account;
        }

        /// <inheritdoc/>
        public Account GetOne(int id)
        {
            return this.db.Account.Where(x => x.accountID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateAccount(int id, string name, string email, string address, DateTime bdate, int minute, int monthly)
        {
            Account a = this.GetOne(id);
            a.name = name;
            a.email = email;
            a.address = address;
            a.birthdate = bdate;
            a.minute = minute;
            a.monthly = monthly;
            this.db.SaveChanges();
        }
    }
}
