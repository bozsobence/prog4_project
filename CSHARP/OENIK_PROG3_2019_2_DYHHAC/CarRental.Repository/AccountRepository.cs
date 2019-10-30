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

        /// <inheritdoc/>
        public void AddAccount(Account account)
        {
            this.db.Account.Add(account);
            this.db.SaveChanges();
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
            if (name != string.Empty)
            {
                a.name = name;
            }

            if (email != string.Empty)
            {
                a.email = email;
            }

            if (address != string.Empty)
            {
                a.address = address;
            }

            if (bdate != DateTime.MinValue)
            {
                a.birthdate = bdate;
            }

            if (minute != -1)
            {
                a.minute = minute;
            }

            if (monthly != -1)
            {
                a.monthly = monthly;
            }

            this.db.SaveChanges();
        }
    }
}
