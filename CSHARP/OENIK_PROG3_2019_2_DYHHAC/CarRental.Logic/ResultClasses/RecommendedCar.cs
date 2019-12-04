// <copyright file="RecommendedCar.cs" company="PlaceholderCompany">
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
    /// This is class is used to store the data that the Java project returned.
    /// </summary>
    public class RecommendedCar
    {
        private string brand;
        private string model;
        private int extraPrice;
        private string size;
        private string category;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecommendedCar"/> class.
        /// </summary>
        /// <param name="brand">The brand of the car.</param>
        /// <param name="model">The model of the car.</param>
        /// <param name="extraPrice">The extra price of the car.</param>
        /// <param name="size">The size of the car.</param>
        /// <param name="category">The category of the car.</param>
        public RecommendedCar(string brand, string model, int extraPrice, string size, string category)
        {
            this.brand = brand;
            this.model = model;
            this.extraPrice = extraPrice;
            this.size = size;
            this.category = category;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("Márka: {0}\nModell: {1}\nMéret: {2}\nKategória: {3}\nExtra felár: {4} Ft/perc\n\n", this.brand, this.model, this.size, this.category, this.extraPrice);
        }
    }
}
