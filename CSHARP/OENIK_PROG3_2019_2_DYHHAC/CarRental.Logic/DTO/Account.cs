// <copyright file="Account.cs" company="PlaceholderCompany">
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
    /// This is the data transfer object for the Account entity.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the ID of the account.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of the account.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the price per minute.
        /// </summary>
        public int? Minute { get; set; }

        /// <summary>
        /// Gets or sets the monthly price.
        /// </summary>
        public int? Monthly { get; set; }
    }
}
