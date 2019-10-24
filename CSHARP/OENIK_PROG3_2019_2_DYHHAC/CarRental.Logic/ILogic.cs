// <copyright file="ILogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the logic classes.
    /// </summary>
    public interface ILogic
    {
        /// <summary>
        /// Gets all data from the Account table.
        /// </summary>
        /// <returns>Returns the data from the Account table in a formatted string.</returns>
        IQueryable GetAccountData();

        /// <summary>
        /// Gets all data from the Car table.
        /// </summary>
        /// <returns>Returns the data from the Car table in a formatted string.</returns>
        IQueryable GetCarData();

        /// <summary>
        /// Gets all data from the License table.
        /// </summary>
        /// <returns>Returns the data from the Account table in a formatted string.</returns>
        IQueryable GetLicenseData();

        /// <summary>
        /// Gets all data from the Rent table.
        /// </summary>
        /// <returns>Returns the data from the Account table in a formatted string.</returns>
        IQueryable GetRentData();

        /// <summary>
        /// Gets all data from the Complaint table.
        /// </summary>
        /// <returns>Returns the data from the Account table in a formatted string.</returns>
        IQueryable GetComplaintData();

        /// <summary>
        /// Checks if the given account exists in the database.
        /// </summary>
        /// <param name="id">The ID of the account.</param>
        /// <returns>True or false.</returns>
        bool IsValidAccount(int id);

        /// <summary>
        /// Checks if the given car exists in the database.
        /// </summary>
        /// <param name="plate">The numberplate of the car.</param>
        /// <returns>True or false.</returns>
        bool IsValidCar(string plate);

        /// <summary>
        /// Checks if the given license exists in the database.
        /// </summary>
        /// <param name="licenseId">The ID of the license.</param>
        /// <returns>True or false.</returns>
        bool IsValidLicense(string licenseId);

        /// <summary>
        /// Checks if the given rent exists in the database.
        /// </summary>
        /// <param name="id">The ID of the rent.</param>
        /// <returns>True or false.</returns>
        bool IsValidRent(int id);

        /// <summary>
        /// Checks if the given complaint exists in the database.
        /// </summary>
        /// <param name="id">The ID of the complaint.</param>
        /// <returns>True or false.</returns>
        bool IsValidComplaint(int id);

        /// <summary>
        /// Adds a new account to the database.
        /// </summary>
        /// <param name="name">The name of the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="address">The city where the user lives.</param>
        /// <param name="bdate">The birth date of the user.</param>
        /// <param name="minute">The price per minute the user will pay for the rents.</param>
        /// <param name="monthly">The monthly price the user will pay for the services.</param>
        /// <returns>True or false whether on the insertion was successful or not.</returns>
        bool AddNewAccount(string name, string email, string address, DateTime bdate, int minute, int monthly);

        /// <summary>
        /// Adds a new car to the database.
        /// </summary>
        /// <param name="plate">The numberplate of the car. This is the primary key.</param>
        /// <param name="brand">The brand of the car.</param>
        /// <param name="model">The model of the car.</param>
        /// <param name="battery">The battery level of the car.</param>
        /// <param name="extraPrice">The additional per minute fee paid by the user when using this car.</param>
        /// <returns>True or false whether the insertion was successful or not.</returns>
        bool AddNewCar(string plate, string brand, string model, int battery, int extraPrice);

        /// <summary>
        /// Adds a new license to the database.
        /// </summary>
        /// <param name="licenseId">The number of the license. Contains numbers and letters.</param>
        /// <param name="accountId">The user whom the license belongs to.</param>
        /// <param name="category">The highest category of the license.</param>
        /// <param name="startDate">The license is valid from this date.</param>
        /// <param name="expiryDate">The expiration date of the license.</param>
        /// <param name="penaltyPoints">The penalty points the user has. Issued by authorities.</param>
        /// <returns>True or false whether the insertion was successful or not.</returns>
        bool AddNewLicense(string licenseId, int accountId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints);

        /// <summary>
        /// Adds a new rent to the database.
        /// </summary>
        /// <param name="accountId">The user who started the rent.</param>
        /// <param name="carId">The numberplate of the car that was used.</param>
        /// <param name="startTime">The start time of the rent.</param>
        /// <param name="endTime">The end time of the rent.</param>
        /// <param name="distance">The distance driven with the car.</param>
        /// <param name="price">The price paid by the user.</param>
        /// <returns>True or false whether the insertion was successful or not.</returns>
        bool AddNewRent(int accountId, string carId, DateTime startTime, DateTime endTime, int distance, int price);

        /// <summary>
        /// Adds a new complaint to the database.
        /// </summary>
        /// <param name="rentId">The rent which the complaint refers to.</param>
        /// <param name="desc">The description of the complaint.</param>
        /// <param name="time">The time the complaint was filed.</param>
        /// <param name="chk">1 or 0, whether the complaint was handled by the service provider.</param>
        /// <returns>True or false whether the insertion was successful or not.</returns>
        bool AddNewComplaint(int rentId, string desc, DateTime time, int chk);

        /// <summary>
        /// Updates an account data.
        /// </summary>
        /// <param name="id">The account to be updated.</param>
        /// <param name="name">The new name to be set.</param>
        /// <param name="email">The new email to be set. </param>
        /// <param name="address">The new address to be set.</param>
        /// <param name="bdate">The new birth date to be set.</param>
        /// <param name="minute">The new price per minute to be set.</param>
        /// <param name="monthly">The new monthly price to be set.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateAccountData(int id, string name, string email, string address, DateTime bdate, int minute, int monthly);

        /// <summary>
        /// Updates the selected car data.
        /// </summary>
        /// <param name="plate">The numberplate of the car we want to update.</param>
        /// <param name="brand">The new brand to be set.</param>
        /// <param name="model">The new model to be set.</param>
        /// <param name="battery">The new battery level to be set.</param>
        /// <param name="extraPrice">The new extra price to be set.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateCarData(string plate, string brand, string model, int battery, int extraPrice);

        /// <summary>
        /// Updates the selected license data.
        /// </summary>
        /// <param name="id">The license we want to update.</param>
        /// <param name="accId">The account whom the license belongs to.</param>
        /// <param name="category">The new category of the license.</param>
        /// <param name="startDate">The new start date of the license.</param>
        /// <param name="expiryDate">The new expiry date of the license.</param>
        /// <param name="penaltyPoints">The new value of penalty points.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateLicenseData(string id, int accId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints);

        /// <summary>
        /// Updates the selected complaint data.
        /// </summary>
        /// <param name="id">The complaint we want to update.</param>
        /// <param name="rentId">The rent which the complaint refers to.</param>
        /// <param name="desc">The new description to be set.</param>
        /// <param name="time">The new time to be set.</param>
        /// <param name="chk">The new check status to be set. Must be 1 or 0.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateComplaintData(int id, int rentId, string desc, DateTime time, int chk);

        /// <summary>
        /// Updates the selected rent data.
        /// </summary>
        /// <param name="id">The rent to be updated.</param>
        /// <param name="accId">The new account who started the rent.</param>
        /// <param name="carId">The new car which the rent was done.</param>
        /// <param name="startTime">The new start time of the rent.</param>
        /// <param name="endTime">The new end time of the rent.</param>
        /// <param name="distance">The new distance of the rent.</param>
        /// <param name="price">The new price paid by the user.</param>
        /// <returns>True or false whether the update was successful or not.</returns>
        bool UpdateRentData(int id, int accId, string carId, DateTime startTime, DateTime endTime, int distance, int price);

        /// <summary>
        /// Deletes the selected account from the database.
        /// </summary>
        /// <param name="accountId">The account to be deleted.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteAccountData(int accountId);

        /// <summary>
        /// Deletes the selected car from the database.
        /// </summary>
        /// <param name="plate">The numberplate of the car which we want to delete.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteCarData(string plate);

        /// <summary>
        /// Deletes the selected license from the database.
        /// </summary>
        /// <param name="licenseId">The license we want to delete.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteLicenseData(string licenseId);

        /// <summary>
        /// Deletes the selected rent from the database.
        /// </summary>
        /// <param name="id">The rent we want to delete.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteRentData(int id);

        /// <summary>
        /// Deletes the selected complaint from the database.
        /// </summary>
        /// <param name="id">The complaint we want to delete.</param>
        /// <returns>True or false whether the deletion was successful or not.</returns>
        bool DeleteComplaintData(int id);
    }
}
