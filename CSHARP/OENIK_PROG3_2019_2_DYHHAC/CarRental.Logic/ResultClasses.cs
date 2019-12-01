// <copyright file="ResultClasses.cs" company="PlaceholderCompany">
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
    /// This class contains the result classes of the <see cref="ILogic"/> functions.
    /// </summary>
    public static class ResultClasses
    {
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

            /// <inheritdoc/>
            public override string ToString()
            {
                return string.Format($"> NAP: {this.Day}.\tBEVÉTEL: {this.Income} Ft");
            }
        }

        /// <summary>
        /// This class contains the result of <see cref="ILogic.GetOverallIncome"/>.
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

        /// <summary>
        /// This class contains the result of <see cref="ILogic.GetDistanceByCar"/>.
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
}
