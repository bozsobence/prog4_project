// <copyright file="InvoiceRepository.cs" company="PlaceholderCompany">
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
    /// This is the repository that handles the Invoice table in the database.
    /// </summary>
    public class InvoiceRepository : IInvoiceRepository<Invoice>
    {
        private CarRentalDatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceRepository"/> class.
        /// </summary>
        /// <param name="db">The database entities object.</param>
        public InvoiceRepository(CarRentalDatabaseEntities db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public void AddInvoice(Invoice invoice)
        {
            this.db.Invoice.Add(invoice);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteInvoice(int id)
        {
            this.db.Invoice.Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Invoice> GetAll()
        {
            return this.db.Invoice;
        }

        /// <inheritdoc/>
        public Invoice GetOne(int id)
        {
            return this.db.Invoice.Where(x => x.invoiceID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateCompleted(int id, int completed)
        {
            Invoice inv = this.GetOne(id);
            inv.completed = completed;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateTime(int id, DateTime newTime)
        {
            Invoice inv = this.GetOne(id);
            inv.time = newTime;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateTotal(int id, int newAmount)
        {
            Invoice inv = this.GetOne(id);
            inv.total = newAmount;
            this.db.SaveChanges();
        }
    }
}
