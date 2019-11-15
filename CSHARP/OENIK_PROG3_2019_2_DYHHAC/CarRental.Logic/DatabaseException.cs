// <copyright file="DatabaseException.cs" company="PlaceholderCompany">
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
    /// This exception is thrown when there is an error with a database function.
    /// </summary>
    public class DatabaseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseException"/> class.
        /// </summary>
        /// <param name="msg">The message to be shown.</param>
        public DatabaseException(string msg)
        {
            this.Message = msg;
        }

        /// <inheritdoc/>
        public override string Message { get; }
    }
}
