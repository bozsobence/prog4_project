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
        private Mock<Repositories> repo;
        private ILogic mockedLogic;
        private List<Account> accounts;
        private List<Car> cars;
        private List<Rent> rents;
        private List<License> licenses;
        private List<Complaint> complaints;

        /// <summary>
        /// Initializes the tests.
        /// </summary>
        [SetUp]
        public void Init()
        {
            this.accounts = new List<Account>()
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
            };
            this.cars = new List<Car>()
            {
                new Car() { plate = "REM-990", brand = "Volkswagen", model = "e-Up", battery = 41, extraPrice = 0 },
                new Car() { plate = "RBT-178", brand = "Volkswagen", model = "e-Up", battery = 12, extraPrice = 0 },
                new Car() { plate = "RKO-673", brand = "Volkswagen", model = "e-Golf", battery = 53, extraPrice = 20 },
                new Car() { plate = "RFP-990", brand = "BMW", model = "i3", battery = 32, extraPrice = 40 },
                new Car() { plate = "RNX-941", brand = "Volkswagen", model = "e-Up", battery = 96, extraPrice = 0 },
                new Car() { plate = "RZT-841", brand = "Audi", model = "e-Tron", battery = 14, extraPrice = 60 },
                new Car() { plate = "RZF-406", brand = "Volkswagen", model = "e-Golf", battery = 53, extraPrice = 20 },
                new Car() { plate = "RUS-598", brand = "Volkswagen", model = "e-Up", battery = 65, extraPrice = 0 },
                new Car() { plate = "RTA-149", brand = "Audi", model = "e-Tron", battery = 98, extraPrice = 60 },
                new Car() { plate = "RCS-709", brand = "Audi", model = "e-Tron", battery = 15, extraPrice = 60 },
                new Car() { plate = "RFF-995", brand = "BMW", model = "i3", battery = 61, extraPrice = 40 },
                new Car() { plate = "RHO-859", brand = "Volkswagen", model = "e-Up", battery = 44, extraPrice = 0 },
                new Car() { plate = "RHX-557", brand = "Nissan", model = "Leaf", battery = 13, extraPrice = 20 },
                new Car() { plate = "REF-473", brand = "Nissan", model = "Leaf", battery = 76, extraPrice = 20 },
                new Car() { plate = "RMB-898", brand = "Volkswagen", model = "e-Up", battery = 57, extraPrice = 0 },
                new Car() { plate = "RMV-468", brand = "Volkswagen", model = "e-Up", battery = 84, extraPrice = 0 },
                new Car() { plate = "RHC-386", brand = "Audi", model = "e-Tron", battery = 94, extraPrice = 60 },
                new Car() { plate = "RTF-587", brand = "BMW", model = "i3", battery = 22, extraPrice = 40 },
                new Car() { plate = "RFW-482", brand = "BMW", model = "i3", battery = 36, extraPrice = 40 },
                new Car() { plate = "RVN-153", brand = "Volkswagen", model = "e-Golf", battery = 78, extraPrice = 20 },
            };
            this.rents = new List<Rent>()
            {
                new Rent() { rentID = 0, accountID = 7, carID = "RTF-587", starttime = DateTime.Parse("2019-10-02 03:29:00"), endtime = DateTime.Parse("2019-10-02 05:57:00"), distance = 37, price = 3700 },
                new Rent() { rentID = 1, accountID = 11, carID = "RZT-841", starttime = DateTime.Parse("2019-10-02 03:56:00"), endtime = DateTime.Parse("2019-10-02 06:11:00"), distance = 55, price = 5500 },
                new Rent() { rentID = 2, accountID = 11, carID = "RTF-587", starttime = DateTime.Parse("2019-10-02 01:21:00"), endtime = DateTime.Parse("2019-10-02 02:29:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 3, accountID = 13, carID = "RKO-673", starttime = DateTime.Parse("2019-10-02 22:34:00"), endtime = DateTime.Parse("2019-10-02 23:26:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 4, accountID = 11, carID = "RCS-709", starttime = DateTime.Parse("2019-10-02 08:31:00"), endtime = DateTime.Parse("2019-10-02 09:55:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 5, accountID = 8, carID = "RVN-153", starttime = DateTime.Parse("2019-10-02 04:34:00"), endtime = DateTime.Parse("2019-10-02 05:05:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 6, accountID = 10, carID = "RHC-386", starttime = DateTime.Parse("2019-10-02 00:53:00"), endtime = DateTime.Parse("2019-10-02 01:35:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 7, accountID = 1, carID = "RHC-386", starttime = DateTime.Parse("2019-10-02 18:39:00"), endtime = DateTime.Parse("2019-10-02 20:12:00"), distance = 37, price = 3700 },
                new Rent() { rentID = 8, accountID = 3, carID = "REM-990", starttime = DateTime.Parse("2019-10-02 08:53:00"), endtime = DateTime.Parse("2019-10-02 09:47:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 9, accountID = 8, carID = "RZF-406", starttime = DateTime.Parse("2019-10-02 06:07:00"), endtime = DateTime.Parse("2019-10-02 07:01:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 10, accountID = 1, carID = "RZF-406", starttime = DateTime.Parse("2019-10-02 19:40:00"), endtime = DateTime.Parse("2019-10-02 21:00:00"), distance = 37, price = 3700 },
                new Rent() { rentID = 11, accountID = 11, carID = "RZF-406", starttime = DateTime.Parse("2019-10-02 06:53:00"), endtime = DateTime.Parse("2019-10-02 08:11:00"), distance = 37, price = 3700 },
                new Rent() { rentID = 12, accountID = 13, carID = "RMB-898", starttime = DateTime.Parse("2019-10-02 23:00:00"), endtime = DateTime.Parse("2019-10-02 23:11:00"), distance = 3, price = 300 },
                new Rent() { rentID = 13, accountID = 3, carID = "RBT-178", starttime = DateTime.Parse("2019-10-02 15:15:00"), endtime = DateTime.Parse("2019-10-02 15:49:00"), distance = 20, price = 2000 },
                new Rent() { rentID = 14, accountID = 9, carID = "REF-473", starttime = DateTime.Parse("2019-10-02 08:16:00"), endtime = DateTime.Parse("2019-10-02 09:30:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 15, accountID = 5, carID = "RHO-859", starttime = DateTime.Parse("2019-10-02 18:57:00"), endtime = DateTime.Parse("2019-10-02 20:19:00"), distance = 37, price = 3700 },
                new Rent() { rentID = 16, accountID = 0, carID = "RZT-841", starttime = DateTime.Parse("2019-10-02 19:58:00"), endtime = DateTime.Parse("2019-10-02 22:00:00"), distance = 55, price = 5500 },
                new Rent() { rentID = 17, accountID = 11, carID = "RFW-482", starttime = DateTime.Parse("2019-10-02 12:38:00"), endtime = DateTime.Parse("2019-10-02 13:50:00"), distance = 18, price = 1800 },
                new Rent() { rentID = 18, accountID = 3, carID = "RFP-990", starttime = DateTime.Parse("2019-10-02 10:34:00"), endtime = DateTime.Parse("2019-10-02 12:03:00"), distance = 37, price = 3700 },
                new Rent() { rentID = 19, accountID = 9, carID = "RFW-482", starttime = DateTime.Parse("2019-10-02 04:47:00"), endtime = DateTime.Parse("2019-10-02 04:55:00"), distance = 3, price = 300 },
            };
            this.licenses = new List<License>()
            {
                new License() { licenseID = "HX211743", accountID = 4, category = "A", startDate = DateTime.Parse("2016-12-11"), expiryDate = DateTime.Parse("2021-12-11") },
                new License() { licenseID = "LK239013", accountID = 7, category = "A", startDate = DateTime.Parse("2014-01-19"), expiryDate = DateTime.Parse("2019-01-19") },
                new License() { licenseID = "TG725938", accountID = 5, category = "AM", startDate = DateTime.Parse("2013-04-13"), expiryDate = DateTime.Parse("2018-04-13") },
                new License() { licenseID = "IK079491", accountID = 1, category = "A", startDate = DateTime.Parse("2017-02-04"), expiryDate = DateTime.Parse("2022-02-04") },
                new License() { licenseID = "QV978087", accountID = 14, category = "A", startDate = DateTime.Parse("2016-03-24"), expiryDate = DateTime.Parse("2021-03-24") },
                new License() { licenseID = "KS701427", accountID = 10, category = "C", startDate = DateTime.Parse("2015-01-14"), expiryDate = DateTime.Parse("2020-01-14") },
                new License() { licenseID = "SI261106", accountID = 13, category = "B", startDate = DateTime.Parse("2014-10-05"), expiryDate = DateTime.Parse("2019-10-05") },
                new License() { licenseID = "KI156402", accountID = 6, category = "A", startDate = DateTime.Parse("2014-09-08"), expiryDate = DateTime.Parse("2019-09-08") },
                new License() { licenseID = "BX169634", accountID = 0, category = "AM", startDate = DateTime.Parse("2018-03-27"), expiryDate = DateTime.Parse("2023-03-27") },
                new License() { licenseID = "FW577033", accountID = 8, category = "D", startDate = DateTime.Parse("2012-10-04"), expiryDate = DateTime.Parse("2017-10-04") },
                new License() { licenseID = "BW629063", accountID = 3, category = "B", startDate = DateTime.Parse("2012-09-20"), expiryDate = DateTime.Parse("2017-09-20") },
                new License() { licenseID = "ZA116690", accountID = 9, category = "B", startDate = DateTime.Parse("2017-05-23"), expiryDate = DateTime.Parse("2022-05-23") },
                new License() { licenseID = "LY178690", accountID = 11, category = "A", startDate = DateTime.Parse("2016-09-21"), expiryDate = DateTime.Parse("2021-09-21") },
                new License() { licenseID = "MD988378", accountID = 2, category = "AM", startDate = DateTime.Parse("2014-02-06"), expiryDate = DateTime.Parse("2019-02-06") },
                new License() { licenseID = "DS212148", accountID = 12, category = "AM", startDate = DateTime.Parse("2018-07-02"), expiryDate = DateTime.Parse("2023-07-02") },
            };
            this.complaints = new List<Complaint>()
            {
                new Complaint() { complaintID = 0, rentID = 5, description = "Nem megfelelő tisztaságú az autó.", time = DateTime.Parse("2019-10-02 05:05:00"), @checked = 1 },
                new Complaint() { complaintID = 1, rentID = 1, description = "Baleset történt személyi sérüléssel.", time = DateTime.Parse("2019-10-02 06:11:00"), @checked = 0 },
                new Complaint() { complaintID = 2, rentID = 4, description = "Nem megfelelő tisztaságú az autó.", time = DateTime.Parse("2019-10-02 09:55:00"), @checked = 1 },
                new Complaint() { complaintID = 3, rentID = 6, description = "Nem megfelelő tisztaságú az autó.", time = DateTime.Parse("2019-10-02 01:35:00"), @checked = 0 },
                new Complaint() { complaintID = 4, rentID = 0, description = "Meghúzták az autót amíg parkolt.", time = DateTime.Parse("2019-10-02 05:57:00"), @checked = 0 },
                new Complaint() { complaintID = 5, rentID = 3, description = "Baleset történt, személyi sérülés nélkül.", time = DateTime.Parse("2019-10-02 23:26:00"), @checked = 0 },
                new Complaint() { complaintID = 6, rentID = 2, description = "Sérült volt az autó a bérlés indítása előtt.", time = DateTime.Parse("2019-10-02 02:29:00"), @checked = 1 },
                new Complaint() { complaintID = 7, rentID = 7, description = "Baleset történt, személyi sérülés nélkül.", time = DateTime.Parse("2019-10-02 20:12:00"), @checked = 0 },
            };
            this.repo = new Mock<Repositories>();
            this.repo.Setup(x => x.AccountRepo.GetAll()).Returns(this.accounts.AsQueryable());
            this.repo.Setup(x => x.CarRepo.GetAll()).Returns(this.cars.AsQueryable());
            this.repo.Setup(x => x.RentRepo.GetAll()).Returns(this.rents.AsQueryable());
            this.repo.Setup(x => x.LicenseRepo.GetAll()).Returns(this.licenses.AsQueryable());
            this.repo.Setup(x => x.ComplaintRepo.GetAll()).Returns(this.complaints.AsQueryable());

            this.mockedLogic = new Logic(this.repo.Object);
        }

        /// <summary>
        /// Tests if the insertion works when given correct input data.
        /// </summary>
        [Test]
        public void AddAccountSuccess()
        {
            bool success = this.mockedLogic.AddNewAccount("Teszt Elek", "teszt.elek@gmail.com", "Budapest", DateTime.Parse("1996-01-11"), 50, 1000);
            this.repo.Verify(x => x.AccountRepo.AddAccount(It.IsAny<Account>()), Times.Once);
            Assert.That(success == true);
        }

        /// <summary>
        /// Tests if the insertion throws exception when given incorrect input data.
        /// </summary>
        [Test]
        public void AddAccountFails()
        {
            Assert.Throws<FormatException>(() => this.mockedLogic.AddNewAccount("Teszt Elek", "teszt.elek@gmail.com", "Budapest", DateTime.Parse("123465"), 50, 1000));
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetAccountData"/> returns the correct data set.
        /// </summary>
        [Test]
        public void GetAllAccountsSuccess()
        {
            IQueryable<Account> acc = this.mockedLogic.GetAccountData();
            this.repo.Verify(x => x.AccountRepo.GetAll(), Times.Once);
            Assert.That(acc, Is.EqualTo(this.accounts));
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetAccountById(int)"/> returns the correct account when it exists.
        /// </summary>
        [Test]
        public void GetAccountByIdSuccess()
        {
            Account acc = this.mockedLogic.GetAccountById(5);
            this.repo.Verify(x => x.AccountRepo.GetOne(5), Times.Once);
            Assert.That(acc, Is.EqualTo(this.accounts[5]));
        }

        [Test]
        public void GetAccountByIdFails()
        {
            Account acc = this.mockedLogic.GetAccountById(65);
            this.repo.Verify(x => x.AccountRepo.GetOne(65), Times.Once);
            Assert.Throws<DatabaseException>(() => mockedLogic.GetAccountById(65));
            Assert.IsNull(acc);
        }
    }
}
