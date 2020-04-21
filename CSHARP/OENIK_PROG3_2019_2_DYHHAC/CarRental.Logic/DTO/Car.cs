// <copyright file="Car.cs" company="PlaceholderCompany">
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
    /// Ths is the data transfer object for the car entity.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Gets or sets the car ID.
        /// </summary>
        public string CarId { get; set; }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the battery.
        /// </summary>
        public int Battery { get; set; }

        /// <summary>
        /// Gets or sets the extra price.
        /// </summary>
        public int? ExtraPrice { get; set; }
    }
}
