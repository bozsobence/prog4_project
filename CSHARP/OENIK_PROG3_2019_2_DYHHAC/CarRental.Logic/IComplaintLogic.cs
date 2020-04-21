// <copyright file="IComplaintLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Logic.DTO;

    /// <summary>
    /// Defines the public methods of the class responsible for the CRUD operations of the Complaints table.
    /// </summary>
    public interface IComplaintLogic
    {
        /// <summary>
        /// Gets all data from the Complaint table.
        /// </summary>
        /// <returns>Returns the data from the Account table in a formatted string.</returns>
        IEnumerable<Complaint> GetComplaintData();

        /// <summary>
        /// Checks if the given complaint exists in the database.
        /// </summary>
        /// <param name="id">The ID of the complaint.</param>
        /// <returns>True or false.</returns>
        bool IsValidComplaint(int id);

        /// <summary>
        /// Adds a new complaint to the database.
        /// </summary>
        /// <param name="rentId">The rent which the complaint refers to.</param>
        /// <param name="desc">The description of the complaint.</param>
        /// <param name="time">The time the complaint was filed.</param>
        /// <param name="chk">1 or 0, whether the complaint was handled by the service provider.</param>
        /// <returns>True or false whether the insertion was successful or not.</returns>
        bool AddNewComplaint(int rentId, string desc, DateTime time, int chk);

        /// <summary>
        /// Updates the selected complaint data.
        /// </summary>
        /// <param name="id">The complaint we want to update.</param>
        /// <param name="rentId">The rent which the complaint refers to.</param>
        /// <param name="desc">The new description to be set.</param>
        /// <param name="time">The new time to be set.</param>
        /// <param name="chk">The new check status to be set. Must be 1 or 0.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateComplaintData(int id, int rentId, string desc, DateTime time, int chk);

        /// <summary>
        /// Deletes the selected complaint from the database.
        /// </summary>
        /// <param name="id">The complaint we want to delete.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteComplaintData(int id);
    }
}
