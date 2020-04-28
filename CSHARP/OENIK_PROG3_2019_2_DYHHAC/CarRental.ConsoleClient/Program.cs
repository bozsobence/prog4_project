using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.ConsoleClient
{
    public class Account
    {
        public int AccountId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public int? Minute { get; set; }

        public int? Monthly { get; set; }

        public override string ToString()
        {
            return string.Format($"> ID: {AccountId} | NÉV: {Name} | EMAIL: {Email} | LAKHELY: {Address} |  SZÜLETÉSI IDŐ: {BirthDate.Date} | PERCDÍJ: {Minute} | HAVIDÍJ: {Monthly}");
        }

    }

    class Program
    {
        private static string url = "http://localhost:59195/api/AccountsApi/";
        private static Dictionary<string, string> postData;
        private static string response;
        private static string json;
        static void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Válassz egyet az alábbiak közül:");
            Console.WriteLine("0. Eddig megjelenített adatok törlése a képernyőről");
            Console.WriteLine("1. Accounts tábla tartalmának listázása");
            Console.WriteLine("2. Új rekord beszúrása az Accounts táblába");
            Console.WriteLine("3. Accounts tábla egyik elemének módosítása");
            Console.WriteLine("4. Accounts tábla egyik elemének törlése");
            Console.WriteLine("5. Kilépés");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Választani az adott szám beküldésével lehetséges!");
            Console.ResetColor();
        }
        static void Run()
        {
            bool end = false;
            do
            {
                ShowOptions();
                int choice;
                bool success = int.TryParse(Console.ReadLine(), out choice);
                while (!success)
                {
                    Console.WriteLine("Érvénytelen választás.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    ShowOptions();
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
                            GetAll();
                            break;

                        case 2:
                            AddNew();
                            break;
                        case 3:
                            Modify();
                            break;
                        case 4:
                            Delete();
                            break;
                        case 5:
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
            }
            while (!end);
        }

        private static void Delete()
        {
            Console.WriteLine("Add meg a felhasználó azonosítóját!");
            string id = Console.ReadLine();

            using(HttpClient client = new HttpClient())
            {
                response = client.GetStringAsync(url + "del/" + id).Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("DEL: " + response);
                Console.WriteLine("ALL: " + json);
            }
        }

        private static void Modify()
        {
            Console.WriteLine("Add meg a felhasználó azonosítóját akit módosítani szeretnél!");
            string id = Console.ReadLine();
            Console.WriteLine("Add meg a felhasználónevet!");
            string name = Console.ReadLine();
            Console.WriteLine("Add meg az email címet!");
            string email = Console.ReadLine();
            Console.WriteLine("Add meg a lakhelyet! (város)");
            string address = Console.ReadLine();
            Console.WriteLine("Add meg a születési időpontját! (YYYY-MM-DD)");
            string birthdate = Console.ReadLine();
            Console.WriteLine("Add meg a percdíjat! (csak szám lehet)");
            string minute = Console.ReadLine();
            Console.WriteLine("Add meg a havidíjat! (csak szám lehet)");
            string monthly = Console.ReadLine();

            using (HttpClient client = new HttpClient())
            {
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Account.AccountId), id);
                postData.Add(nameof(Account.Name), name);
                postData.Add(nameof(Account.Email), email);
                postData.Add(nameof(Account.Address), address);
                postData.Add(nameof(Account.BirthDate), birthdate);
                postData.Add(nameof(Account.Minute), minute);
                postData.Add(nameof(Account.Monthly), monthly);
                response = client.PostAsync(url + "mod", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("MOD: " + response);
                Console.WriteLine("ALL:" + json);
            }

        }

        private static void AddNew()
        {
            Console.WriteLine("Add meg a felhasználónevet!");
            string name = Console.ReadLine();

            Console.WriteLine("Add meg az email címet!");
            string email = Console.ReadLine();
            Console.WriteLine("Add meg a lakhelyet! (város)");
            string address = Console.ReadLine();
            Console.WriteLine("Add meg a születési időpontját! (YYYY-MM-DD)");
            string birthdate = Console.ReadLine();
            Console.WriteLine("Add meg a percdíjat! (csak szám lehet)");
            string minute = Console.ReadLine();
            Console.WriteLine("Add meg a havidíjat! (csak szám lehet)");
            string monthly = Console.ReadLine();

            using(HttpClient client = new HttpClient())
            {
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Account.Name), name);
                postData.Add(nameof(Account.Email), email);
                postData.Add(nameof(Account.Address), address);
                postData.Add(nameof(Account.BirthDate), birthdate);
                postData.Add(nameof(Account.Minute), minute);
                postData.Add(nameof(Account.Monthly), monthly);
                response = client.PostAsync(url + "add", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("ADD: " + response);
                Console.WriteLine("ALL:" + json);
            }
        }

        private static void GetAll()
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("Az adatok letöltése folyamatban...");
                json = client.GetStringAsync(url + "all").Result;
                var accounts = JsonConvert.DeserializeObject<List<Account>>(json);
                Console.WriteLine("A táblában szereplő összes adat:\n ");
                foreach (var acc in accounts)
                {
                    Console.WriteLine(acc);
                }
            }
        }

        static void Main(string[] args)
        {
            Run();

            // régi, nem interaktív (de teljes mértékben működő megoldás)
            //string url = "http://localhost:59195/api/AccountsApi/";
            //Console.WriteLine("Várakozás a webalkalmazás elindulására...");
            //Console.WriteLine("Folytatáshoz nyomj entert.");
            //Console.ReadLine();
            //using(HttpClient client = new HttpClient())
            //{

            //    // GET ALL:
            //    Console.WriteLine("Az adatok letöltése folyamatban...");
            //    string json = client.GetStringAsync(url + "all").Result;
            //    var accounts = JsonConvert.DeserializeObject<List<Account>>(json);
            //    Console.WriteLine("A táblában szereplő összes adat:\n ");
            //    foreach (var acc in accounts)
            //    {
            //        Console.WriteLine(acc);
            //    }
            //    Console.WriteLine("\nFolytatáshoz nyomj entert.\n");
            //    Console.ReadLine();
            //    Dictionary<string, string> postData;
            //    string response;

            //    // ADD NEW:
            //    Console.WriteLine("Új elem hozzáadása:");
            //    postData = new Dictionary<string, string>();
            //    postData.Add(nameof(Account.Name), "Teszt Elek");
            //    postData.Add(nameof(Account.Email), "teszt.elek@email.hu");
            //    postData.Add(nameof(Account.Address), "Budapest");
            //    postData.Add(nameof(Account.BirthDate), "1988.11.22.");
            //    postData.Add(nameof(Account.Minute), "120");
            //    postData.Add(nameof(Account.Monthly), "1200");
            //    response = client.PostAsync(url + "add", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            //    json = client.GetStringAsync(url + "all").Result;
            //    Console.WriteLine("ADD: " + response);
            //    Console.WriteLine("ALL: " + json);
            //    Console.WriteLine("\nFolytatáshoz nyomj entert.\n");
            //    Console.ReadLine();


            //    // MODIFY:
            //    Console.WriteLine("Elem módosítása:");
            //    int accId = JsonConvert.DeserializeObject<List<Account>>(json).First(x => x.Name == "Teszt Elek").AccountId;
            //    postData = new Dictionary<string, string>();
            //    postData.Add(nameof(Account.AccountId), accId.ToString());
            //    postData.Add(nameof(Account.Name), "Teszt Elek");
            //    postData.Add(nameof(Account.Email), "teszt.elek@email.hu");
            //    postData.Add(nameof(Account.Address), "Eger");
            //    postData.Add(nameof(Account.BirthDate), "1988.11.22.");
            //    postData.Add(nameof(Account.Minute), "12");
            //    postData.Add(nameof(Account.Monthly), "1200");
                
            //    response = client.PostAsync(url + "mod", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            //    json = client.GetStringAsync(url + "all").Result;
            //    Console.WriteLine("MOD: " + response);
            //    Console.WriteLine("ALL: " + json);
            //    Console.WriteLine("\nFolytatáshoz nyomj entert.\n");
            //    Console.ReadLine();


            //    // DELETE:
            //    Console.WriteLine("Utoljára hozzáadott elem törlése:");
            //    response = client.GetStringAsync(url + "del/" + accId).Result;
            //    json = client.GetStringAsync(url + "all").Result;
            //    Console.WriteLine("DEL: " + response);
            //    Console.WriteLine("ALL: " + json);
            //    Console.ReadLine();
            //}

        }
    }
}
