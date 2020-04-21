// <copyright file="BusinessLogic.cs" company="PlaceholderCompany">
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
    public class BusinessLogic : IBusinessLogic
    {
        private IRepository<Account, int> accountRepo;
        private IRepository<Car, string> carRepo;
        private IRepository<License, string> licenseRepo;
        private IRepository<Rent, int> rentRepo;
        private IRepository<Complaint, int> complaintRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogic"/> class.
        /// </summary>
        /// <param name="accounts">The account repository.</param>
        /// <param name="cars">The car repository.</param>
        /// <param name="licenses">The license repository.</param>
        /// <param name="rents">The rent repository.</param>
        /// <param name="complaints">The complaint repository.</param>
        public BusinessLogic(IRepository<Account, int> accounts, IRepository<Car, string> cars, IRepository<License, string> licenses, IRepository<Rent, int> rents, IRepository<Complaint, int> complaints)
        {
            this.accountRepo = accounts;
            this.carRepo = cars;
            this.licenseRepo = licenses;
            this.rentRepo = rents;
            this.complaintRepo = complaints;
        }

        /// <inheritdoc/>
        public IEnumerable<DailyIncomeResult> GetDailyIncome()
        {
            List<DailyIncomeResult> results = new List<DailyIncomeResult>();
            for (int i = 1; i <= 12; i++)
            {
                var daily = from x in this.rentRepo.GetAll()
                            where x.StartTime.Month == i
                            group x by x.StartTime.Day into g
                            select new DailyIncomeResult
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
        public OverallIncomeResult GetOverallIncome()
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
            return new OverallIncomeResult() { OverallIncome = (int)income, Average = (double)avg };
        }

        /// <inheritdoc/>
        public RentsByUserResult GetUserWithMostRents()
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
            return new RentsByUserResult() { AccountName = mostRents, Count = count };
        }

        /// <inheritdoc/>
        public IEnumerable<DistancesByCarResult> GetDistanceByCar()
        {
            var rentData = this.rentRepo.GetAll();
            var carData = this.carRepo.GetAll();
            var result = (from rent in rentData
                            join car in carData
                            on rent.CarId equals car.CarId
                            group rent by car into g
                            select new DistancesByCarResult()
                            {
                                Car = g.Key.CarId,
                                Distance = (int)g.Sum(x => x.Distance),
                            }).OrderByDescending(x => x.Distance);
            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<RentsByUserResult> GetRentsByUser()
        {
            var rentData = this.rentRepo.GetAll();
            var accData = this.accountRepo.GetAll();
            var rents = (from rent in rentData
                         join account in accData
                         on rent.AccountId equals account.AccountId
                         group rent by rent.AccountId into g
                         select new RentsByUserResult
                         {
                             AccountName = accData.Where(x => x.AccountId == g.Key).FirstOrDefault().Name,
                             Count = g.Count(),
                         }).OrderByDescending(x => x.Count);
            return rents;
        }

        /// <inheritdoc/>
        public CarStats GetCarStats(string id)
        {
            var car = this.carRepo.GetOne(id);
            int countOfRents = car.Rents.Count;
            int sumOfPrice = car.Rents.Sum(x => x.Price ?? 0);
            return new CarStats()
            {
                Car = id,
                CountOfRents = countOfRents,
                SumOfPrice = sumOfPrice,
            };
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
