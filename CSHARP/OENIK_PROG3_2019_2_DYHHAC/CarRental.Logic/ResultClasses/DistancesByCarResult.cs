// <copyright file="DistancesByCarResult.cs" company="PlaceholderCompany">
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
    /// This class contains the result of <see cref="IBusinessLogic.GetDistanceByCar"/>.
    /// </summary>
    public class DistancesByCarResult
    {
        /// <summary>
        /// Gets or sets the car.
        /// </summary>
        public string Car { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        public int Distance { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format($"> AUTÓ: {this.Car}\t\tMEGTETT TÁVOLSÁG: {this.Distance} KM");
        }
    }
}
