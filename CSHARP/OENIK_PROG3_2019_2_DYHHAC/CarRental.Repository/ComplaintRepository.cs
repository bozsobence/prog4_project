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
    public class ComplaintRepository : IComplaintRepository<Complaint>
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
        public void AddComplaint(Complaint complaint)
        {
            this.db.Complaint.Add(complaint);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteComplaint(int id)
        {
            this.db.Complaint.Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Complaint> GetAll()
        {
            return this.db.Complaint;
        }

        /// <inheritdoc/>
        public Complaint GetOne(int id)
        {
            return this.db.Complaint.Where(x => x.complaintID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateChecked(int id, int newValue)
        {
            Complaint com = this.GetOne(id);
            com.@checked = newValue;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateDescription(int id, string desc)
        {
            Complaint com = this.GetOne(id);
            com.description = desc;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateTime(int id, DateTime newTime)
        {
            Complaint com = this.GetOne(id);
            com.time = newTime;
            this.db.SaveChanges();
        }
    }
}
