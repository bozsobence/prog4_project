// <copyright file="License.cs" company="PlaceholderCompany">
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
    /// This is the data transfer object for the license entity.
    /// </summary>
    public class License
    {
        /// <summary>
        /// Gets or sets the license ID.
        /// </summary>
        public string LicenseId { get; set; }

        /// <summary>
        /// Gets or sets the account ID.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the expiry date.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Gets or sets the penalty points.
        /// </summary>
        public int? PenaltyPoints { get; set; }
    }
}
