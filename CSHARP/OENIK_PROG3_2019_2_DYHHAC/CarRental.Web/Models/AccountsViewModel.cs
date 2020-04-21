using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Web.Models
{
    public class AccountsViewModel
    {
        public Account CurrentlyEdited { get; set; }
        public IEnumerable<Account> AccountsInDatabase { get; set; }
    }
}