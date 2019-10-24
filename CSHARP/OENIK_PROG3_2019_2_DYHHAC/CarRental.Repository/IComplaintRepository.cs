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
        /// Updates the selected complaint data.
        /// </summary>
        /// <param name="id">The complaint we want to update.</param>
        /// <param name="rentId">The rent which the complaint refers to.</param>
        /// <param name="desc">The new description to be set.</param>
        /// <param name="time">The new time to be set.</param>
        /// <param name="chk">The new check status to be set. Must be 1 or 0.</param>
        void UpdateComplaint(int id, int rentId, string desc, DateTime time, int chk);

        /// <summary>
        /// Deletes the selected complaint from the database.
        /// </summary>
        /// <param name="id">The complaint to be deleted.</param>
        void DeleteComplaint(int id);
    }
}
