// <copyright file="RentsByUserResult.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class contains the result of <see cref="ILogic.GetUserWithMostRents"/>.
    /// </summary>
    public class RentsByUserResult
    {
        /// <summary>
        /// Gets or sets the account name.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        public int Count { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format($"> NÉV: {this.AccountName}\tBÉRLÉSEK SZÁMA: {this.Count}");
        }
    }
}
