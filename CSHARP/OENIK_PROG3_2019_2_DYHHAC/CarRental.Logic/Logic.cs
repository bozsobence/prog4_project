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
                Name = name,
                Email = email,
                Address = address,
                BirthDate = bdate,
                Minute = minute,
                Monthly = monthly,
            };
            try
            {
                this.repository.AccountRepo.Add(acc);
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
                CarID = plate,
                Brand = brand,
                Model = model,
                Battery = battery,
                ExtraPrice = extraPrice,
            };
            try
            {
                this.repository.CarRepo.Add(car);
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
                RentID = rentId,
                Description = desc,
                Time = time,
                Chk = chk,
            };
            try
            {
                this.repository.ComplaintRepo.Add(comp);
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
                LicenseID = licenseId,
                AccountID = accountId,
                Category = category,
                StartDate = startDate,
                ExpiryDate = expiryDate,
                PenaltyPoints = penaltyPoints,
            };
            try
            {
                this.repository.LicenseRepo.Add(lic);
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
                AccountID = accountId,
                CarID = carId,
                StartTime = startTime,
                EndTime = endTime,
                Distance = distance,
                Price = price,
            };
            try
            {
                this.repository.RentRepo.Add(r);
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
                this.repository.AccountRepo.Delete(accountId);
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
                this.repository.CarRepo.Delete(plate);
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
                this.repository.ComplaintRepo.Delete(id);
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
                this.repository.LicenseRepo.Delete(licenseId);
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
                this.repository.RentRepo.Delete(id);
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
                    Account acc = new Account()
                    {
                        Name = name,
                        Email = email,
                        Address = address,
                        BirthDate = bdate,
                        Minute = minute,
                        Monthly = monthly,
                    };
                    this.repository.AccountRepo.Update(id, acc);
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
        public bool UpdateCarData(string carID, string brand, string model, int battery, int extraPrice)
        {
            if (this.IsValidCar(carID))
            {
                try
                {
                    Car car = new Car()
                    {
                        CarID = carID,
                        Brand = brand,
                        Model = model,
                        Battery = battery,
                        ExtraPrice = extraPrice,
                    };
                    this.repository.CarRepo.Update(carID, car);
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
                    Complaint c = new Complaint()
                    {
                        RentID = rentId,
                        Description = desc,
                        Time = time,
                        Chk = chk,
                    };
                    this.repository.ComplaintRepo.Update(id, c);
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
                    License l = new License()
                    {
                        AccountID = accId,
                        Category = category,
                        StartDate = startDate,
                        ExpiryDate = expiryDate,
                        PenaltyPoints = penaltyPoints,
                    };
                    this.repository.LicenseRepo.Update(id, l);
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
                    Rent r = new Rent()
                    {
                        AccountID = accId,
                        CarID = carId,
                        StartTime = startTime,
                        EndTime = endTime,
                        Distance = distance,
                        Price = price,
                    };
                    this.repository.RentRepo.Update(id, r);
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
                            where x.StartTime.Month == i
                            group x by x.StartTime.Day into g
                            select new ResultClasses.DailyIncomeResult
                            {
                                Month = i,
                                Day = g.Key,
                                Income = (int)g.Sum(x => x.Price),
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
            var income = rentData.Sum(x => x.Price);
            var avgDaily = from x in rentData
                           group x by x.StartTime.Day into g
                           select new
                           {
                               Avg = g.Sum(x => x.Price),
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
                         on rent.AccountID equals account.AccountID
                         group rent by rent.AccountID into g
                         select new
                         {
                             ID = g.Key,
                             RENTS = g.Count(),
                         }).OrderByDescending(x => x.RENTS).FirstOrDefault();
            var mostRents = accData.Where(x => x.AccountID == rents.ID).FirstOrDefault().Name;
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
                            on rent.CarID equals car.CarID
                            group rent by car into g
                            select new ResultClasses.DistancesByCarResult()
                            {
                                Car = g.Key.CarID,
                                Distance = (int)g.Sum(x => x.Distance),
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
                         on rent.AccountID equals account.AccountID
                         group rent by rent.AccountID into g
                         select new ResultClasses.RentsByUserResult
                         {
                             AccountName = accData.Where(x => x.AccountID == g.Key).FirstOrDefault().Name,
                             Count = g.Count(),
                         }).OrderByDescending(x => x.Count);
            return rents;
        }
    }
}
