// <copyright file="TestClasses.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;
    using CarRental.Logic;
    using CarRental.Repository;
    using Moq;
    using NUnit;
    using NUnit.Framework;

    /// <summary>
    /// This is the container class of the tests.
    /// </summary>
    [TestFixture]
    public class TestClasses
    {
        private Mock<IAccountRepository<Account>> accountRepo;
        private Mock<ICarRepository<Car>> carRepo;
        private Mock<ILicenseRepository<License>> licenseRepo;
        private Mock<IRentRepository<Rent>> rentRepo;
        private Mock<IComplaintRepository<Complaint>> complaintRepo;
        private ILogic logic;

        /// <summary>
        /// Initializes the tests.
        /// </summary>
        [SetUp]
        public void Init()
        {

            accountRepo = new Mock<IAccountRepository<Account>>();
            accountRepo.Setup(x => x.GetAll()).Returns(new List<Account>()
            {
                new Account() { accountID = 0, name = "Kiss József", email = "jozsef.kiss@outlook.com", address = "Szentendre", birthdate = DateTime.Parse("1971.01.16"), minute = 60, monthly = 1500 },
                new Account() { accountID = 1, name = "Simon Ádám", email = "adam.simon@icloud.com", address = "Budaörs", birthdate = DateTime.Parse("1987.05.25"), minute = 60, monthly = 1500 },
                new Account() { accountID = 2, name = "Simon Tamás", email = "tamas.simon@gmail.com", address = "Vác", birthdate = DateTime.Parse("1966.01.12"), minute = 60, monthly = 1500 },
                new Account() { accountID = 3, name = "Lakatos Sándor", email = "sandor.lakatos@gmail.com", address = "Gödöllő", birthdate = DateTime.Parse("1959.12.15"), minute = 100, monthly = 0 },
                new Account() { accountID = 4, name = "Molnár András", email = "andras.molnar@freemail.hu", address = "Mogyoród", birthdate = DateTime.Parse("1980.07.14"), minute = 100, monthly = 0 },
                new Account() { accountID = 5, name = "Simon Anna", email = "anna.simon@uni-obuda.hu", address = "Vác", birthdate = DateTime.Parse("1976.07.22"), minute = 100, monthly = 0 },
                new Account() { accountID = 6, name = "Lakatos József", email = "jozsef.lakatos@citromail.hu", address = "Vác", birthdate = DateTime.Parse("1953.11.24"), minute = 100, monthly = 0 },
                new Account() { accountID = 7, name = "Kiss Tamás", email = "tamas.kiss@uni-obuda.hu", address = "Vác", birthdate = DateTime.Parse("1953.02.13"), minute = 100, monthly = 0 },
                new Account() { accountID = 8, name = "Vincze Béla", email = "bela.vincze@icloud.com", address = "Vecsés", birthdate = DateTime.Parse("1952.07.14"), minute = 60, monthly = 1500 },
                new Account() { accountID = 9, name = "Molnár Dániel", email = "daniel.molnar@uni-obuda.hu", address = "Mogyoród", birthdate = DateTime.Parse("1999.09.11"), minute = 60, monthly = 1500 },
                new Account() { accountID = 10, name = "Papp László", email = "laszlo.papp@gmail.com", address = "Mogyoród", birthdate = DateTime.Parse("1962.05.12"), minute = 60, monthly = 1500 },
                new Account() { accountID = 11, name = "Vincze Kata", email = "kata.vincze@gmail.com", address = "Vecsés", birthdate = DateTime.Parse("1999.06.14"), minute = 35, monthly = 4000 },
                new Account() { accountID = 12, name = "Lakatos Anna", email = "anna.lakatos@hotmail.com", address = "Budaörs", birthdate = DateTime.Parse("1964.01.16"), minute = 60, monthly = 1500 },
                new Account() { accountID = 13, name = "Kiss Sándor", email = "sandor.kiss@uni-obuda.hu", address = "Csömör", birthdate = DateTime.Parse("1954.05.09"), minute = 100, monthly = 0 },
                new Account() { accountID = 14, name = "Vincze Ádám", email = "adam.vincze@freemail.hu", address = "Budapest", birthdate = DateTime.Parse("1978.05.08"), minute = 60, monthly = 1500 },
            }.AsQueryable());
        }
    }
}
