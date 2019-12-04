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
            this.logic = BusinessLogic.CreateLogic();
        }

        /// <summary>
        /// Shows the menu for the user.
        /// </summary>
        public void Run()
        {
            bool end = false;
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

                try
                {
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            break;

                        case 1:
                            this.ShowTableContent();
                            break;

                        case 2:
                            this.AddNewRecord();
                            break;
                        case 3:
                            this.ModifyRecord();
                            break;
                        case 4:
                            this.DeleteRecord();
                            break;
                        case 5:
                            this.GetDailyIncome();
                            break;
                        case 6:
                            this.GetOverallIncome();
                            break;
                        case 7:
                            this.GetUserWithMostRents();
                            break;
                        case 8:
                            this.GetDistanceByCar();
                            break;
                        case 9:
                            this.GetRentsByUser();
                            break;
                        case 10:
                            this.GetRecommendation();
                            break;
                        case 11:
                            this.GetCarStatsById();
                            break;
                        case 12:
                            this.GetAllCarStats();
                            break;
                        case 13:
                            end = true;
                            Console.WriteLine("Kilépés...");
                            break;

                        default:
                            Console.WriteLine("Ez a funkció jelenleg nem elérhető.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valamely adat hibás formátumban került bevitelre. Próbáld újra az egyes menüpontoknál kért formátumban!");
                }
                catch (System.Net.WebException)
                {
                    Console.WriteLine("Nem sikerült a kommunikáció a Java végponttal, ellenőrizd hogy fut-e a Glassfish szerver.");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("A keresett elem nem létezik az adatbázisban, ellenőrizd hogy nem történt-e elírás.");
                }
            }
            while (!end);
        }

        private void GetOverallIncome()
        {
            Console.WriteLine(">> PÉNZÜGYI STATISZTIKÁK <<\n");
            Console.WriteLine(this.logic.GetOverallIncome());
        }

        private void GetDailyIncome()
        {
            Console.WriteLine(">> PÉNZÜGYI STATISZTIKÁK NAPI BONTÁSBAN <<\n");
            var incomes = this.logic.GetDailyIncome();
            for (int i = 1; i < 13; i++)
            {
                Console.WriteLine($">> HÓNAP: {i}.");
                var monthly = from x in incomes where x.Month == i select x;
                foreach (var day in monthly)
                {
                    Console.WriteLine("\t" + $"> NAP: {day.Day}.\tBEVÉTEL: {day.Income} Ft");
                }
            }
        }

        private void GetUserWithMostRents()
        {
            Console.WriteLine(">> LEGTÖBB BÉRLÉST INDÍTÓ FELHASZNÁLÓ <<\n");
            Console.WriteLine(this.logic.GetUserWithMostRents());
        }

        private void GetDistanceByCar()
        {
            Console.WriteLine(">> KILOMÉTERÓRA ÁLLÁSA AUTÓNKÉNT LEBONTVA <<\n");
            var res = this.logic.GetDistanceByCar();

            foreach (var car in res)
            {
                Console.WriteLine(car);
            }
        }

        private void GetRentsByUser()
        {
            Console.WriteLine(">> BÉRLÉSEK SZÁMA FELHASZNÁLÓNKÉNTI BONTÁSBAN <<\n");
            var rents = this.logic.GetRentsByUser();
            foreach (var user in rents)
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
                    Console.WriteLine(">> 'ACCOUNTS' TÁBLA ADATAI <<\n");
                    var accData = this.logic.GetAccountData();
                    foreach (var acc in accData)
                    {
                        Console.WriteLine(string.Format($"> ID: {acc.AccountId} | NÉV: {acc.Name} | EMAIL: {acc.Email} | LAKHELY: {acc.Address} |  SZÜLETÉSI IDŐ: {acc.BirthDate.Date.ToString()} | PERCDÍJ: {acc.Minute} | HAVIDÍJ: {acc.Monthly}"));
                    }

                    success = true;
                }
                else if (table.ToUpper().Contains("CAR"))
                {
                    Console.WriteLine(">> 'CARS' TÁBLA ADATAI <<\n");
                    var carData = this.logic.GetCarData();
                    foreach (var car in carData)
                    {
                        Console.WriteLine(string.Format($"> RENDSZÁM: {car.CarId} | MÁRKA: {car.Brand} | MODELL: {car.Model} | AKKUMULÁTOR: {car.Battery}% | EXTRA ÁR: {car.ExtraPrice}"));
                    }

                    success = true;
                }
                else if (table.ToUpper().Contains("LICENSE"))
                {
                    Console.WriteLine(">> 'LICENSES' TÁBLA ADATAI <<\n");
                    var licenseData = this.logic.GetLicenseData();
                    foreach (var lic in licenseData)
                    {
                        Console.WriteLine(string.Format($"> ID: {lic.LicenseId} | FELHASZNÁLÓ ID: {lic.AccountId} | KATEGÓRIA: {lic.Category} | ÉRVÉNYESSÉG KEZDETE: {lic.StartDate.ToString()} | ÉRVÉNYESSÉG VÉGE: {lic.ExpiryDate} | BÜNTETŐPONTOK: {lic.PenaltyPoints}"));
                    }

                    success = true;
                }
                else if (table.ToUpper().Contains("RENT"))
                {
                    Console.WriteLine(">> 'RENTS' TÁBLA ADATAI <<\n");
                    var rentData = this.logic.GetRentData();
                    foreach (var rent in rentData)
                    {
                        Console.WriteLine(string.Format($"> ID: {rent.RentId} | FELHASZNÁLÓ ID: {rent.AccountId} | AUTÓ: {rent.CarId} | KEZDET: {rent.StartTime.ToString()} | VÉGE: {rent.EndTime.ToString()} | TÁVOLSÁG: {rent.Distance} | ÁR: {rent.Price}"));
                    }

                    success = true;
                }
                else if (table.ToUpper().Contains("COMPLAINT"))
                {
                    Console.WriteLine(">> 'COMPLAINT' TÁBLA ADATAI <<\n");
                    var complaintData = this.logic.GetComplaintData();
                    foreach (var comp in complaintData)
                    {
                        Console.WriteLine(string.Format($"> ID: {comp.ComplaintId} | BÉRLÉS ID: {comp.RentId} | LEÍRÁS: {comp.Description} | IDŐPONT: {comp.Time.ToString()} | STÁTUSZ: {comp.Chk}"));
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
                    string licenseId = Console.ReadLine();
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

                    bool success = this.logic.AddNewLicense(licenseId, accId, category, start, expiry, penalty);
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
                    string b = Console.ReadLine();
                    DateTime birthdate = b != string.Empty ? DateTime.Parse(b) : DateTime.MinValue;
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
                    string licenseId = Console.ReadLine();
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

                    bool success = this.logic.UpdateLicenseData(licenseId, accId, category, start, expiry, penalty);
                    string msg = success ? "Sikeres módosítás." : "Hiba történt a módosítás során.";
                    Console.WriteLine(msg);
                    if (!expiryParse || !startParse)
                    {
                        Console.WriteLine("Az egyik megadott dátum érték hibás formátumú vagy üres volt.");
                    }
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
                    if (!endParse || !startParse)
                    {
                        Console.WriteLine("Az egyik megadott dátum érték hibás formátumú vagy üres volt.");
                    }
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
                    if (!timeParse)
                    {
                        Console.WriteLine("Az egyik megadott dátum érték hibás formátumú vagy üres volt.");
                    }
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

        private void GetRecommendation()
        {
            int minute = 0;
            int size = 0;
            int category = 0;
            Console.WriteLine(">> AJÁNLOTT ELŐFIZETÉSI KONSTRUKCIÓ KÉRÉSE JAVA VÉGPONTTÓL <<");
            Console.WriteLine("Add meg havonta hány percet tervezel utazni!");
            minute = int.Parse(Console.ReadLine());
            Console.WriteLine("Válaszd ki milyen méretű autó lenne ideális:");
            Console.WriteLine("1 - kicsi\n2 - közepes\n3 - nagy\n");
            size = int.Parse(Console.ReadLine());
            Console.WriteLine("Válaszd ki milyen kategóriájú autót vezetnél szívesen:");
            Console.WriteLine("1 - olcsó\n2 - normál\n3 - prémium\n");
            category = int.Parse(Console.ReadLine());
            string xml = this.logic.GetRecommendationFromJava(minute, size, category);
            Console.WriteLine(xml);
        }

        private void GetCarStatsById()
        {
            bool success = false;
            do
            {
                Console.WriteLine("Add meg az autó rendszámát, aminek a statisztikáit meg akarod jeleníteni!");
                string id = Console.ReadLine();
                Console.WriteLine(">> MEGADOTT AUTÓ STATISZTIKÁI <<");
                Console.WriteLine(this.logic.GetCarStats(id));
                success = true;
            }
            while (!success);
        }

        private void GetAllCarStats()
        {
            var cars = this.logic.GetCarData();
            Console.WriteLine(">> AUTÓK STATISZTIKÁI <<\n");
            foreach (var car in cars)
            {
                Console.WriteLine(this.logic.GetCarStats(car.CarId));
            }
        }

        private void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Válassz egyet az alábbiak közül:");
            Console.WriteLine("0. Eddig megjelenített adatok törlése a képernyőről");
            Console.WriteLine("1. Megadott tábla tartalmának listázása");
            Console.WriteLine("2. Új rekord beszúrása megadott táblába");
            Console.WriteLine("3. Megadott tábla adott elemének módosítása");
            Console.WriteLine("4. Megadott tábla adott elemének törlése");
            Console.WriteLine("5. Napi bevételek listázása, nap szerint csoportosítva");
            Console.WriteLine("6. Összes bevétel kiírása, napi átlagos bevétel megjelenítése");
            Console.WriteLine("7. Legtöbb bérlést indító felhasználó listázása");
            Console.WriteLine("8. Megtett távolság (kilométeróra állása) autónként csoportosítva");
            Console.WriteLine("9. Felhasználók és az általuk indított bérlések száma");
            Console.WriteLine("10. Várható használat alapján előfizetési konstrukció ajánlása (Java)");
            Console.WriteLine("11. Megadott autó statisztikáinak megjelenítése");
            Console.WriteLine("12. Összes autó statisztikáinak megjelenítése");
            Console.WriteLine("13. Kilépés");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Választani az adott szám beküldésével lehetséges!");
            Console.ResetColor();
        }
    }
}
