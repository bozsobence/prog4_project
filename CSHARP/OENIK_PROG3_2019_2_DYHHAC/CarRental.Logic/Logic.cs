// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;
    using CarRental.Repository;

    /// <summary>
    /// This class is responsible for the functions of the business logic.
    /// </summary>
    public class Logic : ILogic
    {
        private Repositories repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// </summary>
        public Logic()
        {
            this.repository = new Repositories();
        }

        /// <inheritdoc/>
        public bool AddNewAccount(string name, string email, string address, DateTime bdate, int minute, int monthly)
        {
            try
            {
                this.repository.AccountRepo.AddAccount(name, email, address, bdate, minute, monthly);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool AddNewCar(string plate, string brand, string model, int battery, int extraPrice)
        {
            try
            {
                this.repository.CarRepo.AddCar(plate, brand, model, battery, extraPrice);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool AddNewComplaint(int rentId, string desc, DateTime time, int chk)
        {
            try
            {
                this.repository.ComplaintRepo.AddComplaint(rentId, desc, time, chk);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool AddNewLicense(string licenseId, int accountId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints)
        {
            try
            {
                this.repository.LicenseRepo.AddLicense(licenseId, accountId, category, startDate, expiryDate, penaltyPoints);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool AddNewRent(int accountId, string carId, DateTime startTime, DateTime endTime, int distance, int price)
        {
            try
            {
                this.repository.RentRepo.AddRent(accountId, carId, startTime, endTime, distance, price);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteAccountData(int accountId)
        {
            try
            {
                this.repository.AccountRepo.DeleteAccount(accountId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteCarData(string plate)
        {
            try
            {
                this.repository.CarRepo.DeleteCar(plate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteComplaintData(int id)
        {
            try
            {
                this.repository.ComplaintRepo.DeleteComplaint(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteLicenseData(string licenseId)
        {
            try
            {
                this.repository.LicenseRepo.DeleteLicense(licenseId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteRentData(int id)
        {
            try
            {
                this.repository.RentRepo.DeleteRent(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public string GetAccountData()
        {
            return this.repository.AccountRepo.GetAccountData();
        }

        /// <inheritdoc/>
        public string GetCarData()
        {
            return this.repository.CarRepo.GetCarData();
        }

        /// <inheritdoc/>
        public string GetComplaintData()
        {
            return this.repository.ComplaintRepo.GetComplaintData();
        }

        /// <inheritdoc/>
        public string GetLicenseData()
        {
            return this.repository.LicenseRepo.GetLicenseData();
        }

        /// <inheritdoc/>
        public string GetRentData()
        {
            return this.repository.RentRepo.GetRentData();
        }

        /// <inheritdoc/>
        public bool IsValidAccount(int id)
        {
            try
            {
                this.repository.AccountRepo.GetOne(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool IsValidCar(string plate)
        {
            try
            {
                this.repository.CarRepo.GetOne(plate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool IsValidComplaint(int id)
        {
            try
            {
                this.repository.ComplaintRepo.GetOne(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool IsValidLicense(string licenseId)
        {
            try
            {
                this.repository.LicenseRepo.GetOne(licenseId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool IsValidRent(int id)
        {
            try
            {
                this.repository.RentRepo.GetOne(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateAccountData(int id, string name, string email, string address, DateTime bdate, int minute, int monthly)
        {
            try
            {
                this.repository.AccountRepo.UpdateAccount(id, name, email, address, bdate, minute, monthly);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateCarData(string plate, string brand, string model, int battery, int extraPrice)
        {
            try
            {
                this.repository.CarRepo.UpdateCar(plate, brand, model, battery, extraPrice);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateComplaintData(int id, int rentId, string desc, DateTime time, int chk)
        {
            try
            {
                this.repository.ComplaintRepo.UpdateComplaint(id, rentId, desc, time, chk);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateLicenseData(string id, int accId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints)
        {
            try
            {
                this.repository.LicenseRepo.UpdateLicense(id, accId, category, startDate, expiryDate, penaltyPoints);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateRentData(int id, int accId, string carId, DateTime startTime, DateTime endTime, int distance, int price)
        {
            try
            {
                this.repository.RentRepo.UpdateRent(id, accId, carId, startTime, endTime, distance, price);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the daily income of each month.
        /// </summary>
        /// <returns>Returns a formatted string containing the daily income data.</returns>
        public string GetDailyIncome()
        {
            return this.repository.RentRepo.GetDailyIncome();
        }

        /// <summary>
        /// Gets the overall income and the daily average price of the rents.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetOverallIncome()
        {
            return this.repository.RentRepo.GetOverallIncome();
        }

        /// <summary>
        /// Gets the people who started the most and least rents.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetRentsByUser()
        {
            return this.repository.GetRentsByUser();
        }

        /// <summary>
        /// Gets the distance driven with each car.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetDistanceByCar()
        {
            return this.repository.GetDistanceByCar();
        }

        /// <summary>
        /// Gets the users who are excluded from starting rents.
        /// </summary>
        /// <returns>Returns a formatted string.</returns>
        public string GetExcludedUsers()
        {
            return this.repository.GetExcludedUsers();
        }
    }
}
