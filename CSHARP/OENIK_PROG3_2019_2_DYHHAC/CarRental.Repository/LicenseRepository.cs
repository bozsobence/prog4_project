﻿// <copyright file="LicenseRepository.cs" company="PlaceholderCompany">
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

        // public string GetLicenseData()
        // {
        //    List<License> licenses = this.GetAll().ToList();
        //    string formatted = string.Empty;
        //    foreach (var lic in licenses)
        //    {
        //        formatted += string.Format($">> ID: {lic.licenseID} | ACCOUNT: {lic.accountID} | CATEGORY: {lic.category} | START: {lic.startDate.ToString()} | EXPIRES: {lic.expiryDate} | PENALTY POINTS: {lic.penaltyPoints}\n");
        //    }

        // return formatted;
        // }

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
        public void UpdateLicense(string id, int accId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints)
        {
            License l = this.GetOne(id);
            l.accountID = accId;
            l.category = category;
            l.startDate = startDate;
            l.expiryDate = expiryDate;
            l.penaltyPoints = penaltyPoints;
            this.db.SaveChanges();
        }
    }
}
