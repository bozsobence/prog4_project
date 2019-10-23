
namespace CarRental.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;

    /// <summary>
    /// Interface for the Rent Repository.
    /// </summary>
    /// <typeparam name="TRent">Generic parameter for the Rent object.</typeparam>
    public interface IRentRepository<TRent> : IRepository<TRent, int>
        where TRent : Rent
    {
        /// <summary>
        /// Adds a new rent to the database.
        /// </summary>
        /// <param name="rent">The rent to be added.</param>
        void AddRent(Rent rent);

        /// <summary>
        /// Updates the car belonging to the selected rent.
        /// </summary>
        /// <param name="id">The rent to be updated.</param>
        /// <param name="newCarId">The new car to be set.</param>
        void UpdateCar(int id, string newCarId);

        /// <summary>
        /// Updates the start time of the selected rent.
        /// </summary>
        /// <param name="id">The rent to be updated.</param>
        /// <param name="newStart">The new start time to be set.</param>
        void UpdateStart(int id, DateTime newStart);

        /// <summary>
        /// Updates the end time of the selected rent.
        /// </summary>
        /// <param name="id">The rent to be updated.</param>
        /// <param name="newEnd">The new end time to be set.</param>
        void UpdateEnd(int id, DateTime newEnd);

        /// <summary>
        /// Updates the driven distance of the selected rent.
        /// </summary>
        /// <param name="id">The rent to be updated.</param>
        /// <param name="newDistance">The new distance to be set.</param>
        void UpdateDistance(int id, int newDistance);

        /// <summary>
        /// Deletes the selected rent from the database.
        /// </summary>
        /// <param name="id">The rent to be deleted.</param>
        void DeleteRent(int id);

    }
}
