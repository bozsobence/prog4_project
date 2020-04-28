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
        static void Main(string[] args)
        {
            // működőképes de nem végleges megoldás, még határidőig interaktívabban lesz megoldva ez
            string url = "http://localhost:59195/api/AccountsApi/";
            Console.WriteLine("Várakozás a webalkalmazás elindulására...");
            Console.WriteLine("Folytatáshoz nyomj entert.");
            Console.ReadLine();
            using(HttpClient client = new HttpClient())
            {

                // GET ALL:
                Console.WriteLine("Az adatok letöltése folyamatban...");
                string json = client.GetStringAsync(url + "all").Result;
                var accounts = JsonConvert.DeserializeObject<List<Account>>(json);
                Console.WriteLine("A táblában szereplő összes adat:\n ");
                foreach (var acc in accounts)
                {
                    Console.WriteLine(acc);
                }
                Console.WriteLine("\nFolytatáshoz nyomj entert.\n");
                Console.ReadLine();
                Dictionary<string, string> postData;
                string response;

                // ADD NEW:
                Console.WriteLine("Új elem hozzáadása:");
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Account.Name), "Teszt Elek");
                postData.Add(nameof(Account.Email), "teszt.elek@email.hu");
                postData.Add(nameof(Account.Address), "Budapest");
                postData.Add(nameof(Account.BirthDate), "1988.11.22.");
                postData.Add(nameof(Account.Minute), "120");
                postData.Add(nameof(Account.Monthly), "1200");
                response = client.PostAsync(url + "add", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("ADD: " + response);
                Console.WriteLine("ALL: " + json);
                Console.WriteLine("\nFolytatáshoz nyomj entert.\n");
                Console.ReadLine();


                // MODIFY:
                Console.WriteLine("Elem módosítása:");
                int accId = JsonConvert.DeserializeObject<List<Account>>(json).First(x => x.Name == "Teszt Elek").AccountId;
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Account.AccountId), accId.ToString());
                postData.Add(nameof(Account.Name), "Teszt Elek");
                postData.Add(nameof(Account.Email), "teszt.elek@email.hu");
                postData.Add(nameof(Account.Address), "Eger");
                postData.Add(nameof(Account.BirthDate), "1988.11.22.");
                postData.Add(nameof(Account.Minute), "12");
                postData.Add(nameof(Account.Monthly), "1200");
                
                response = client.PostAsync(url + "mod", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("MOD: " + response);
                Console.WriteLine("ALL: " + json);
                Console.WriteLine("\nFolytatáshoz nyomj entert.\n");
                Console.ReadLine();


                // DELETE:
                Console.WriteLine("Utoljára hozzáadott elem törlése:");
                response = client.GetStringAsync(url + "del/" + accId).Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("DEL: " + response);
                Console.WriteLine("ALL: " + json);
                Console.ReadLine();
            }

        }
    }
}
