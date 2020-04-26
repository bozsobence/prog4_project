// <copyright file="Complaint.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the data transfer object for the complaint entity.
    /// </summary>
    public class Complaint
    {
        /// <summary>
        /// Gets or sets the complaint ID.
        /// </summary>
        public int ComplaintId { get; set; }

        /// <summary>
        /// Gets or sets the rent ID.
        /// </summary>
        public int RentId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets if the complaint is checked or not. Should be 0 or 1.
        /// </summary>
        public int Chk { get; set; }
    }
}
