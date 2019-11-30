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
    public class LicenseRepository : IRepository<License, string>
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
        public void Add(License element)
        {
            this.db.Licenses.Add(element);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(string id)
        {
            License lic = this.GetOne(id);
            this.db.Licenses.Remove(lic);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<License> GetAll()
        {
            return this.db.Licenses;
        }

        /// <inheritdoc/>
        public License GetOne(string id)
        {
            return this.GetAll().Where(x => x.LicenseId == id).Single();
        }

        /// <inheritdoc/>
        public void Update(string id, License newData)
        {
            License l = this.GetOne(id);
            if (newData.AccountId != -1)
            {
                l.AccountId = newData.AccountId;
            }

            if (newData.Category != string.Empty)
            {
                l.Category = newData.Category;
            }

            if (newData.StartDate != DateTime.MinValue)
            {
                l.StartDate = newData.StartDate;
            }

            if (newData.ExpiryDate != DateTime.MinValue)
            {
                l.ExpiryDate = newData.ExpiryDate;
            }

            if (newData.PenaltyPoints != -1)
            {
                l.PenaltyPoints = newData.PenaltyPoints;
            }

            this.db.SaveChanges();
        }
    }
}
