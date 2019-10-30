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
            if (accId != -1)
            {
                r.accountID = accId;
            }

            if (carId != string.Empty)
            {
                r.carID = carId;
            }

            if (startTime != DateTime.MinValue)
            {
                r.starttime = startTime;
            }

            if (endTime != DateTime.MinValue)
            {
                r.endtime = endTime;
            }

            if (distance != -1)
            {
                r.distance = distance;
            }

            if (price != -1)
            {
                r.price = price;
            }

            this.db.SaveChanges();
        }

        // public string GetOverallIncome()
        // {
        //    string formatted = string.Empty;
        //    var income = this.GetAll().Sum(x => x.price);
        //    var avg1 = from x in this.GetAll()
        //                  group x by x.starttime.Day into g
        //                  select new
        //                  {
        //                      Avg = g.Sum(x => x.price),
        //                  };
        //    var avg = avg1.Sum(x => x.Avg) / avg1.Count();
        //    formatted += string.Format($">> ÖSSZES BEVÉTEL: {income}\tÁTLAGOS NAPI BEVÉTEL: {avg}\n");
        //    return formatted;
        // }
    }
}
