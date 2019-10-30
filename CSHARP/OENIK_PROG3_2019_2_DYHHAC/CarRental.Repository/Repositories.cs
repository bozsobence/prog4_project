// <copyright file="Repositories.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;

    /// <summary>
    /// This is the main repository which contains the entity-specific repositories.
    /// </summary>
    public class Repositories
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repositories"/> class.
        /// </summary>
        public Repositories()
        {
            this.Db = new CarRentalDatabaseEntities();
            this.AccountRepo = new AccountRepository(this.Db);
            this.CarRepo = new CarRepository(this.Db);
            this.LicenseRepo = new LicenseRepository(this.Db);
            this.RentRepo = new RentRepository(this.Db);
            this.ComplaintRepo = new ComplaintRepository(this.Db);
        }

        /// <summary>
        /// Gets the <see cref="AccountRepository"/>.
        /// </summary>
        public IAccountRepository<Account> AccountRepo { get; }

        /// <summary>
        /// Gets database.
        /// </summary>
        public CarRentalDatabaseEntities Db { get; }

        /// <summary>
        /// Gets the <see cref="CarRepository"/>.
        /// </summary>
        public ICarRepository<Car> CarRepo { get; }

        /// <summary>
        /// Gets the <see cref="LicenseRepository"/>.
        /// </summary>
        public ILicenseRepository<License> LicenseRepo { get; }

        /// <summary>
        /// Gets the <see cref="RentRepository"/>.
        /// </summary>
        public IRentRepository<Rent> RentRepo { get; }

        /// <summary>
        /// Gets the <see cref="ComplaintRepository"/>.
        /// </summary>
        public IComplaintRepository<Complaint> ComplaintRepo { get; }
    }
}
