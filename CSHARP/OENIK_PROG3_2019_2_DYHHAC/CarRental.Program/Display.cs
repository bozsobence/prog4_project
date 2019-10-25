// <copyright file="Display.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Program
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Logic;

    /// <summary>
    /// This is a menu which displays at the start of the program.
    /// </summary>
    public class Display
    {
        private Logic logic;

        /// <summary>
        /// Initializes a new instance of the <see cref="Display"/> class.
        /// </summary>
        public Display()
        {
            this.logic = new Logic();
        }

        /// <summary>
        /// Shows the menu for the user.
        /// </summary>
        public void Run()
        {
            do
            {
                this.ShowOptions();
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
                    case 1: this.ShowTableContent();
                        break;
                    case 2: this.AddNewRecord();
                        break;
                    case 3: this.ModifyRecord();
                        break;
                    default:
                        Console.WriteLine("Ez a funkció jelenleg nem elérhető.");
                        break;
                }
            }
            while (true);
        }

        private void ShowTableContent()
        {
            bool success = false;
            do
            {
                Console.Write("Add meg a tábla nevét, amiből listázni szeretnél: ");
                string table = Console.ReadLine();
                if (table.ToUpper().Contains("ACCOUNT"))
                {
                    Console.WriteLine(this.logic.GetAccountData());
                    success = true;
                }
                else if (table.ToUpper().Contains("CAR"))
                {
                    Console.WriteLine(this.logic.GetCarData());
                    success = true;
                }
                else if (table.ToUpper().Contains("LICENSE"))
                {
                    Console.WriteLine(this.logic.GetLicenseData());
                    success = true;
                }
                else if (table.ToUpper().Contains("RENT"))
                {
                    Console.WriteLine(this.logic.GetRentData());
                    success = true;
                }
                else if (table.ToUpper().Contains("COMPLAINT"))
                {
                    Console.WriteLine(this.logic.GetComplaintData());
                    success = true;
                }
                else
                {
                    Console.WriteLine("Nincs ilyen tábla az adatbázisban, próbáld újra.");
                }
            }
            while (!success);
        }

        private void AddNewRecord()
        {

        }

        private void ModifyRecord()
        {

        }

        private void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Válassz egyet az alábbiak közül:");
            Console.WriteLine("1. Megadott tábla tartalmának listázása");
            Console.WriteLine("2. Új rekord beszúrása megadott táblába");
            Console.WriteLine("3. Megadott tábla adott elemének módosítása");
            Console.WriteLine("4. Megadott tábla adott elemének törlése");
            Console.WriteLine("5. Napi bevételek listázása, nap szerint csoportosítva");
            Console.WriteLine("6. Összes bevétel kiírása, napi átlagos bevétel megjelenítése");
            Console.WriteLine("7. Legtöbb és legkevesebb bérlést indító felhasználók listázása");
            Console.WriteLine("8. Megtett távolság (kilométeróra állása) autónként csoportosítva");
            Console.WriteLine("9. Az alkalmazás használatára nem jogosult felhasználók listázása");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Választani az adott szám beküldésével lehetséges!");
            Console.ResetColor();
        }
    }
}
