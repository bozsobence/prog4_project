// <copyright file="ComplaintRepository.cs" company="PlaceholderCompany">
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
    /// This is the repository that handles the Complaint table in the database.
    /// </summary>
    public class ComplaintRepository : IRepository<Complaint, int>
    {
        private CarRentalDatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplaintRepository"/> class.
        /// </summary>
        /// <param name="db">The database entities object.</param>
        public ComplaintRepository(CarRentalDatabaseEntities db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public void Add(Complaint element)
        {
            this.db.Complaints.Add(element);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            Complaint c = this.GetOne(id);
            this.db.Complaints.Remove(c);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Complaint> GetAll()
        {
            return this.db.Complaints;
        }

        /// <inheritdoc/>
        public Complaint GetOne(int id)
        {
            return this.GetAll().Where(x => x.ComplaintId == id).Single();
        }

        /// <inheritdoc/>
        public void Update(int id, Complaint newData)
        {
            Complaint c = this.GetOne(id);
            if (newData.RentId != -1)
            {
                c.RentId = newData.RentId;
            }

            if (newData.Description != string.Empty)
            {
                c.Description = newData.Description;
            }

            if (newData.Time != DateTime.MinValue)
            {
                c.Time = newData.Time;
            }

            if (newData.Chk != -1)
            {
                c.Chk = newData.Chk;
            }

            this.db.SaveChanges();
        }
    }
}
