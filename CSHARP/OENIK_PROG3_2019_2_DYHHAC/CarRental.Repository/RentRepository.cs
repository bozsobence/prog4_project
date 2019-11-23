﻿// <copyright file="RentRepository.cs" company="PlaceholderCompany">
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
    /// This is the repository that handles the Rent table in the database.
    /// </summary>
    public class RentRepository : IRepository<Rent, int>
    {
        private CarRentalDatabaseEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentRepository"/> class.
        /// </summary>
        /// <param name="db">The database entities object.</param>
        public RentRepository(CarRentalDatabaseEntities db)
        {
            this.db = db;
        }

        /// <inheritdoc/>
        public void Add(Rent rent)
        {
            this.db.Rents.Add(rent);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            Rent r = this.GetOne(id);
            this.db.Rents.Remove(r);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Rent> GetAll()
        {
            return this.db.Rents;
        }

        /// <inheritdoc/>
        public Rent GetOne(int id)
        {
            return this.db.Rents.Where(x => x.RentID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void Update(int id, Rent newData)
        {
            Rent r = this.GetOne(id);
            if (newData.AccountID != -1)
            {
                r.AccountID = newData.AccountID;
            }

            if (newData.CarID != string.Empty)
            {
                r.CarID = newData.CarID;
            }

            if (newData.StartTime != DateTime.MinValue)
            {
                r.StartTime = newData.StartTime;
            }

            if (newData.EndTime != DateTime.MinValue)
            {
                r.EndTime = newData.EndTime;
            }

            if (newData.Distance != -1)
            {
                r.Distance = newData.Distance;
            }

            if (newData.Price != -1)
            {
                r.Price = newData.Price;
            }

            this.db.SaveChanges();
        }
    }
}
