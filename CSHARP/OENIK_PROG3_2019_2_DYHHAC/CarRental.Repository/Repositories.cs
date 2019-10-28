// <copyright file="Repositories.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;

    /// <summary>
    /// This is the main repository which contains the entity-specific repositories.
    /// </summary>
    public class Repositories
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Repositories"/> class.
        /// </summary>
        public Repositories()
        {
            this.Db = new CarRentalDatabaseEntities();
            this.AccountRepo = new AccountRepository(this.Db);
            this.CarRepo = new CarRepository(this.Db);
            this.LicenseRepo = new LicenseRepository(this.Db);
            this.RentRepo = new RentRepository(this.Db);
            this.ComplaintRepo = new ComplaintRepository(this.Db);
        }

        /// <summary>
        /// Gets the <see cref="AccountRepository"/>.
        /// </summary>
        public AccountRepository AccountRepo { get; }

        /// <summary>
        /// Gets database.
        /// </summary>
        public CarRentalDatabaseEntities Db { get; }

        /// <summary>
        /// Gets the <see cref="CarRepository"/>.
        /// </summary>
        public CarRepository CarRepo { get; }

        /// <summary>
        /// Gets the <see cref="LicenseRepository"/>.
        /// </summary>
        public LicenseRepository LicenseRepo { get; }

        /// <summary>
        /// Gets the <see cref="RentRepository"/>.
        /// </summary>
        public RentRepository RentRepo { get; }

        /// <summary>
        /// Gets the <see cref="ComplaintRepository"/>.
        /// </summary>
        public ComplaintRepository ComplaintRepo { get; }

        /// <summary>
        /// Gets the people who started the most and least rents.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetRentsByUser()
        {
            string formatted = string.Empty;
            var rents = (from rent in this.RentRepo.GetAll()
                         join account in this.AccountRepo.GetAll()
                         on rent.accountID equals account.accountID
                         group rent by rent.accountID into g
                         select new
                         {
                             ID = g.Key,
                             RENTS = g.Count(),
                         }).OrderByDescending(x => x.RENTS).FirstOrDefault();
            var mostRents = this.AccountRepo.GetOne(rents.ID).name;
            var count = rents.RENTS;
            formatted += string.Format($">> LEGTÖBB BÉRLÉS: {mostRents}\t {count} darab\n");
            return formatted;
        }

        /// <summary>
        /// Gets the distance driven with each car.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetDistanceByCar()
        {
            var distance = (from rent in this.RentRepo.GetAll()
                            join car in this.CarRepo.GetAll()
                            on rent.carID equals car.plate
                            group rent by car into g
                            select new
                            {
                                CAR = g.Key.plate,
                                KM = g.Sum(x => x.distance),
                            }).OrderByDescending(x => x.KM);
            string formatted = string.Empty;
            foreach (var car in distance)
            {
                formatted += string.Format($">> RENDSZÁM: {car.CAR}\tKM: {car.KM}\n");
            }

            return formatted;
        }

        /// <summary>
        /// Gets the users who are excluded from starting rents.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetExcludedUsers()
        {
            var users = from acc in this.AccountRepo.GetAll()
                        join lic in this.LicenseRepo.GetAll()
                        on acc.accountID equals lic.accountID
                        where DbFunctions.DiffYears(acc.birthdate, DateTime.Now) < 18 || lic.expiryDate.CompareTo(DateTime.Now) == -1 || lic.category.Contains("A")
                        select acc.name;

            string formatted = string.Empty;
            foreach (var user in users)
            {
                formatted += string.Format($">> NÉV: {user}\n");
            }

            return formatted;
        }
    }
}
