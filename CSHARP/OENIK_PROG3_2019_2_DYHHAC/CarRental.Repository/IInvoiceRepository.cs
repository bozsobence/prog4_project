// <copyright file="IInvoiceRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;

    /// <summary>
    /// Interface for the Invoice Repository.
    /// </summary>
    /// <typeparam name="TInvoice">Generic parameter for Invoice object.</typeparam>
    public interface IInvoiceRepository<TInvoice> : IRepository<TInvoice, int>
        where TInvoice : Invoice
    {
        /// <summary>
        /// Adds a new invoice to the database.
        /// </summary>
        /// <param name="invoice">The invoice to be added.</param>
        void AddInvoice(Invoice invoice);

        /// <summary>
        /// Updates the total amount of the selected invoice.
        /// </summary>
        /// <param name="id">The invoice to be updated.</param>
        /// <param name="newAmount">The new amount to be set.</param>
        void UpdateTotal(int id, int newAmount);

        /// <summary>
        /// Updates the completion state of the selected invoice.
        /// </summary>
        /// <param name="id">The invoice to be updated.</param>
        /// <param name="completed">The value to be set whether the invoice is paid or not. Must be 0 or 1.</param>
        void UpdateCompleted(int id, int completed);

        /// <summary>
        /// Updates the time when the invoice was created.
        /// </summary>
        /// <param name="id">The invoice to be updated.</param>
        /// <param name="newTime">The new time to be set.</param>
        void UpdateTime(int id, DateTime newTime);

        /// <summary>
        /// Deletes the selected invoice from the database.
        /// </summary>
        /// <param name="id">The invoice to be deleted.</param>
        void DeleteInvoice(int id);
    }
}
