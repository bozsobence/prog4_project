using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace CarRental.Wpf
{
    class MainLogic
    {
        private string url = "http://localhost:59195/api/AccountsApi/";
        HttpClient client = new HttpClient();

        private void SendMessage(bool success)
        {
            string message = success ? "Completed successfully." : "Failed.";
            Messenger.Default.Send(message, "AccountResult");
        }

        public List<AccountVM> GetAccounts()
        {
            string json = client.GetStringAsync(url + "all").Result;
            var accounts = JsonConvert.DeserializeObject<List<AccountVM>>(json);
            return accounts;
        }

        public void DeleteAccount(AccountVM acc)
        {
            bool success = false;
            if (acc != null)
            {
                string json = client.GetStringAsync(url + "del/" + acc.AccountId).Result;
                JObject obj = JObject.Parse(json);
                success = (bool)obj["OperationResult"];
            }
            SendMessage(success);
        }

        private bool EditAccount(AccountVM acc, bool edit)
        {
            if (acc == null)
            {
                return false;
            }

            string myUrl = edit ? url + "mod" : url + "add";
            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (edit)
            {
                postData.Add(nameof(AccountVM.AccountId), acc.AccountId.ToString());
            }
            postData.Add(nameof(AccountVM.Name), acc.Name);
            postData.Add(nameof(AccountVM.Email), acc.Email);
            postData.Add(nameof(AccountVM.Address), acc.Address);
            postData.Add(nameof(AccountVM.BirthDate), acc.BirthDate.ToString());
            postData.Add(nameof(AccountVM.Minute), acc.Minute.ToString());
            postData.Add(nameof(AccountVM.Monthly), acc.Monthly.ToString());

            string json = client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(json);
            return (bool)obj["OperationResult"];


        }

        public void EditAccount(AccountVM acc, Func<AccountVM, bool> editor)
        {
            AccountVM clone = new AccountVM();
            if (acc != null)
            {
                clone.CopyFrom(acc);
            }
            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (acc != null)
                {
                    success = this.EditAccount(clone, true);
                }
                else
                {
                    success = this.EditAccount(clone, false);
                }
                SendMessage(success == true);
            }
        }

    }
}
