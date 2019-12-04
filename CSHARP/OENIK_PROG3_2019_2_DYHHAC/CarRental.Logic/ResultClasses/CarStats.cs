// <copyright file="CarStats.cs" company="PlaceholderCompany">
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
    /// This class contains the result of the <see cref="ILogic.GetCarStats(string)"/> method.
    /// </summary>
    public class CarStats
    {
        /// <summary>
        /// Gets or sets the car.
        /// </summary>
        public string Car { get; set; }

        /// <summary>
        /// Gets or sets the count of rents.
        /// </summary>
        public int CountOfRents { get; set; }

        /// <summary>
        /// Gets or sets the sum of price.
        /// </summary>
        public int SumOfPrice { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format($"> AUTÓ: {this.Car}\t\tBÉRLÉSEK SZÁMA: {this.CountOfRents}\t\tBEVÉTEL: {this.SumOfPrice} FT");
        }
    }
}
