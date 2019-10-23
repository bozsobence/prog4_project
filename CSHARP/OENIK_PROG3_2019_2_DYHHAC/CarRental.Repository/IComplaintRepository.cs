// <copyright file="IComplaintRepository.cs" company="PlaceholderCompany">
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
    /// Interface for Complaint Repository.
    /// </summary>
    /// <typeparam name="TComplaint">Generic parameter for Complaint object.</typeparam>
    public interface IComplaintRepository<TComplaint> : IRepository<TComplaint, int>
        where TComplaint : Complaint
    {
        /// <summary>
        /// Adds a new complaint to the database.
        /// </summary>
        /// <param name="complaint">The complaint to be added.</param>
        void AddComplaint(Complaint complaint);

        /// <summary>
        /// Updates the description of the selected complaint.
        /// </summary>
        /// <param name="id">The complaint to be updated.</param>
        /// <param name="desc">The new description of the selected complaint.</param>
        void UpdateDescription(int id, string desc);

        /// <summary>
        /// Updates the time of the selected complaint.
        /// </summary>
        /// <param name="id">The complaint to be updated.</param>
        /// <param name="newTime">The new time value to be set.</param>
        void UpdateTime(int id, DateTime newTime);

        /// <summary>
        /// Updates whether the complaint has been checked or not.
        /// </summary>
        /// <param name="id">The complaint to be updated.</param>
        /// <param name="newValue">The value to be set. Must be 0 or 1.</param>
        void UpdateChecked(int id, int newValue);

        /// <summary>
        /// Deletes the selected complaint from the database.
        /// </summary>
        /// <param name="id">The complaint to be deleted.</param>
        void DeleteComplaint(int id);
    }
}
