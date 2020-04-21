// <copyright file="AccountLogic.cs" company="PlaceholderCompany">
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
    using CarRental.Repository;

    /// <summary>
    /// This class is responsible for the CRUD operations of the Accounts table.
    /// </summary>
    public class AccountLogic : IAccountLogic
    {
        private IRepository<Account, int> accountRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountLogic"/> class.
        /// </summary>
        /// <param name="accounts">The repository that handles the accounts table.</param>
        public AccountLogic(IRepository<Account, int> accounts)
        {
            this.accountRepo = accounts;
        }

        /// <inheritdoc/>
        public bool AddNewAccount(string name, string email, string address, DateTime bdate, int minute, int monthly)
        {
            Account acc = new Account()
            {
                Name = name,
                Email = email,
                Address = address,
                BirthDate = bdate,
                Minute = minute,
                Monthly = monthly,
            };

            if (bdate == DateTime.MinValue)
            {
                return false;
            }

            try
            {
                this.accountRepo.Add(acc);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteAccountData(int accountId)
        {
            try
            {
                this.accountRepo.Delete(accountId);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public IQueryable<Account> GetAccountData()
        {
            return this.accountRepo.GetAll();
        }

        /// <inheritdoc/>
        public bool IsValidAccount(int id)
        {
            try
            {
                this.accountRepo.GetOne(id);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateAccountData(int id, string name, string email, string address, DateTime bdate, int minute, int monthly)
        {
            if (this.IsValidAccount(id))
            {
                Account acc = new Account()
                {
                    Name = name,
                    Email = email,
                    Address = address,
                    BirthDate = bdate,
                    Minute = minute,
                    Monthly = monthly,
                };
                this.accountRepo.Update(id, acc);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
