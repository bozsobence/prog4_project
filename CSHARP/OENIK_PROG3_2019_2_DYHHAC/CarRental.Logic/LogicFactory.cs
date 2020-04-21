// <copyright file="LogicFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;
    using CarRental.Repository;

    /// <summary>
    /// This class is responsible for creating logic instances.
    /// </summary>
    public class LogicFactory
    {
        private CarRentalDatabaseEntities db;
        private IRepository<Account, int> accountRepo;
        private IRepository<Car, string> carRepo;
        private IRepository<License, string> licenseRepo;
        private IRepository<Rent, int> rentRepo;
        private IRepository<Complaint, int> complaintRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicFactory"/> class.
        /// </summary>
        public LogicFactory()
        {
            this.db = new CarRentalDatabaseEntities();
            this.accountRepo = new AccountRepository(this.db);
            this.carRepo = new CarRepository(this.db);
            this.complaintRepo = new ComplaintRepository(this.db);
            this.rentRepo = new RentRepository(this.db);
            this.licenseRepo = new LicenseRepository(this.db);

        }

        /// <summary>
        /// Creates an instance of the account logic.
        /// </summary>
        /// <returns>Returns <see cref="IAccountLogic"/>.</returns>
        public IAccountLogic GetAccountLogic()
        {
            return new AccountLogic(this.accountRepo);
        }

        /// <summary>
        /// Creates an instance of the car logic.
        /// </summary>
        /// <returns>Returns <see cref="ICarLogic"/>.</returns>
        public ICarLogic GetCarLogic()
        {
            return new CarLogic(this.carRepo);
        }

        /// <summary>
        /// Creates an instance of the license logic.
        /// </summary>
        /// <returns>Returns <see cref="ILicenseLogic"/>.</returns>
        public ILicenseLogic GetLicenseLogic()
        {
            return new LicenseLogic(this.licenseRepo);
        }

        /// <summary>
        /// Creates an instance of the rent logic.
        /// </summary>
        /// <returns>Returns <see cref="IRentLogic"/>.</returns>
        public IRentLogic GetRentLogic()
        {
            return new RentLogic(this.rentRepo);
        }

        /// <summary>
        /// Creates an instance of the complaint logic.
        /// </summary>
        /// <returns>Returns <see cref="IComplaintLogic"/>.</returns>
        public IComplaintLogic GetComplaintLogic()
        {
            return new ComplaintLogic(this.complaintRepo);
        }

        /// <summary>
        /// Creates an instance of the business logic.
        /// </summary>
        /// <returns>Returns <see cref="IBusinessLogic"/>.</returns>
        public IBusinessLogic GetBusinessLogic()
        {
            return new BusinessLogic(this.accountRepo, this.carRepo, this.licenseRepo, this.rentRepo, this.complaintRepo);
        }
    }
}
