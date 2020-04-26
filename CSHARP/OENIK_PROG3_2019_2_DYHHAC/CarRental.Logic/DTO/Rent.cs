// <copyright file="Rent.cs" company="PlaceholderCompany">
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
    /// This is the data transfer object for the Rent entity.
    /// </summary>
    public class Rent
    {
        /// <summary>
        /// Gets or sets the rent ID.
        /// </summary>
        public int RentId { get; set; }

        /// <summary>
        /// Gets or sets the account ID.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the car ID.
        /// </summary>
        public string CarId { get; set; }

        /// <summary>
        /// Gets or sets the start time.
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public int? Distance { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public int? Price { get; set; }
    }
}
