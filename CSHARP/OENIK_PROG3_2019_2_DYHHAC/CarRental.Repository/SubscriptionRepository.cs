// <copyright file="SubscriptionRepository.cs" company="PlaceholderCompany">
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
    /// This is the repository that handles the Subscription table in the database.
    /// </summary>
    public class SubscriptionRepository : ISubscriptionRepository<Subscription>
    {
        private CarRentalDatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionRepository"/> class.
        /// </summary>
        /// <param name="db">The database entities object.</param>
        public SubscriptionRepository(CarRentalDatabaseEntities db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public void AddSubscription(Subscription subscription)
        {
            this.db.Subscription.Add(subscription);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteSubscription(int id)
        {
            this.db.Subscription.Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Subscription> GetAll()
        {
            return this.db.Subscription;
        }

        /// <inheritdoc/>
        public Subscription GetOne(int id)
        {
            return this.db.Subscription.Where(x => x.subID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateCompany(int id, int company)
        {
            Subscription sub = this.GetOne(id);
            sub.company = company;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateMinute(int id, int newMinute)
        {
            Subscription sub = this.GetOne(id);
            sub.minute = newMinute;
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void UpdateMonthly(int id, int newMonthly)
        {
            Subscription sub = this.GetOne(id);
            sub.monthly = newMonthly;
            this.db.SaveChanges();
        }
    }
}
