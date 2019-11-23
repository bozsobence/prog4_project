// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This is the interface which contains methods that all repositories must implement.
    /// </summary>
    /// <typeparam name="T">Entity Model Class.</typeparam>
    /// <typeparam name="TK">Type of the primary key. This is needed because it is possible that in a table the primary key is a string or int.</typeparam>
    public interface IRepository<T, TK>
        where T : class
    {
        /// <summary>
        /// Returns one data object.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <returns>Data object to return.</returns>
        T GetOne(TK id);

        /// <summary>
        /// Returns all objects of the database (table).
        /// </summary>
        /// <returns>All objects of the database (table).</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Adds a new element to the database.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        void Add(T element);

        /// <summary>
        /// Updates the selected element.
        /// </summary>
        /// <param name="id">The element to be updated.</param>
        /// <param name="newElement">The new element data.</param>
        void Update(TK id, T newElement);

        /// <summary>
        /// Deletes an element from the database.
        /// </summary>
        /// <param name="id">The element to be deleted.</param>
        void Delete(TK id);

    }
}
