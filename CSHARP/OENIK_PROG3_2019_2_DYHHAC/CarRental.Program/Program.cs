// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CarRental.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// It is the main class of the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// This is the main method of the program.
        /// </summary>
        public static void Main()
        {
            Display menu = new Display();
            menu.Run();
        }
    }
}
