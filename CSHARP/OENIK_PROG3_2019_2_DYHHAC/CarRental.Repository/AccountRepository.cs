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
    public class AccountRepository : IRepository<Account, int>
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
        public void Add(Account account)
        {
            this.db.Accounts.Add(account);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            Account acc = this.GetOne(id);
            this.db.Accounts.Remove(acc);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Account> GetAll()
        {
            return this.db.Accounts;
        }

        /// <inheritdoc/>
        public Account GetOne(int id)
        {
            return this.db.Accounts.Where(x => x.AccountID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void Update(int id, Account newData)
        {
            Account a = this.GetOne(id);
            if (newData.Name != string.Empty)
            {
                a.Name = newData.Name;
            }

            if (newData.Email != string.Empty)
            {
                a.Email = newData.Email;
            }

            if (newData.Address != string.Empty)
            {
                a.Address = newData.Address;
            }

            if (newData.BirthDate != DateTime.MinValue)
            {
                a.BirthDate = newData.BirthDate;
            }

            if (newData.Minute != -1)
            {
                a.Minute = newData.Minute;
            }

            if (newData.Monthly != -1)
            {
                a.Monthly = newData.Monthly;
            }

            this.db.SaveChanges();
        }
    }
}
