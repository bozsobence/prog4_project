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
    using System.Xml.Linq;
    using CarRental.Data;
    using CarRental.Repository;

    /// <summary>
    /// This class is responsible for the functions of the business logic.
    /// </summary>
    public class Logic : ILogic
    {
        private IRepository<Account, int> accountRepo;
        private IRepository<Car, string> carRepo;
        private IRepository<License, string> licenseRepo;
        private IRepository<Rent, int> rentRepo;
        private IRepository<Complaint, int> complaintRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// </summary>
        /// <param name="accounts">The account repository.</param>
        /// <param name="cars">The car repository.</param>
        /// <param name="licenses">The license repository.</param>
        /// <param name="rents">The rent repository.</param>
        /// <param name="complaints">The complaint repository.</param>
        public Logic(IRepository<Account, int> accounts, IRepository<Car, string> cars, IRepository<License, string> licenses, IRepository<Rent, int> rents, IRepository<Complaint, int> complaints)
        {
            this.accountRepo = accounts;
            this.carRepo = cars;
            this.licenseRepo = licenses;
            this.rentRepo = rents;
            this.complaintRepo = complaints;
        }

        /// <summary>
        /// Creates a new Logic instance.
        /// </summary>
        /// <returns>Returns a <see cref="Logic"/> object.</returns>
        public static ILogic CreateLogic()
        {
            CarRentalDatabaseEntities db = new CarRentalDatabaseEntities();

            return new Logic(new AccountRepository(db), new CarRepository(db), new LicenseRepository(db), new RentRepository(db), new ComplaintRepository(db));
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

            if (bdate == DateTime.MinValue)
            {
                return false;
            }

            try
            {
                this.accountRepo.Add(acc);
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
        public bool AddNewCar(string plate, string brand, string model, int battery, int extraPrice)
        {
            Car car = new Car()
            {
                CarId = plate,
                Brand = brand,
                Model = model,
                Battery = battery,
                ExtraPrice = extraPrice,
            };

            if (car.Battery < 0 || car.Battery > 100)
            {
                throw new FormatException("Battery level must be between 0 and 100.");
            }

            try
            {
                this.carRepo.Add(car);
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
        public bool AddNewComplaint(int rentId, string desc, DateTime time, int chk)
        {
            Complaint comp = new Complaint()
            {
                RentId = rentId,
                Description = desc,
                Time = time,
                Chk = chk,
            };

            if (time == DateTime.MinValue)
            {
                return false;
            }

            try
            {
                this.complaintRepo.Add(comp);
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
        public bool AddNewLicense(string licenseId, int accountId, string category, DateTime startDate, DateTime expiryDate, int penaltyPoints)
        {
            License lic = new License()
            {
                LicenseId = licenseId,
                AccountId = accountId,
                Category = category,
                StartDate = startDate,
                ExpiryDate = expiryDate,
                PenaltyPoints = penaltyPoints,
            };

            if (startDate == DateTime.MinValue || expiryDate == DateTime.MinValue)
            {
                return false;
            }

            try
            {
                this.licenseRepo.Add(lic);
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
        public bool DeleteAccountData(int accountId)
        {
            try
            {
                this.accountRepo.Delete(accountId);
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
        public bool DeleteCarData(string plate)
        {
            try
            {
                this.carRepo.Delete(plate);
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
        public bool DeleteComplaintData(int id)
        {
            try
            {
                this.complaintRepo.Delete(id);
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
        public bool DeleteLicenseData(string licenseId)
        {
            try
            {
                this.licenseRepo.Delete(licenseId);
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
        public IQueryable<Account> GetAccountData()
        {
            return this.accountRepo.GetAll();
        }

        /// <inheritdoc/>
        public IQueryable<Car> GetCarData()
        {
            return this.carRepo.GetAll();
        }

        /// <inheritdoc/>
        public IQueryable<Complaint> GetComplaintData()
        {
            return this.complaintRepo.GetAll();
        }

        /// <inheritdoc/>
        public IQueryable<License> GetLicenseData()
        {
            return this.licenseRepo.GetAll();
        }

        /// <inheritdoc/>
        public IQueryable<Rent> GetRentData()
        {
            return this.rentRepo.GetAll();
        }

        /// <inheritdoc/>
        public bool IsValidAccount(int id)
        {
            try
            {
                this.accountRepo.GetOne(id);
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
        public bool IsValidCar(string plate)
        {
            try
            {
                this.carRepo.GetOne(plate);
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
        public bool IsValidComplaint(int id)
        {
            try
            {
                this.complaintRepo.GetOne(id);
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
        public bool IsValidLicense(string licenseId)
        {
            try
            {
                this.licenseRepo.GetOne(licenseId);
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
        public bool UpdateAccountData(int id, string name, string email, string address, DateTime bdate, int minute, int monthly)
        {
            if (this.IsValidAccount(id))
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
                this.accountRepo.Update(id, acc);
                return true;
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
                Car car = new Car()
                {
                    CarId = carID,
                    Brand = brand,
                    Model = model,
                    Battery = battery,
                    ExtraPrice = extraPrice,
                };
                this.carRepo.Update(carID, car);
                return true;
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
                    Complaint c = new Complaint()
                    {
                        RentId = rentId,
                        Description = desc,
                        Time = time,
                        Chk = chk,
                    };
                    this.complaintRepo.Update(id, c);
                    return true;
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
                License l = new License()
                {
                    AccountId = accId,
                    Category = category,
                    StartDate = startDate,
                    ExpiryDate = expiryDate,
                    PenaltyPoints = penaltyPoints,
                };
                this.licenseRepo.Update(id, l);
                return true;
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

        /// <inheritdoc/>
        public IEnumerable<ResultClasses.DailyIncomeResult> GetDailyIncome()
        {
            List<ResultClasses.DailyIncomeResult> results = new List<ResultClasses.DailyIncomeResult>();
            for (int i = 1; i <= 12; i++)
            {
                var daily = from x in this.rentRepo.GetAll()
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
            var rentData = this.rentRepo.GetAll();
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
            var rentData = this.rentRepo.GetAll();
            var accData = this.accountRepo.GetAll();
            var rents = (from rent in rentData
                         join account in accData
                         on rent.AccountId equals account.AccountId
                         group rent by rent.AccountId into g
                         select new
                         {
                             ID = g.Key,
                             RENTS = g.Count(),
                         }).OrderByDescending(x => x.RENTS).FirstOrDefault();
            var mostRents = accData.Where(x => x.AccountId == rents.ID).FirstOrDefault().Name;
            var count = rents.RENTS;
            return new ResultClasses.RentsByUserResult() { AccountName = mostRents, Count = count };
        }

        /// <inheritdoc/>
        public IEnumerable<ResultClasses.DistancesByCarResult> GetDistanceByCar()
        {
            var rentData = this.rentRepo.GetAll();
            var carData = this.carRepo.GetAll();
            var result = (from rent in rentData
                            join car in carData
                            on rent.CarId equals car.CarId
                            group rent by car into g
                            select new ResultClasses.DistancesByCarResult()
                            {
                                Car = g.Key.CarId,
                                Distance = (int)g.Sum(x => x.Distance),
                            }).OrderByDescending(x => x.Distance);
            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<ResultClasses.RentsByUserResult> GetRentsByUser()
        {
            var rentData = this.rentRepo.GetAll();
            var accData = this.accountRepo.GetAll();
            var rents = (from rent in rentData
                         join account in accData
                         on rent.AccountId equals account.AccountId
                         group rent by rent.AccountId into g
                         select new ResultClasses.RentsByUserResult
                         {
                             AccountName = accData.Where(x => x.AccountId == g.Key).FirstOrDefault().Name,
                             Count = g.Count(),
                         }).OrderByDescending(x => x.Count);
            return rents;
        }

        /// <inheritdoc/>
        public string GetRecommendationFromJava(int minutes, int size, int category)
        {
            string url = $"http://localhost:8080/CarRental.JavaWeb/RecommendationService?minutes={minutes}&size={size}&category={category}";
            XDocument xdoc = XDocument.Load(url);
            List<RecommendedCar> cars = new List<RecommendedCar>();

            foreach (var item in xdoc.Root.Descendants("car"))
            {
                string brand = item.Element("brand").Value;
                string model = item.Element("model").Value;
                int extraPrice = int.Parse(item.Element("extraPrice").Value);
                string carSize;

                if (int.Parse(item.Element("size").Value) == 1)
                {
                    carSize = "kicsi";
                }
                else if (int.Parse(item.Element("size").Value) == 2)
                {
                    carSize = "közepes";
                }
                else
                {
                    carSize = "nagy";
                }

                string carCategory;

                if (int.Parse(item.Element("category").Value) == 1)
                {
                    carCategory = "olcsó";
                }
                else if (int.Parse(item.Element("category").Value) == 2)
                {
                    carCategory = "normál";
                }
                else
                {
                    carCategory = "prémium";
                }

                cars.Add(new RecommendedCar(brand, model, extraPrice, carSize, carCategory));
            }

            int minutePrice = int.Parse(xdoc.Root.Descendants("subscription").Single().Element("minutePrice").Value);
            int monthlyPrice = int.Parse(xdoc.Root.Descendants("subscription").Single().Element("monthlyPrice").Value);
            string name = xdoc.Root.Descendants("subscription").Single().Element("name").Value;
            int fullPrice = int.Parse(xdoc.Root.Descendants("subscription").Single().Element("fullPrice").Value);

            RecommendedSubscription subscription = new RecommendedSubscription(minutePrice, monthlyPrice, name, fullPrice);
            string returnFormatted = subscription.ToString();

            if (xdoc.Root.Descendants("msg").Single().Value != null)
            {
                returnFormatted += xdoc.Root.Descendants("msg").Single().Value;
            }

            returnFormatted += ">> AJÁNLOTT AUTÓK <<\n";
            foreach (var car in cars)
            {
                returnFormatted += car.ToString() + "\n";
            }

            return returnFormatted;
        }
    }
}
