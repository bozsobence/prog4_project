﻿// <copyright file="DailyIncomeResult.cs" company="PlaceholderCompany">
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
    /// This class contains the result of <see cref="ILogic.GetDailyIncome"/>.
    /// </summary>
    public class DailyIncomeResult
    {
        /// <summary>
        /// Gets or sets the month.
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Gets or sets the income.
        /// </summary>
        public int Income { get; set; }
        public override string ToString()
        {
            return string.Format($"> DAY: {this.Day}\tINCOME: {this.Income} Ft");
        }
    }
}
