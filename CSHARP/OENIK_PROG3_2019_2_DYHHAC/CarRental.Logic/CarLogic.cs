// <copyright file="CarLogic.cs" company="PlaceholderCompany">
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
    /// This class is responsible for the CRUD operations of the Cars table.
    /// </summary>
    public class CarLogic : ICarLogic
    {
        private IRepository<Car, string> carRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CarLogic"/> class.
        /// </summary>
        /// <param name="cars">The repository that handles the car table.</param>
        public CarLogic(IRepository<Car, string> cars)
        {
            this.carRepo = cars;
        }

        /// <inheritdoc/>
        public bool AddNewCar(string id, string brand, string model, int battery, int extraPrice)
        {
            Car car = new Car()
            {
                CarId = id,
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
        public IQueryable<Car> GetCarData()
        {
            return this.carRepo.GetAll();
        }

        /// <inheritdoc/>
        public bool IsValidCar(string id)
        {
            try
            {
                this.carRepo.GetOne(id);
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
        public bool UpdateCarData(string id, string brand, string model, int battery, int extraPrice)
        {
            if (this.IsValidCar(id))
            {
                Car car = new Car()
                {
                    CarId = id,
                    Brand = brand,
                    Model = model,
                    Battery = battery,
                    ExtraPrice = extraPrice,
                };
                this.carRepo.Update(id, car);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
