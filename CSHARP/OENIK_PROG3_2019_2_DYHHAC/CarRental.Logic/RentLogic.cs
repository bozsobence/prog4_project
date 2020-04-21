// <copyright file="RentLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;
    using CarRental.Repository;

    /// <summary>
    /// This class is responsible for the CRUD operations of the Rents table.
    /// </summary>
    public class RentLogic : IRentLogic
    {
        private IRepository<Rent, int> rentRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentLogic"/> class.
        /// </summary>
        /// <param name="rents">The repoository that handles the rents table.</param>
        public RentLogic(IRepository<Rent, int> rents)
        {
            this.rentRepo = rents;
        }

        /// <inheritdoc/>
        public bool AddNewRent(int accountId, string carId, DateTime startTime, DateTime endTime, int distance, int price)
        {
            Rent r = new Rent()
            {
                AccountId = accountId,
                CarId = carId,
                StartTime = startTime,
                EndTime = endTime,
                Distance = distance,
                Price = price,
            };

            if (startTime == DateTime.MinValue || endTime == DateTime.MinValue)
            {
                return false;
            }

            try
            {
                this.rentRepo.Add(r);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteRentData(int id)
        {
            try
            {
                this.rentRepo.Delete(id);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public IQueryable<Rent> GetRentData()
        {
            return this.rentRepo.GetAll();
        }

        /// <inheritdoc/>
        public bool IsValidRent(int id)
        {
            try
            {
                this.rentRepo.GetOne(id);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateRentData(int id, int accId, string carId, DateTime startTime, DateTime endTime, int distance, int price)
        {
            if (this.IsValidRent(id))
            {
                Rent r = new Rent()
                {
                    AccountId = accId,
                    CarId = carId,
                    StartTime = startTime,
                    EndTime = endTime,
                    Distance = distance,
                    Price = price,
                };
                this.rentRepo.Update(id, r);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
