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
        private ILogic logic;

        /// <summary>
        /// Initializes the tests.
        /// </summary>
        [SetUp]
        public void Init()
        {

        }

    }
}
