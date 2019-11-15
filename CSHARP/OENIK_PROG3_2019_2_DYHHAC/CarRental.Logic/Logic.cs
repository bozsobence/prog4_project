// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
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
        /// <param name="repo">The repository that the logic handles.</param>
        public Logic(Repositories repo)
        {
            this.repository = repo;
        }

        /// <summary>
        /// Creates a new Logic instance.
        /// </summary>
        /// <returns>Returns a <see cref="Logic"/> object.</returns>
        public static ILogic CreateLogic()
        {
            Repositories repo = new Repositories();
            return new Logic(repo);
        }

        /// <inheritdoc/>
        public bool AddNewAccount(string name, string email, string address, DateTime bdate, int minute, int monthly)
        {
            Account acc = new Account()
            {
                name = name,
                email = email,
                address = address,
                birthdate = bdate,
                minute = minute,
                monthly = monthly,
            };
            try
            {
                this.repository.AccountRepo.AddAccount(acc);
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
            Car car = new Car()
            {
                plate = plate,
                brand = brand,
                model = model,
                battery = battery,
                extraPrice = extraPrice,
            };
            try
            {
                this.repository.CarRepo.AddCar(car);
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
            Complaint comp = new Complaint()
            {
                rentID = rentId,
                description = desc,
                time = time,
                @checked = chk,
            };
            try
            {
                this.repository.ComplaintRepo.AddComplaint(comp);
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
            License lic = new License()
            {
                licenseID = licenseId,
                accountID = accountId,
                category = category,
                startDate = startDate,
                expiryDate = expiryDate,
                penaltyPoints = penaltyPoints,
            };
            try
            {
                this.repository.LicenseRepo.AddLicense(lic);
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
            Rent r = new Rent()
            {
                accountID = accountId,
                carID = carId,
                starttime = startTime,
                endtime = endTime,
                distance = distance,
                price = price,
            };
            try
            {
                this.repository.RentRepo.AddRent(r);
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
        public IQueryable<Account> GetAccountData()
        {
            return this.repository.AccountRepo.GetAll();
        }

        /// <inheritdoc/>
        public Account GetAccountById(int id)
        {
            return this.repository.AccountRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public IQueryable<Car> GetCarData()
        {
            return this.repository.CarRepo.GetAll();
        }

        /// <inheritdoc/>
        public IQueryable<Complaint> GetComplaintData()
        {
            return this.repository.ComplaintRepo.GetAll();
        }

        /// <inheritdoc/>
        public IQueryable<License> GetLicenseData()
        {
            return this.repository.LicenseRepo.GetAll();
        }

        /// <inheritdoc/>
        public IQueryable<Rent> GetRentData()
        {
            return this.repository.RentRepo.GetAll();
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
            if (this.IsValidAccount(id))
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
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateCarData(string plate, string brand, string model, int battery, int extraPrice)
        {
            if (this.IsValidCar(plate))
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
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateComplaintData(int id, int rentId, string desc, DateTime time, int chk)
        {
            if (this.IsValidComplaint(id))
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
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateLicenseData(string id, int accId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints)
        {
            if (this.IsValidLicense(id))
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
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateRentData(int id, int accId, string carId, DateTime startTime, DateTime endTime, int distance, int price)
        {
            if (this.IsValidRent(id))
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
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public IEnumerable<ResultClasses.DailyIncomeResult> GetDailyIncome()
        {
            List<ResultClasses.DailyIncomeResult> results = new List<ResultClasses.DailyIncomeResult>();
            for (int i = 1; i <= 12; i++)
            {
                var daily = from x in this.repository.RentRepo.GetAll()
                            where x.starttime.Month == i
                            group x by x.starttime.Day into g
                            select new ResultClasses.DailyIncomeResult
                            {
                                Month = i,
                                Day = g.Key,
                                Income = (int)g.Sum(x => x.price),
                            };
                if (daily.Count() != 0)
                {
                    foreach (var day in daily)
                    {
                        results.Add(day);
                    }
                }
            }

            return results;
        }

        /// <inheritdoc/>
        public ResultClasses.OverallIncomeResult GetOverallIncome()
        {
            var rentData = this.repository.RentRepo.GetAll();
            var income = rentData.Sum(x => x.price);
            var avgDaily = from x in rentData
                           group x by x.starttime.Day into g
                           select new
                           {
                               Avg = g.Sum(x => x.price),
                           };
            var avg = avgDaily.Sum(x => x.Avg) / avgDaily.Count();
            return new ResultClasses.OverallIncomeResult() { OverallIncome = (int)income, Average = (double)avg };
        }

        /// <inheritdoc/>
        public ResultClasses.RentsByUserResult GetUserWithMostRents()
        {
            var rentData = this.repository.RentRepo.GetAll();
            var accData = this.repository.AccountRepo.GetAll();
            var rents = (from rent in rentData
                         join account in accData
                         on rent.accountID equals account.accountID
                         group rent by rent.accountID into g
                         select new
                         {
                             ID = g.Key,
                             RENTS = g.Count(),
                         }).OrderByDescending(x => x.RENTS).FirstOrDefault();
            var mostRents = accData.Where(x => x.accountID == rents.ID).FirstOrDefault().name;
            var count = rents.RENTS;
            return new ResultClasses.RentsByUserResult() { AccountName = mostRents, Count = count };
        }

        /// <inheritdoc/>
        public IEnumerable<ResultClasses.DistancesByCarResult> GetDistanceByCar()
        {
            var rentData = this.repository.RentRepo.GetAll();
            var carData = this.repository.CarRepo.GetAll();
            var result = (from rent in rentData
                            join car in carData
                            on rent.carID equals car.plate
                            group rent by car into g
                            select new ResultClasses.DistancesByCarResult()
                            {
                                Car = g.Key.plate,
                                Distance = (int)g.Sum(x => x.distance),
                            }).OrderByDescending(x => x.Distance);
            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<ResultClasses.RentsByUserResult> GetRentsByUser()
        {
            var rentData = this.repository.RentRepo.GetAll();
            var accData = this.repository.AccountRepo.GetAll();
            var rents = (from rent in rentData
                         join account in accData
                         on rent.accountID equals account.accountID
                         group rent by rent.accountID into g
                         select new ResultClasses.RentsByUserResult
                         {
                             AccountName = accData.Where(x => x.accountID == g.Key).FirstOrDefault().name,
                             Count = g.Count(),
                         }).OrderByDescending(x => x.Count);
            return rents;
        }
    }
}
