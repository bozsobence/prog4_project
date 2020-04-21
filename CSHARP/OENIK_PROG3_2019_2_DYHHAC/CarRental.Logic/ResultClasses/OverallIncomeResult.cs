// <copyright file="OverallIncomeResult.cs" company="PlaceholderCompany">
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
    /// This class contains the result of <see cref="IBusinessLogic.GetOverallIncome"/>.
    /// </summary>
    public class OverallIncomeResult
    {
        /// <summary>
        /// Gets or sets the overall income.
        /// </summary>
        public int OverallIncome { get; set; }

        /// <summary>
        /// Gets or sets the average income per day.
        /// </summary>
        public double Average { get; set; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format($"> ÖSSZESÍTETT BEVÉTEL: {this.OverallIncome}\tÁTLAGOS NAPI BEVÉTEL: {this.Average}");
        }
    }
}
