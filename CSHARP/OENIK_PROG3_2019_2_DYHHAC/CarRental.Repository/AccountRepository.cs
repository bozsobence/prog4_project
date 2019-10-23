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
            Account acc = this.db.Account.Where(x => x.accountID == id).Single();
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
            return this.db.Account.Where(x => x.accountID == id).Single();
        }

        /// <inheritdoc/>
        public void UpdateAddress(int id, string newAddress)
        {
            Account acc = this.GetOne(id);
            acc.address = newAddress;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateEmail(int id, string newMail)
        {
            Account acc = this.GetOne(id);
            acc.email = newMail;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateName(int id, string newName)
        {
            Account acc = this.GetOne(id);
            acc.name = newName;
            this.db.SaveChanges();
        }
    }
}
