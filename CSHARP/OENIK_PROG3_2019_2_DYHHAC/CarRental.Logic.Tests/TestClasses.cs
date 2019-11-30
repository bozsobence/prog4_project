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
        private Mock<IRepository<Account, int>> accountRepo;
        private Mock<IRepository<Car, string>> carRepo;
        private Mock<IRepository<License, string>> licenseRepo;
        private Mock<IRepository<Rent, int>> rentRepo;
        private Mock<IRepository<Complaint, int>> complaintRepo;

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
                new Account() { AccountId = 0, Name = "Kiss József", Email = "jozsef.kiss@outlook.com", Address = "Szentendre", BirthDate = DateTime.Parse("1971.01.16"), Minute = 60, Monthly = 1500 },
                new Account() { AccountId = 1, Name = "Simon Ádám", Email = "adam.simon@icloud.com", Address = "Budaörs", BirthDate = DateTime.Parse("1987.05.25"), Minute = 60, Monthly = 1500 },
                new Account() { AccountId = 2, Name = "Simon Tamás", Email = "tamas.simon@gmail.com", Address = "Vác", BirthDate = DateTime.Parse("1966.01.12"), Minute = 60, Monthly = 1500 },
                new Account() { AccountId = 3, Name = "Lakatos Sándor", Email = "sandor.lakatos@gmail.com", Address = "Gödöllő", BirthDate = DateTime.Parse("1959.12.15"), Minute = 100, Monthly = 0 },
                new Account() { AccountId = 4, Name = "Molnár András", Email = "andras.molnar@freemail.hu", Address = "Mogyoród", BirthDate = DateTime.Parse("1980.07.14"), Minute = 100, Monthly = 0 },
                new Account() { AccountId = 5, Name = "Simon Anna", Email = "anna.simon@uni-obuda.hu", Address = "Vác", BirthDate = DateTime.Parse("1976.07.22"), Minute = 100, Monthly = 0 },
                new Account() { AccountId = 6, Name = "Lakatos József", Email = "jozsef.lakatos@citromail.hu", Address = "Vác", BirthDate = DateTime.Parse("1953.11.24"), Minute = 100, Monthly = 0 },
                new Account() { AccountId = 7, Name = "Kiss Tamás", Email = "tamas.kiss@uni-obuda.hu", Address = "Vác", BirthDate = DateTime.Parse("1953.02.13"), Minute = 100, Monthly = 0 },
                new Account() { AccountId = 8, Name = "Vincze Béla", Email = "bela.vincze@icloud.com", Address = "Vecsés", BirthDate = DateTime.Parse("1952.07.14"), Minute = 60, Monthly = 1500 },
                new Account() { AccountId = 9, Name = "Molnár Dániel", Email = "daniel.molnar@uni-obuda.hu", Address = "Mogyoród", BirthDate = DateTime.Parse("1999.09.11"), Minute = 60, Monthly = 1500 },
                new Account() { AccountId = 10, Name = "Papp László", Email = "laszlo.papp@gmail.com", Address = "Mogyoród", BirthDate = DateTime.Parse("1962.05.12"), Minute = 60, Monthly = 1500 },
                new Account() { AccountId = 11, Name = "Vincze Kata", Email = "kata.vincze@gmail.com", Address = "Vecsés", BirthDate = DateTime.Parse("1999.06.14"), Minute = 35, Monthly = 4000 },
                new Account() { AccountId = 12, Name = "Lakatos Anna", Email = "anna.lakatos@hotmail.com", Address = "Budaörs", BirthDate = DateTime.Parse("1964.01.16"), Minute = 60, Monthly = 1500 },
                new Account() { AccountId = 13, Name = "Kiss Sándor", Email = "sandor.kiss@uni-obuda.hu", Address = "Csömör", BirthDate = DateTime.Parse("1954.05.09"), Minute = 100, Monthly = 0 },
                new Account() { AccountId = 14, Name = "Vincze Ádám", Email = "adam.vincze@freemail.hu", Address = "Budapest", BirthDate = DateTime.Parse("1978.05.08"), Minute = 60, Monthly = 1500 },
            };
            this.cars = new List<Car>()
            {
                new Car() { CarId = "REM-990", Brand = "Volkswagen", Model = "e-Up", Battery = 41, ExtraPrice = 0 },
                new Car() { CarId = "RBT-178", Brand = "Volkswagen", Model = "e-Up", Battery = 12, ExtraPrice = 0 },
                new Car() { CarId = "RKO-673", Brand = "Volkswagen", Model = "e-Golf", Battery = 53, ExtraPrice = 20 },
                new Car() { CarId = "RFP-990", Brand = "BMW", Model = "i3", Battery = 32, ExtraPrice = 40 },
                new Car() { CarId = "RNX-941", Brand = "Volkswagen", Model = "e-Up", Battery = 96, ExtraPrice = 0 },
                new Car() { CarId = "RZT-841", Brand = "Audi", Model = "e-Tron", Battery = 14, ExtraPrice = 60 },
                new Car() { CarId = "RZF-406", Brand = "Volkswagen", Model = "e-Golf", Battery = 53, ExtraPrice = 20 },
                new Car() { CarId = "RUS-598", Brand = "Volkswagen", Model = "e-Up", Battery = 65, ExtraPrice = 0 },
                new Car() { CarId = "RTA-149", Brand = "Audi", Model = "e-Tron", Battery = 98, ExtraPrice = 60 },
                new Car() { CarId = "RCS-709", Brand = "Audi", Model = "e-Tron", Battery = 15, ExtraPrice = 60 },
                new Car() { CarId = "RFF-995", Brand = "BMW", Model = "i3", Battery = 61, ExtraPrice = 40 },
                new Car() { CarId = "RHO-859", Brand = "Volkswagen", Model = "e-Up", Battery = 44, ExtraPrice = 0 },
                new Car() { CarId = "RHX-557", Brand = "Nissan", Model = "Leaf", Battery = 13, ExtraPrice = 20 },
                new Car() { CarId = "REF-473", Brand = "Nissan", Model = "Leaf", Battery = 76, ExtraPrice = 20 },
                new Car() { CarId = "RMB-898", Brand = "Volkswagen", Model = "e-Up", Battery = 57, ExtraPrice = 0 },
                new Car() { CarId = "RMV-468", Brand = "Volkswagen", Model = "e-Up", Battery = 84, ExtraPrice = 0 },
                new Car() { CarId = "RHC-386", Brand = "Audi", Model = "e-Tron", Battery = 94, ExtraPrice = 60 },
                new Car() { CarId = "RTF-587", Brand = "BMW", Model = "i3", Battery = 22, ExtraPrice = 40 },
                new Car() { CarId = "RFW-482", Brand = "BMW", Model = "i3", Battery = 36, ExtraPrice = 40 },
                new Car() { CarId = "RVN-153", Brand = "Volkswagen", Model = "e-Golf", Battery = 78, ExtraPrice = 20 },
            };
            this.rents = new List<Rent>()
            {
                new Rent() { RentId = 0, AccountId = 7, CarId = "RTF-587", StartTime = DateTime.Parse("2019-10-02 03:29:00"), EndTime = DateTime.Parse("2019-10-02 05:57:00"), Distance = 37, Price = 3700 },
                new Rent() { RentId = 1, AccountId = 11, CarId = "RZT-841", StartTime = DateTime.Parse("2019-10-02 03:56:00"), EndTime = DateTime.Parse("2019-10-02 06:11:00"), Distance = 55, Price = 5500 },
                new Rent() { RentId = 2, AccountId = 11, CarId = "RTF-587", StartTime = DateTime.Parse("2019-10-02 01:21:00"), EndTime = DateTime.Parse("2019-10-02 02:29:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 3, AccountId = 13, CarId = "RKO-673", StartTime = DateTime.Parse("2019-10-02 22:34:00"), EndTime = DateTime.Parse("2019-10-02 23:26:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 4, AccountId = 11, CarId = "RCS-709", StartTime = DateTime.Parse("2019-10-02 08:31:00"), EndTime = DateTime.Parse("2019-10-02 09:55:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 5, AccountId = 8, CarId = "RVN-153", StartTime = DateTime.Parse("2019-10-02 04:34:00"), EndTime = DateTime.Parse("2019-10-02 05:05:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 6, AccountId = 10, CarId = "RHC-386", StartTime = DateTime.Parse("2019-10-02 00:53:00"), EndTime = DateTime.Parse("2019-10-02 01:35:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 7, AccountId = 1, CarId = "RHC-386", StartTime = DateTime.Parse("2019-10-02 18:39:00"), EndTime = DateTime.Parse("2019-10-02 20:12:00"), Distance = 37, Price = 3700 },
                new Rent() { RentId = 8, AccountId = 3, CarId = "REM-990", StartTime = DateTime.Parse("2019-10-02 08:53:00"), EndTime = DateTime.Parse("2019-10-02 09:47:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 9, AccountId = 8, CarId = "RZF-406", StartTime = DateTime.Parse("2019-10-02 06:07:00"), EndTime = DateTime.Parse("2019-10-02 07:01:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 10, AccountId = 1, CarId = "RZF-406", StartTime = DateTime.Parse("2019-10-02 19:40:00"), EndTime = DateTime.Parse("2019-10-02 21:00:00"), Distance = 37, Price = 3700 },
                new Rent() { RentId = 11, AccountId = 11, CarId = "RZF-406", StartTime = DateTime.Parse("2019-10-02 06:53:00"), EndTime = DateTime.Parse("2019-10-02 08:11:00"), Distance = 37, Price = 3700 },
                new Rent() { RentId = 12, AccountId = 13, CarId = "RMB-898", StartTime = DateTime.Parse("2019-10-02 23:00:00"), EndTime = DateTime.Parse("2019-10-02 23:11:00"), Distance = 3, Price = 300 },
                new Rent() { RentId = 13, AccountId = 3, CarId = "RBT-178", StartTime = DateTime.Parse("2019-10-02 15:15:00"), EndTime = DateTime.Parse("2019-10-02 15:49:00"), Distance = 20, Price = 2000 },
                new Rent() { RentId = 14, AccountId = 9, CarId = "REF-473", StartTime = DateTime.Parse("2019-10-02 08:16:00"), EndTime = DateTime.Parse("2019-10-02 09:30:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 15, AccountId = 5, CarId = "RHO-859", StartTime = DateTime.Parse("2019-10-02 18:57:00"), EndTime = DateTime.Parse("2019-10-02 20:19:00"), Distance = 37, Price = 3700 },
                new Rent() { RentId = 16, AccountId = 0, CarId = "RZT-841", StartTime = DateTime.Parse("2019-10-02 19:58:00"), EndTime = DateTime.Parse("2019-10-02 22:00:00"), Distance = 55, Price = 5500 },
                new Rent() { RentId = 17, AccountId = 11, CarId = "RFW-482", StartTime = DateTime.Parse("2019-10-02 12:38:00"), EndTime = DateTime.Parse("2019-10-02 13:50:00"), Distance = 18, Price = 1800 },
                new Rent() { RentId = 18, AccountId = 3, CarId = "RFP-990", StartTime = DateTime.Parse("2019-10-02 10:34:00"), EndTime = DateTime.Parse("2019-10-02 12:03:00"), Distance = 37, Price = 3700 },
                new Rent() { RentId = 19, AccountId = 9, CarId = "RFW-482", StartTime = DateTime.Parse("2019-10-02 04:47:00"), EndTime = DateTime.Parse("2019-10-02 04:55:00"), Distance = 3, Price = 300 },
                new Rent() { RentId = 20, AccountId = 5, CarId = "RFW-482", StartTime = DateTime.Parse("2019-10-01 04:47:00"), EndTime = DateTime.Parse("2019-10-01 04:55:00"), Distance = 3, Price = 1300 },
            };
            this.licenses = new List<License>()
            {
                new License() { LicenseId = "HX211743", AccountId = 4, Category = "A", StartDate = DateTime.Parse("2016-12-11"), ExpiryDate = DateTime.Parse("2021-12-11") },
                new License() { LicenseId = "LK239013", AccountId = 7, Category = "A", StartDate = DateTime.Parse("2014-01-19"), ExpiryDate = DateTime.Parse("2019-01-19") },
                new License() { LicenseId = "TG725938", AccountId = 5, Category = "AM", StartDate = DateTime.Parse("2013-04-13"), ExpiryDate = DateTime.Parse("2018-04-13") },
                new License() { LicenseId = "IK079491", AccountId = 1, Category = "A", StartDate = DateTime.Parse("2017-02-04"), ExpiryDate = DateTime.Parse("2022-02-04") },
                new License() { LicenseId = "QV978087", AccountId = 14, Category = "A", StartDate = DateTime.Parse("2016-03-24"), ExpiryDate = DateTime.Parse("2021-03-24") },
                new License() { LicenseId = "KS701427", AccountId = 10, Category = "C", StartDate = DateTime.Parse("2015-01-14"), ExpiryDate = DateTime.Parse("2020-01-14") },
                new License() { LicenseId = "SI261106", AccountId = 13, Category = "B", StartDate = DateTime.Parse("2014-10-05"), ExpiryDate = DateTime.Parse("2019-10-05") },
                new License() { LicenseId = "KI156402", AccountId = 6, Category = "A", StartDate = DateTime.Parse("2014-09-08"), ExpiryDate = DateTime.Parse("2019-09-08") },
                new License() { LicenseId = "BX169634", AccountId = 0, Category = "AM", StartDate = DateTime.Parse("2018-03-27"), ExpiryDate = DateTime.Parse("2023-03-27") },
                new License() { LicenseId = "FW577033", AccountId = 8, Category = "D", StartDate = DateTime.Parse("2012-10-04"), ExpiryDate = DateTime.Parse("2017-10-04") },
                new License() { LicenseId = "BW629063", AccountId = 3, Category = "B", StartDate = DateTime.Parse("2012-09-20"), ExpiryDate = DateTime.Parse("2017-09-20") },
                new License() { LicenseId = "ZA116690", AccountId = 9, Category = "B", StartDate = DateTime.Parse("2017-05-23"), ExpiryDate = DateTime.Parse("2022-05-23") },
                new License() { LicenseId = "LY178690", AccountId = 11, Category = "A", StartDate = DateTime.Parse("2016-09-21"), ExpiryDate = DateTime.Parse("2021-09-21") },
                new License() { LicenseId = "MD988378", AccountId = 2, Category = "AM", StartDate = DateTime.Parse("2014-02-06"), ExpiryDate = DateTime.Parse("2019-02-06") },
                new License() { LicenseId = "DS212148", AccountId = 12, Category = "AM", StartDate = DateTime.Parse("2018-07-02"), ExpiryDate = DateTime.Parse("2023-07-02") },
            };
            this.complaints = new List<Complaint>()
            {
                new Complaint() { ComplaintId = 0, RentId = 5, Description = "Nem megfelelő tisztaságú az autó.", Time = DateTime.Parse("2019-10-02 05:05:00"), Chk = 1 },
                new Complaint() { ComplaintId = 1, RentId = 1, Description = "Baleset történt személyi sérüléssel.", Time = DateTime.Parse("2019-10-02 06:11:00"), Chk = 0 },
                new Complaint() { ComplaintId = 2, RentId = 4, Description = "Nem megfelelő tisztaságú az autó.", Time = DateTime.Parse("2019-10-02 09:55:00"), Chk = 1 },
                new Complaint() { ComplaintId = 3, RentId = 6, Description = "Nem megfelelő tisztaságú az autó.", Time = DateTime.Parse("2019-10-02 01:35:00"), Chk = 0 },
                new Complaint() { ComplaintId = 4, RentId = 0, Description = "Meghúzták az autót amíg parkolt.", Time = DateTime.Parse("2019-10-02 05:57:00"), Chk = 0 },
                new Complaint() { ComplaintId = 5, RentId = 3, Description = "Baleset történt, személyi sérülés nélkül.", Time = DateTime.Parse("2019-10-02 23:26:00"), Chk = 0 },
                new Complaint() { ComplaintId = 6, RentId = 2, Description = "Sérült volt az autó a bérlés indítása előtt.", Time = DateTime.Parse("2019-10-02 02:29:00"), Chk = 1 },
                new Complaint() { ComplaintId = 7, RentId = 7, Description = "Baleset történt, személyi sérülés nélkül.", Time = DateTime.Parse("2019-10-02 20:12:00"), Chk = 0 },
            };
            this.accountRepo = new Mock<IRepository<Account, int>>();
            this.carRepo = new Mock<IRepository<Car, string>>();
            this.licenseRepo = new Mock<IRepository<License, string>>();
            this.rentRepo = new Mock<IRepository<Rent, int>>();
            this.complaintRepo = new Mock<IRepository<Complaint, int>>();
            this.accountRepo.Setup(x => x.GetAll()).Returns(this.accounts.AsQueryable());
            this.carRepo.Setup(x => x.GetAll()).Returns(this.cars.AsQueryable());
            this.rentRepo.Setup(x => x.GetAll()).Returns(this.rents.AsQueryable());
            this.licenseRepo.Setup(x => x.GetAll()).Returns(this.licenses.AsQueryable());
            this.complaintRepo.Setup(x => x.GetAll()).Returns(this.complaints.AsQueryable());
            this.mockedLogic = new Logic(this.accountRepo.Object, this.carRepo.Object, this.licenseRepo.Object, this.rentRepo.Object, this.complaintRepo.Object);
        }

        /// <summary>
        /// Tests if the new account gets added to the repository when given correct data.
        /// </summary>
        [Test]
        public void WhenAddAccount_WithCorrectInput_ItGetsAddedToRepository()
        {
            bool success = this.mockedLogic.AddNewAccount("Teszt Elek", "teszt.elek@gmail.com", "Budapest", DateTime.Parse("1996-01-11"), 50, 1000);
            this.accountRepo.Verify(x => x.Add(It.IsAny<Account>()), Times.Once);
            Assert.That(success == true);
        }

        /// <summary>
        /// Tests if the insertion throws exception when given incorrect input data.
        /// </summary>
        [Test]
        public void WhenAddAccount_WithIncorrectInput_ItThrowsException()
        {
            Assert.Throws<FormatException>(() => this.mockedLogic.AddNewAccount("Teszt Elek", "teszt.elek@gmail.com", "Budapest", DateTime.Parse("123465"), 50, 1000));
            this.accountRepo.Verify(x => x.Add(It.IsAny<Account>()), Times.Never);
        }

        /// <summary>
        /// Tests if the new car gets added to the repository when given correct data.
        /// </summary>
        [Test]
        public void WhenAddCar_WithCorrectInput_ItGetsAddedToRepository()
        {
            bool success = this.mockedLogic.AddNewCar("NNX-845", "Volkswagen", "e-Golf", 100, 100);
            this.carRepo.Verify(x => x.Add(It.IsAny<Car>()), Times.Once);
            Assert.That(success == true);
        }

        /// <summary>
        /// Tests if the insertion throws exception when given incorrect input data.
        /// </summary>
        [Test]
        public void WhenAddCar_WithIncorrectInput_ItThrowsException()
        {
            Assert.Throws<FormatException>(() => this.mockedLogic.AddNewCar("NNX-845", "1", "2", 999999999, 99999));
            this.carRepo.Verify(x => x.Add(It.IsAny<Car>()), Times.Never);
        }

        /// <summary>
        /// Tests if the new license gets added to the repository when given correct data.
        /// </summary>
        [Test]
        public void WhenAddLicense_WithCorrectInput_ItGetsAddedToRepository()
        {
            bool success = this.mockedLogic.AddNewLicense("SA12345", 1, "B", DateTime.Parse("2018-01-12"), DateTime.Parse("2022-01-12"), 0);
            this.licenseRepo.Verify(x => x.Add(It.IsAny<License>()), Times.Once);
            Assert.That(success == true);
        }

        /// <summary>
        /// Tests if the insertion throws exception when given incorrect input data.
        /// </summary>
        [Test]
        public void WhenAddLicense_WithIncorrectInput_ItThrowsException()
        {
            Assert.Throws<FormatException>(() => this.mockedLogic.AddNewLicense("SA1234564", 50, "B", DateTime.Parse("1234-41-515"), DateTime.Parse("12452-15-52"), 50500));
            this.licenseRepo.Verify(x => x.Add(It.IsAny<License>()), Times.Never);
        }

        /// <summary>
        /// Tests if the new rent gets added to the repository when given correct data.
        /// </summary>
        [Test]
        public void WhenAddRent_WithCorrectInput_ItGetsAddedToRepository()
        {
            bool success = this.mockedLogic.AddNewRent(1, "REM-990", DateTime.Parse("2019-11-23 21:22:00"), DateTime.Parse("2019-11-23 21:40:00"), 10, 1300);
            this.rentRepo.Verify(x => x.Add(It.IsAny<Rent>()), Times.Once);
            Assert.That(success == true);
        }

        /// <summary>
        /// Tests if the insertion throws exception when given incorrect input data.
        /// </summary>
        [Test]
        public void WhenAddRent_WithIncorrectInput_ItThrowsException()
        {
            Assert.Throws<FormatException>(() => this.mockedLogic.AddNewRent(1, "REM990", DateTime.Parse("201911-23 29:32:00"), DateTime.Parse("2019-121-213 21:40:00"), 10, 1300));
            this.rentRepo.Verify(x => x.Add(It.IsAny<Rent>()), Times.Never);
        }

        /// <summary>
        /// Tests if the new complaint gets added to the repository when given correct data.
        /// </summary>
        [Test]
        public void WhenAddComplaint_WithCorrectInput_ItGetsAddedToRepository()
        {
            bool success = this.mockedLogic.AddNewComplaint(5, "Nem indul a kocsi.", DateTime.Now, 0);
            this.complaintRepo.Verify(x => x.Add(It.IsAny<Complaint>()), Times.Once);
            Assert.That(success == true);
        }

        /// <summary>
        /// Tests if the insertion throws exception when given incorrect input data.
        /// </summary>
        [Test]
        public void WhenAddComplaint_WithIncorrectInput_ItThrowsException()
        {
            Assert.Throws<FormatException>(() => this.mockedLogic.AddNewComplaint(5, "asdf", DateTime.Parse("1235+5152-51"), 5));
            this.complaintRepo.Verify(x => x.Add(It.IsAny<Complaint>()), Times.Never);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetAccountData"/> returns the correct data set.
        /// </summary>
        [Test]
        public void WhenGetAccountData_ReturnsRepositoryData()
        {
            IQueryable<Account> acc = this.mockedLogic.GetAccountData();
            this.accountRepo.Verify(x => x.GetAll(), Times.Once);
            Assert.That(acc, Is.EqualTo(this.accounts));
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetCarData"/> returns the correct data set.
        /// </summary>
        [Test]
        public void WhenGetCarData_ReturnsRepositoryData()
        {
            IQueryable<Car> car = this.mockedLogic.GetCarData();
            this.carRepo.Verify(x => x.GetAll(), Times.Once);
            Assert.That(car, Is.EqualTo(this.cars));
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetLicenseData"/> returns the correct data set.
        /// </summary>
        [Test]
        public void WhenGetLicenseData_ReturnsRepositoryData()
        {
            IQueryable<License> lic = this.mockedLogic.GetLicenseData();
            this.licenseRepo.Verify(x => x.GetAll(), Times.Once);
            Assert.That(lic, Is.EqualTo(this.licenses));
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetRentData"/> returns the correct data set.
        /// </summary>
        [Test]
        public void WhenGetRentData_ReturnsRepositoryData()
        {
            IQueryable<Rent> r = this.mockedLogic.GetRentData();
            this.rentRepo.Verify(x => x.GetAll(), Times.Once);
            Assert.That(r, Is.EqualTo(this.rents));
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetComplaintData"/> returns the correct data set.
        /// </summary>
        [Test]
        public void WhenGetComplaintData_ReturnsRepositoryData()
        {
            IQueryable<Complaint> c = this.mockedLogic.GetComplaintData();
            this.complaintRepo.Verify(x => x.GetAll(), Times.Once);
            Assert.That(c, Is.EqualTo(this.complaints));
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.UpdateAccountData(int, string, string, string, DateTime, int, int)"/> calls the <see cref="IRepository{T, TK}.Update(TK, T)"/> method.
        /// </summary>
        [Test]
        public void WhenUpdateAccountData_ItGetsUpdatedInRepository()
        {
            bool success = this.mockedLogic.UpdateAccountData(2, "Teszt Lajos", "teszt.lajos@gmail.com", "New York", DateTime.Now, 50, 1000);
            this.accountRepo.Verify(x => x.Update(2, It.IsAny<Account>()), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.UpdateCarData(string, string, string, int, int)"/> calls the <see cref="IRepository{T, TK}.Update(TK, T)"/> method.
        /// </summary>
        [Test]
        public void WhenUpdateCarData_ItGetsUpdatedInRepository()
        {
            bool success = this.mockedLogic.UpdateCarData("REM-990", "Teszt", "Teszt", 50, 1500);
            this.carRepo.Verify(x => x.Update("REM-990", It.IsAny<Car>()), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.UpdateLicenseData(string, int, string, DateTime, DateTime, int)"/> calls the <see cref="IRepository{T, TK}.Update(TK, T)"/> method.
        /// </summary>
        [Test]
        public void WhenUpdateLicenseData_ItGetsUpdatedInRepository()
        {
            bool success = this.mockedLogic.UpdateLicenseData("HX211743", 1, "B", DateTime.Now, DateTime.Now.AddYears(4), 0);
            this.licenseRepo.Verify(x => x.Update("HX211743", It.IsAny<License>()), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.UpdateRentData(int, int, string, DateTime, DateTime, int, int)"/> calls the <see cref="IRepository{T, TK}.Update(TK, T)"/> method.
        /// </summary>
        [Test]
        public void WhenUpdateRentData_ItGetsUpdatedInRepository()
        {
            bool success = this.mockedLogic.UpdateRentData(5, 1, "REM-990", DateTime.Now, DateTime.Now.AddMinutes(32), 15, 2500);
            this.rentRepo.Verify(x => x.Update(5, It.IsAny<Rent>()), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.UpdateComplaintData(int, int, string, DateTime, int)"/> calls the <see cref="IRepository{T, TK}.Update(TK, T)"/> method.
        /// </summary>
        [Test]
        public void WhenUpdateComplaintData_ItGetsUpdatedInRepository()
        {
            bool success = this.mockedLogic.UpdateComplaintData(1, 5, "Nem indul az autó.", DateTime.Now, 1);
            this.complaintRepo.Verify(x => x.Update(1, It.IsAny<Complaint>()), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.DeleteAccountData(int)"/> calls the <see cref="IRepository{T, TK}.Delete(TK)"/> method.
        /// </summary>
        [Test]
        public void WhenDeleteAccountData_ItGetsDeletedInRepository()
        {
            bool success = this.mockedLogic.DeleteAccountData(1);
            this.accountRepo.Verify(x => x.Delete(1), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.DeleteCarData(string)"/> calls the <see cref="IRepository{T, TK}.Delete(TK)"/> method.
        /// </summary>
        [Test]
        public void WhenDeleteCarData_ItGetsDeletedInRepository()
        {
            bool success = this.mockedLogic.DeleteCarData("REM-990");
            this.carRepo.Verify(x => x.Delete("REM-990"), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.DeleteLicenseData(string)"/> calls the <see cref="IRepository{T, TK}.Delete(TK)"/> method.
        /// </summary>
        [Test]
        public void WhenDeleteLicenseData_ItGetsDeletedInRepository()
        {
            bool success = this.mockedLogic.DeleteLicenseData("HX211743");
            this.licenseRepo.Verify(x => x.Delete("HX211743"), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.DeleteRentData(int)"/> calls the <see cref="IRepository{T, TK}.Delete(TK)"/> method.
        /// </summary>
        [Test]
        public void WhenDeleteRentData_ItGetsDeletedInRepository()
        {
            bool success = this.mockedLogic.DeleteRentData(1);
            this.rentRepo.Verify(x => x.Delete(1), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.DeleteComplaintData(int)"/> calls the <see cref="IRepository{T, TK}.Delete(TK)"/> method.
        /// </summary>
        [Test]
        public void WhenDeleteComplaintData_ItGetsDeletedInRepository()
        {
            bool success = this.mockedLogic.DeleteComplaintData(1);
            this.complaintRepo.Verify(x => x.Delete(1), Times.Once);
            Assert.IsTrue(success);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetDailyIncome"/> method returns the expected result.
        /// </summary>
        [Test]
        public void WhenGetDailyIncome_ItReturnsExpectedResult()
        {
            IEnumerable<ResultClasses.DailyIncomeResult> result = this.mockedLogic.GetDailyIncome();
            Assert.That(result.Where(x => x.Month == 10 && x.Day == 2).First().Income == 52000);
            Assert.That(result.Where(x => x.Month == 10 && x.Day == 1).First().Income == 1300);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetOverallIncome"/> method returns the expected result.
        /// </summary>
        [Test]
        public void WhenGetOverallIncome_ItReturnsExpectedResult()
        {
            ResultClasses.OverallIncomeResult result = this.mockedLogic.GetOverallIncome();
            Assert.That(result.OverallIncome == 53300);
            Assert.That(result.Average == 26650);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetUserWithMostRents"/> method returns the expected result.
        /// </summary>
        [Test]
        public void WhenGetUserWithMostRents_ItReturnsExpectedResult()
        {
            ResultClasses.RentsByUserResult result = this.mockedLogic.GetUserWithMostRents();
            Assert.That(result.AccountName == "Vincze Kata");
            Assert.That(result.Count == 5);
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetDistanceByCar"/> method returns the expected result.
        /// </summary>
        [Test]
        public void WhenGetDistanceByCar_ItReturnsExpectedResult()
        {
            IEnumerable<ResultClasses.DistancesByCarResult> result = this.mockedLogic.GetDistanceByCar();
            Assert.That(result.Where(x => x.Car == "REM-990").First().Distance == 18);
            Assert.That(result.Where(x => x.Car == "RZF-406").First().Distance == 92);
            Assert.That(result.Where(x => x.Car == "RMB-898").First().Distance == 3);
            Assert.That(result.Where(x => x.Car == "RBT-178").First().Distance == 20);
            Assert.That(result.Where(x => x.Car == "REF-473").First().Distance == 18);
            Assert.That(result.Where(x => x.Car == "RHO-859").First().Distance == 37);
            Assert.That(result.Where(x => x.Car == "RHC-386").First().Distance == 55);
            Assert.That(result.Where(x => x.Car == "RVN-153").First().Distance == 18);
            Assert.That(result.Where(x => x.Car == "RCS-709").First().Distance == 18);
            Assert.That(result.Where(x => x.Car == "RZT-841").First().Distance == 110);
            Assert.IsNull(result.Where(x => x.Car == "RNX-941").FirstOrDefault());
        }

        /// <summary>
        /// Tests if the <see cref="ILogic.GetRentsByUser"/> method returns the expected result by testing the corner cases (user with most and least rents).
        /// </summary>
        [Test]
        public void WhenGetRentsByUser_ItReturnsExpectedResult()
        {
            IEnumerable<ResultClasses.RentsByUserResult> result = this.mockedLogic.GetRentsByUser();

            Assert.That(result.OrderByDescending(x => x.Count).First().AccountName == "Vincze Kata");
            Assert.That(result.OrderByDescending(x => x.Count).First().Count == 5);
            Assert.That(result.OrderByDescending(x => x.Count).Last().Count == 1);
            Assert.That(result.Where(x => x.AccountName == "Vincze Béla").First().Count == 2);
        }
    }
}
