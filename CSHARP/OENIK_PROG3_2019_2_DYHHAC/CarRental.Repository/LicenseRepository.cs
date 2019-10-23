// <copyright file="LicenseRepository.cs" company="PlaceholderCompany">
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
    /// This repository handles the License table in the database.
    /// </summary>
    public class LicenseRepository : ILicenseRepository<License>
    {
        private CarRentalDatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="LicenseRepository"/> class.
        /// </summary>
        /// <param name="db">The database entities object.</param>
        public LicenseRepository(CarRentalDatabaseEntities db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public void AddLicense(License license)
        {
            this.db.License.Add(license);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteLicense(string id)
        {
            License lic = this.GetOne(id);
            this.db.License.Remove(lic);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<License> GetAll()
        {
            return this.db.License;
        }

        /// <inheritdoc/>
        public License GetOne(string id)
        {
            return this.db.License.Where(x => x.licenseID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateCategory(string id, string newCat)
        {
            License lic = this.GetOne(id);
            lic.category = newCat;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateExpiryDate(string id, DateTime newDate)
        {
            License lic = this.GetOne(id);
            lic.expiryDate = newDate;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdatePenaltyPoints(string id, int newPoints)
        {
            License lic = this.GetOne(id);
            lic.penaltyPoints = newPoints;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateStartDate(string id, DateTime newDate)
        {
            License lic = this.GetOne(id);
            lic.startDate = newDate;
            this.db.SaveChanges();
        }
    }
}
