// <copyright file="RentRepository.cs" company="PlaceholderCompany">
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
    public class RentRepository : IRentRepository<Rent>
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
        public void AddRent(Rent rent)
        {
            this.db.Rent.Add(rent);
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteRent(int id)
        {
            this.db.Rent.Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<Rent> GetAll()
        {
            return this.db.Rent;
        }

        /// <inheritdoc/>
        public Rent GetOne(int id)
        {
            return this.db.Rent.Where(x => x.rentID == id).SingleOrDefault();
        }

        /// <inheritdoc/>
        public void UpdateRent(int id, int accId, string carId, DateTime startTime, DateTime endTime, int distance, int price)
        {
            Rent r = this.GetOne(id);
            r.accountID = accId;
            r.carID = carId;
            r.starttime = startTime;
            r.endtime = endTime;
            r.distance = distance;
            r.price = price;
            this.db.SaveChanges();
        }
    }
}
