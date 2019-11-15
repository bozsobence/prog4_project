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
            CarRentalDatabaseEntities db = new CarRentalDatabaseEntities();
            this.AccountRepo = new AccountRepository(db);
            this.CarRepo = new CarRepository(db);
            this.LicenseRepo = new LicenseRepository(db);
            this.RentRepo = new RentRepository(db);
            this.ComplaintRepo = new ComplaintRepository(db);
        }

        /// <summary>
        /// Gets or sets the <see cref="AccountRepository"/>.
        /// </summary>
        public virtual IAccountRepository<Account> AccountRepo { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="CarRepository"/>.
        /// </summary>
        public virtual ICarRepository<Car> CarRepo { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="LicenseRepository"/>.
        /// </summary>
        public virtual ILicenseRepository<License> LicenseRepo { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="RentRepository"/>.
        /// </summary>
        public virtual IRentRepository<Rent> RentRepo { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ComplaintRepository"/>.
        /// </summary>
        public virtual IComplaintRepository<Complaint> ComplaintRepo { get; set; }
    }
}
