﻿// <copyright file="Repositories.cs" company="PlaceholderCompany">
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
    /// This is the main repository which contains the entity-specific repositories.
    /// </summary>
    public class Repositories
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repositories"/> class.
        /// </summary>
        /// <param name="db">The database entities object.</param>
        public Repositories(CarRentalDatabaseEntities db)
        {
            this.AccountRepo = new AccountRepository(db);
            this.CarRepo = new CarRepository(db);
            this.LicenseRepo = new LicenseRepository(db);
            this.RentRepo = new RentRepository(db);
            this.SubscriptionRepo = new SubscriptionRepository(db);
            this.InvoiceRepo = new InvoiceRepository(db);
            this.ComplaintRepo = new ComplaintRepository(db);
        }

        /// <summary>
        /// Gets the <see cref="AccountRepository"/>.
        /// </summary>
        public AccountRepository AccountRepo { get; }

        /// <summary>
        /// Gets the <see cref="CarRepository"/>.
        /// </summary>
        public CarRepository CarRepo { get; }

        /// <summary>
        /// Gets the <see cref="LicenseRepository"/>.
        /// </summary>
        public LicenseRepository LicenseRepo { get; }

        /// <summary>
        /// Gets the <see cref="RentRepository"/>.
        /// </summary>
        public RentRepository RentRepo { get; }

        /// <summary>
        /// Gets the <see cref="SubscriptionRepository"/>.
        /// </summary>
        public SubscriptionRepository SubscriptionRepo { get; }

        /// <summary>
        /// Gets the <see cref="InvoiceRepository"/>.
        /// </summary>
        public InvoiceRepository InvoiceRepo { get; }

        /// <summary>
        /// Gets the <see cref="ComplaintRepository"/>.
        /// </summary>
        public ComplaintRepository ComplaintRepo { get; }
    }
}