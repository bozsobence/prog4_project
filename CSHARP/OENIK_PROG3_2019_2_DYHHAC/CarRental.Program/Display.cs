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
    using CarRental.Data;
    using CarRental.Logic;
    using CarRental.Repository;

    /// <summary>
    /// This is the main application which the user interacts with.
    /// </summary>
    public class Display
    {
        private ILogic logic;

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
                    case 4: this.DeleteRecord();
                        break;
                    case 5: this.GetDailyIncome();
                        break;
                    case 6: this.GetOverallIncome();
                        break;
                    case 7: this.GetUserWithMostRents();
                        break;
                    case 8: this.GetDistanceByCar();
                        break;
                    case 9: this.GetExcludedUsers();
                        break;
                    default:
                        Console.WriteLine("Ez a funkció jelenleg nem elérhető.");
                        break;
                }
            }
            while (true);
        }

        private void GetOverallIncome()
        {
            Console.WriteLine(">> OVERALL INCOME AND AVERAGE DAILY INCOME RESULT:\n");
            Console.WriteLine(this.logic.GetOverallIncome());
        }

        private void GetDailyIncome()
        {
            Console.WriteLine(">> DAILY INCOMES RESULT:\n");
            var incomes = this.logic.GetDailyIncome();
            for (int i = 1; i < 13; i++)
            {
                Console.WriteLine($">> MONTH: {i}");
                var monthly = from x in incomes where x.Month == i select x;
                foreach (var day in monthly)
                {
                    Console.WriteLine("\t" + day);
                }
            }
        }

        private void GetUserWithMostRents()
        {
            Console.WriteLine(">> USER WITH MOST RENTS RESULT:\n");
            Console.WriteLine(this.logic.GetUserWithMostRents());
        }

        private void GetDistanceByCar()
        {
            Console.WriteLine(">> DRIVEN DISTANCES BY CAR RESULT:\n");
            var res = this.logic.GetDistanceByCar();
            foreach (var car in res)
            {
                Console.WriteLine(car);
            }
        }

        private void GetExcludedUsers()
        {
            Console.WriteLine(">> EXCLUDED USERS RESULT:\n");
            var excluded = this.logic.GetExcludedUsers();
            foreach (var user in excluded)
            {
                Console.WriteLine(user);
            }
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
                    Console.WriteLine(">> RECORDS OF ACCOUNT TABLE:\n");
                    var accData = this.logic.GetAccountData();
                    foreach (var acc in accData)
                    {
                        Console.WriteLine(string.Format($"> ID: {acc.accountID} | NAME: {acc.name} | EMAIL: {acc.email} | ADDRESS: {acc.address} | BIRTHDATE: {acc.birthdate.Date.ToString()} | MINUTE: {acc.minute} | MONTHLY: {acc.monthly}"));
                    }

                    success = true;
                }
                else if (table.ToUpper().Contains("CAR"))
                {
                    Console.WriteLine(">> RECORDS OF CAR TABLE:\n");
                    var carData = this.logic.GetCarData();
                    foreach (var car in carData)
                    {
                        Console.WriteLine(string.Format($"> NUMBERPLATE: {car.plate} | BRAND: {car.brand} | MODEL: {car.model} | BATTERY: {car.battery}% | EXTRA PRICE: {car.extraPrice}"));
                    }

                    success = true;
                }
                else if (table.ToUpper().Contains("LICENSE"))
                {
                    Console.WriteLine(">> RECORDS OF LICENSE TABLE:\n");
                    var licenseData = this.logic.GetLicenseData();
                    foreach (var lic in licenseData)
                    {
                        Console.WriteLine(string.Format($"> ID: {lic.licenseID} | ACCOUNT: {lic.accountID} | CATEGORY: {lic.category} | START: {lic.startDate.ToString()} | EXPIRES: {lic.expiryDate} | PENALTY POINTS: {lic.penaltyPoints}"));
                    }

                    success = true;
                }
                else if (table.ToUpper().Contains("RENT"))
                {
                    Console.WriteLine(">> RECORDS OF RENT TABLE:\n");
                    var rentData = this.logic.GetRentData();
                    foreach (var rent in rentData)
                    {
                        Console.WriteLine(string.Format($"> ID: {rent.rentID} | ACCOUNT: {rent.accountID} | CAR: {rent.carID} | START: {rent.starttime.ToString()} | END: {rent.endtime.ToString()} | DISTANCE: {rent.distance} | PRICE: {rent.price}"));
                    }

                    success = true;
                }
                else if (table.ToUpper().Contains("COMPLAINT"))
                {
                    Console.WriteLine(">> RECORDS OF COMPLAINT TABLE:\n");
                    var complaintData = this.logic.GetComplaintData();
                    foreach (var comp in complaintData)
                    {
                        Console.WriteLine(string.Format($"> ID: {comp.complaintID} | RENT: {comp.rentID} | DESCRIPTION: {comp.description} | TIME: {comp.time.ToString()} | CHECKED: {comp.@checked}"));
                    }

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
            bool correctTable = true;
            do
            {
                correctTable = true;
                Console.Write("Add meg a tábla nevét, amihez új rekordot akarsz hozzáadni: ");
                string table = Console.ReadLine();
                if (table.ToUpper().Contains("ACCOUNT"))
                {
                    Console.WriteLine("Add meg a felhasználónevet!");
                    string name = Console.ReadLine();
                    Console.WriteLine("Add meg az email címet!");
                    string email = Console.ReadLine();
                    Console.WriteLine("Add meg a lakhelyet! (város)");
                    string address = Console.ReadLine();
                    Console.WriteLine("Add meg a születési időpontját! (YYYY-MM-DD)");
                    DateTime birthdate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a percdíjat! (csak szám lehet)");
                    int minute = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a havidíjat! (csak szám lehet)");
                    int monthly = int.Parse(Console.ReadLine());

                    bool success = this.logic.AddNewAccount(name, email, address, birthdate, minute, monthly);
                    string msg = success ? "Sikeres hozzáadás." : "Hiba történt a hozzáadás során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("CAR"))
                {
                    Console.WriteLine("Add meg a rendszámot!");
                    string plate = Console.ReadLine();
                    Console.WriteLine("Add meg az autó márkáját!");
                    string brand = Console.ReadLine();
                    Console.WriteLine("Add meg a modellt!");
                    string model = Console.ReadLine();
                    Console.WriteLine("Add meg az akkumulátor töltöttségét!");
                    int battery = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a felár értékét! (0 ha nincs)");
                    int extra = int.Parse(Console.ReadLine());

                    bool success = this.logic.AddNewCar(plate, brand, model, battery, extra);
                    string msg = success ? "Sikeres hozzáadás." : "Hiba történt a hozzáadás során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("LICENSE"))
                {
                    Console.WriteLine("Add meg a jopgosítványszámot!");
                    string licenseID = Console.ReadLine();
                    Console.WriteLine("Add meg a hozzá tartozó felhasználó azonosítóját! (csak szám lehet)");
                    int accId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a kategóriát!");
                    string category = Console.ReadLine();
                    Console.WriteLine("Add meg az érvényesség kezdetét! (YYYY-MM-DD)");
                    DateTime start = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg az érvényesség végét! (YYYY-MM-DD)");
                    DateTime expiry = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a büntetőpontok számát!");
                    int penalty = int.Parse(Console.ReadLine());

                    bool success = this.logic.AddNewLicense(licenseID, accId, category, start, expiry, penalty);
                    string msg = success ? "Sikeres hozzáadás." : "Hiba történt a hozzáadás során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("RENT"))
                {
                    Console.WriteLine("Add meg a bérléshez tartozó felhasználó azonosítóját!");
                    int accountId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg az autó rendszámát!");
                    string carId = Console.ReadLine();
                    Console.WriteLine("Add meg a kezdés időpontját! (YYYY-MM-DD HH:MM)");
                    DateTime start = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a befejezés időpontját! (YYYY-MM-DD HH:MM)");
                    DateTime end = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a megtett távolságot!");
                    int distance = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a bérlés árát!");
                    int price = int.Parse(Console.ReadLine());

                    bool success = this.logic.AddNewRent(accountId, carId, start, end, distance, price);
                    string msg = success ? "Sikeres hozzáadás." : "Hiba történt a hozzáadás során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("COMPLAINT"))
                {
                    Console.WriteLine("Add meg a bejelentéshez tartozó bérlés azonosítóját!");
                    int rentId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a bejelentés szövegét!");
                    string description = Console.ReadLine();
                    Console.WriteLine("Add meg a bejelentés időpontját! (YYYY-MM-DD HH:MM)");
                    DateTime time = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg hogy ellenőrizve lett-e a bejelentés! (0 vagy 1 lehet)");
                    int chk = int.Parse(Console.ReadLine());

                    bool success = this.logic.AddNewComplaint(rentId, description, time, chk);
                    string msg = success ? "Sikeres hozzáadás." : "Hiba történt a hozzáadás során.";
                    Console.WriteLine(msg);
                }
                else
                {
                    Console.WriteLine("Nincs ilyen tábla az adatbázisban, próbáld újra.");
                    correctTable = false;
                }
            }
            while (!correctTable);
        }

        private void ModifyRecord()
        {
            bool correctTable = true;
            do
            {
                correctTable = true;
                Console.Write("Add meg a tábla nevét, amiben rekordot szeretnél módosítani: ");
                string table = Console.ReadLine();
                if (table.ToUpper().Contains("ACCOUNT"))
                {
                    Console.WriteLine("Add meg a felhasználó azonosítóját akit módosítani szeretnél!");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a felhasználónevet!");
                    string name = Console.ReadLine();
                    Console.WriteLine("Add meg az email címet!");
                    string email = Console.ReadLine();
                    Console.WriteLine("Add meg a lakhelyet! (város)");
                    string address = Console.ReadLine();
                    Console.WriteLine("Add meg a születési időpontját! (YYYY-MM-DD)");
                    DateTime birthdate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a percdíjat! (csak szám lehet)");
                    string cr = Console.ReadLine();
                    int minute = cr != string.Empty ? int.Parse(cr) : -1;
                    Console.WriteLine("Add meg a havidíjat! (csak szám lehet)");
                    cr = Console.ReadLine();
                    int monthly = cr != string.Empty ? int.Parse(cr) : -1;

                    bool success = this.logic.UpdateAccountData(id, name, email, address, birthdate, minute, monthly);
                    string msg = success ? "Sikeres módosítás." : "Hiba történt a módosítás során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("CAR"))
                {
                    Console.WriteLine("Add meg az autó rendszámát amit módosítani szeretnél!");
                    string plate = Console.ReadLine();
                    Console.WriteLine("Add meg az autó márkáját!");
                    string brand = Console.ReadLine();
                    Console.WriteLine("Add meg a modellt!");
                    string model = Console.ReadLine();
                    Console.WriteLine("Add meg az akkumulátor töltöttségét!");
                    string cr = Console.ReadLine();
                    int battery = cr != string.Empty ? int.Parse(cr) : -1;
                    Console.WriteLine("Add meg a felár értékét! (0 ha nincs)");
                    cr = Console.ReadLine();
                    int extra = cr != string.Empty ? int.Parse(cr) : -1;

                    bool success = this.logic.UpdateCarData(plate, brand, model, battery, extra);
                    string msg = success ? "Sikeres módosítás." : "Hiba történt a módosítás során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("LICENSE"))
                {
                    Console.WriteLine("Add meg a jopgosítvány számát amit módosítani szeretnél!");
                    string licenseID = Console.ReadLine();
                    Console.WriteLine("Add meg a hozzá tartozó felhasználó azonosítóját! (csak szám lehet)");
                    string cr = Console.ReadLine();
                    int accId = cr != string.Empty ? int.Parse(cr) : -1;
                    Console.WriteLine("Add meg a kategóriát!");
                    string category = Console.ReadLine();
                    Console.WriteLine("Add meg az érvényesség kezdetét! (YYYY-MM-DD)");
                    DateTime start;
                    cr = Console.ReadLine();
                    bool startParse = DateTime.TryParse(cr, out start);
                    Console.WriteLine("Add meg az érvényesség végét! (YYYY-MM-DD)");
                    DateTime expiry;
                    cr = Console.ReadLine();
                    bool expiryParse = DateTime.TryParse(cr, out expiry);
                    Console.WriteLine("Add meg a büntetőpontok számát!");
                    cr = Console.ReadLine();
                    int penalty = cr != string.Empty ? int.Parse(cr) : -1;

                    bool success = this.logic.UpdateLicenseData(licenseID, accId, category, start, expiry, penalty);
                    string msg = success ? "Sikeres módosítás." : "Hiba történt a módosítás során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("RENT"))
                {
                    Console.WriteLine("Add meg a módosítani kívánt bérlés azonosítóját!");
                    int rentId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a bérléshez tartozó felhasználó azonosítóját!");
                    string cr = Console.ReadLine();
                    int accountId = cr != string.Empty ? int.Parse(cr) : -1;
                    Console.WriteLine("Add meg az autó rendszámát!");
                    string carId = Console.ReadLine();
                    Console.WriteLine("Add meg a kezdés időpontját! (YYYY-MM-DD HH:MM)");
                    DateTime start;
                    cr = Console.ReadLine();
                    bool startParse = DateTime.TryParse(cr, out start);
                    Console.WriteLine("Add meg a befejezés időpontját! (YYYY-MM-DD HH:MM)");
                    DateTime end;
                    cr = Console.ReadLine();
                    bool endParse = DateTime.TryParse(cr, out end);
                    Console.WriteLine("Add meg a megtett távolságot!");
                    cr = Console.ReadLine();
                    int distance = cr != string.Empty ? int.Parse(cr) : -1;
                    Console.WriteLine("Add meg a bérlés árát!");
                    cr = Console.ReadLine();
                    int price = cr != string.Empty ? int.Parse(cr) : -1;

                    bool success = this.logic.UpdateRentData(rentId, accountId, carId, start, end, distance, price);
                    string msg = success ? "Sikeres módosítás." : "Hiba történt a módosítás során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("COMPLAINT"))
                {
                    Console.WriteLine("Add meg a módosítani kívánt bejelentés azonosítóját!");
                    int compId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Add meg a bejelentéshez tartozó bérlés azonosítóját!");
                    string cr = Console.ReadLine();
                    int rentId = cr != string.Empty ? int.Parse(cr) : -1;
                    Console.WriteLine("Add meg a bejelentés szövegét!");
                    string description = Console.ReadLine();
                    Console.WriteLine("Add meg a bejelentés időpontját! (YYYY-MM-DD HH:MM)");
                    DateTime time;
                    cr = Console.ReadLine();
                    bool timeParse = DateTime.TryParse(cr, out time);
                    Console.WriteLine("Add meg hogy ellenőrizve lett-e a bejelentés! (0 vagy 1 lehet)");
                    cr = Console.ReadLine();
                    int chk = cr != string.Empty ? int.Parse(cr) : -1;

                    bool success = this.logic.UpdateComplaintData(compId, rentId, description, time, chk);
                    string msg = success ? "Sikeres módosítás." : "Hiba történt a módosítás során.";
                    Console.WriteLine(msg);
                }
                else
                {
                    Console.WriteLine("Nincs ilyen tábla az adatbázisban, próbáld újra.");
                    correctTable = false;
                }
            }
            while (!correctTable);
        }

        private void DeleteRecord()
        {
            bool correctTable = true;
            do
            {
                correctTable = true;
                Console.Write("Add meg a tábla nevét, amiből törölni szeretnél: ");
                string table = Console.ReadLine();
                if (table.ToUpper().Contains("ACCOUNT"))
                {
                    Console.WriteLine("Add meg a felhasználó azonosítóját amit törölni szeretnél!");
                    int id = int.Parse(Console.ReadLine());
                    bool success = this.logic.DeleteAccountData(id);
                    string msg = success ? "Sikeres törlés." : "Hiba történt a törlés során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("CAR"))
                {
                    Console.WriteLine("Add meg az autó rendszámát amit törölni szeretnél!");
                    string plate = Console.ReadLine();
                    bool success = this.logic.DeleteCarData(plate);
                    string msg = success ? "Sikeres törlés." : "Hiba történt a törlés során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("LICENSE"))
                {
                    Console.WriteLine("Add meg a jogosítvány számát amit törölni szeretnél!");
                    string id = Console.ReadLine();
                    bool success = this.logic.DeleteLicenseData(id);
                    string msg = success ? "Sikeres törlés." : "Hiba történt a törlés során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("RENT"))
                {
                    Console.WriteLine("Add meg a bérlés azonosítóját amit törölni szeretnél!");
                    int id = int.Parse(Console.ReadLine());
                    bool success = this.logic.DeleteRentData(id);
                    string msg = success ? "Sikeres törlés." : "Hiba történt a törlés során.";
                    Console.WriteLine(msg);
                }
                else if (table.ToUpper().Contains("COMPLAINT"))
                {
                    Console.WriteLine("Add meg a bejelentés azonosítóját amit törölni szeretnél!");
                    int id = int.Parse(Console.ReadLine());
                    bool success = this.logic.DeleteComplaintData(id);
                    string msg = success ? "Sikeres törlés." : "Hiba történt a törlés során.";
                    Console.WriteLine(msg);
                }
                else
                {
                    Console.WriteLine("Nincs ilyen tábla az adatbázisban, próbáld újra.");
                    correctTable = false;
                }
            }
            while (!correctTable);
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
            Console.WriteLine("7. Legtöbb bérlést indító felhasználó listázása");
            Console.WriteLine("8. Megtett távolság (kilométeróra állása) autónként csoportosítva");
            Console.WriteLine("9. Az alkalmazás használatára nem jogosult felhasználók listázása");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Választani az adott szám beküldésével lehetséges!");
            Console.ResetColor();
        }
    }
}
