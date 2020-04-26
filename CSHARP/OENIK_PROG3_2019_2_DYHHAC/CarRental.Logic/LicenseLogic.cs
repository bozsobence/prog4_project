// <copyright file="LicenseLogic.cs" company="PlaceholderCompany">
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
    /// This class is responsible for the CRUD operations of the Licenses table.
    /// </summary>
    public class LicenseLogic : ILicenseLogic
    {
        private IRepository<License, string> licenseRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseLogic"/> class.
        /// </summary>
        /// <param name="licenses">The repository that handles the licenses table.</param>
        public LicenseLogic(IRepository<License, string> licenses)
        {
            this.licenseRepo = licenses;
        }

        /// <inheritdoc/>
        public bool AddNewLicense(string licenseId, int accountId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints)
        {
            License lic = new License()
            {
                LicenseId = licenseId,
                AccountId = accountId,
                Category = category,
                StartDate = startDate,
                ExpiryDate = expiryDate,
                PenaltyPoints = penaltyPoints,
            };

            if (startDate == DateTime.MinValue || expiryDate == DateTime.MinValue)
            {
                return false;
            }

            try
            {
                this.licenseRepo.Add(lic);
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
        public bool DeleteLicenseData(string licenseId)
        {
            try
            {
                this.licenseRepo.Delete(licenseId);
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
        public IEnumerable<DTO.License> GetLicenseData()
        {
            return MapperFactory.CreateMapper().Map<IEnumerable<CarRental.Data.License>, IEnumerable<CarRental.Logic.DTO.License>>(this.licenseRepo.GetAll());
        }

        /// <inheritdoc/>
        public bool IsValidLicense(string licenseId)
        {
            try
            {
                this.licenseRepo.GetOne(licenseId);
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
        public bool UpdateLicenseData(string id, int accId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints)
        {
            if (this.IsValidLicense(id))
            {
                License l = new License()
                {
                    AccountId = accId,
                    Category = category,
                    StartDate = startDate,
                    ExpiryDate = expiryDate,
                    PenaltyPoints = penaltyPoints,
                };
                this.licenseRepo.Update(id, l);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
