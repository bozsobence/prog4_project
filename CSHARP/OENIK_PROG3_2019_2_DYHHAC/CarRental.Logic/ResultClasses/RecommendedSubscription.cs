// <copyright file="RecommendedSubscription.cs" company="PlaceholderCompany">
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
    /// This class is used to store the data that the Java project returned.
    /// </summary>
    public class RecommendedSubscription
    {
        private int minute;
        private int monthly;
        private string name;
        private int fullPrice;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendedSubscription"/> class.
        /// </summary>
        /// <param name="minute">The price per minute.</param>
        /// <param name="monthly">The monthly price.</param>
        /// <param name="name">The name of the subscription.</param>
        /// <param name="fullPrice">The full price based on the time the user drives each month.</param>
        public RecommendedSubscription(int minute, int monthly, string name, int fullPrice)
        {
            this.minute = minute;
            this.monthly = monthly;
            this.name = name;
            this.fullPrice = fullPrice;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(">> AJÁNLOTT ELŐFIZETÉS <<\nNév: {0}\nPercdíj: {1} Ft\nHavidíj: {2} Ft\n\nVárható havi költség: {3} Ft\n\n", this.name, this.minute, this.monthly, this.fullPrice);
        }
    }
}
