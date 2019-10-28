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

        /// <summary>
        /// Gets the content of the table.
        /// </summary>
        /// <returns>Returns a formatted string with the table data.</returns>
        public string GetRentData()
        {
            List<Rent> rents = this.GetAll().ToList();
            string formatted = string.Empty;
            foreach (var rent in rents)
            {
                formatted += string.Format($">> ID: {rent.rentID} | ACCOUNT: {rent.accountID} | CAR: {rent.carID} | START: {rent.starttime.ToString()} | END: {rent.endtime.ToString()} | DISTANCE: {rent.distance} | PRICE: {rent.price}\n");
            }

            return formatted;
        }

        /// <inheritdoc/>
        public void AddRent(Rent rent)
        {
            this.db.Rent.Add(rent);
            this.db.SaveChanges();
        }

        /// <summary>
        /// Adds a new rent to the database.
        /// </summary>
        /// <param name="rAccountId">The user who started the rent.</param>
        /// <param name="rCarId">The numberplate of the car that was used.</param>
        /// <param name="rStartTime">The start time of the rent.</param>
        /// <param name="rEndTime">The end time of the rent.</param>
        /// <param name="rDistance">The distance driven with the car.</param>
        /// <param name="rPrice">The price paid by the user.</param>
        public void AddRent(int rAccountId, string rCarId, DateTime rStartTime, DateTime rEndTime, int rDistance, int rPrice)
        {
            Rent r = new Rent()
            {
                accountID = rAccountId,
                carID = rCarId,
                starttime = rStartTime,
                endtime = rEndTime,
                distance = rDistance,
                price = rPrice,
            };
            this.AddRent(r);
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

        /// <summary>
        /// Gets the daily income of each month.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetDailyIncome()
        {
            string formatted = string.Empty;
            for (int i = 1; i <= 12; i++)
            {
                var daily = from x in this.GetAll()
                            where x.starttime.Month == i
                            group x by x.starttime.Day into g
                            select new
                            {
                                g.Key,
                                INCOME = g.Sum(x => x.price),
                            };
                if (daily.Count() != 0)
                {
                    formatted += string.Format($">> HÓNAP: {i}\n");
                    foreach (var item in daily)
                    {
                        formatted += string.Format($"> NAP: {item.Key}.\tBEVÉTEL: {item.INCOME} Ft\n");
                    }
                }
            }

            return formatted;
        }

        /// <summary>
        /// Gets the overall income and the daily average price of the rents.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetOverallIncome()
        {
            string formatted = string.Empty;
            var income = this.GetAll().Sum(x => x.price);
            var avg1 = from x in this.GetAll()
                          group x by x.starttime.Day into g
                          select new
                          {
                              Avg = g.Sum(x => x.price),
                          };
            var avg = avg1.Sum(x => x.Avg) / avg1.Count();
            formatted += string.Format($">> ÖSSZES BEVÉTEL: {income}\tÁTLAGOS NAPI BEVÉTEL: {avg}\n");
            return formatted;
        }
    }
}
