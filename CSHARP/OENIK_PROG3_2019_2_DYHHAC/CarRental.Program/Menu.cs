// <copyright file="Menu.cs" company="PlaceholderCompany">
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
    /// This is a menu which displays at the start of the program.
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Shows the menu for the user.
        /// </summary>
        public void Run()
        {
            this.ShowOptions();
            do
            {
                int choice;
                bool success = int.TryParse(Console.ReadLine(), out choice);
                while (!success)
                {
                    Console.WriteLine("Érvénytelen választás.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    this.ShowOptions();
                    success = int.TryParse(Console.ReadLine(), out choice);
                }

                switch (choice)
                {
                    default:
                        Console.WriteLine("Ez a funkció jelenleg nem elérhető.");
                        break;
                }
            }
            while (true);
        }

        private void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Válassz egyet az alábbiak közül:");
            Console.WriteLine("1. Elérhető adattáblák listázása");
            Console.WriteLine("2. Adatok listázása megadott táblából");
            Console.WriteLine("3. Új felhasználó felvitele a rendszerbe");
            Console.WriteLine("4. Új autó felvitele a rendszerbe");
            Console.WriteLine("5. Egyéb új adat beszúrása, törlése, frissítése");
            Console.WriteLine("6. Statisztikák megjelenítése");
            Console.WriteLine("7. Felhasználó bérléseinek lekérdezése a Java végpontból");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Választani az adott szám beküldésével lehetséges!");
            Console.ResetColor();
        }
    }
}
