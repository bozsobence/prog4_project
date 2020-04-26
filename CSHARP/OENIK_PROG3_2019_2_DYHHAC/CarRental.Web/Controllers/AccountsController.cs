using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CarRental.Logic;
using CarRental.Web.Models;

namespace CarRental.Web.Controllers
{
    public class AccountsController : Controller
    {
        private IAccountLogic accLogic;
        private IMapper mapper;
        private AccountsViewModel vm;

        public AccountsController()
        {
            LogicFactory lf = new LogicFactory();
            this.accLogic = lf.GetAccountLogic();
            this.mapper = Models.MapperFactory.CreateMapper();
            this.vm = new AccountsViewModel();
            vm.CurrentlyEdited = new Account();
            vm.AccountsInDatabase = mapper.Map<IEnumerable<CarRental.Logic.DTO.Account>, IEnumerable<CarRental.Web.Models.Account>>(this.accLogic.GetAccountData());

        }

        public Account GetOne(int id)
        {
            var acc = this.accLogic.GetAccountData().Where(x => x.AccountId == id).Single();
            return this.mapper.Map<CarRental.Logic.DTO.Account, CarRental.Web.Models.Account>(acc);
        }

        // GET: Accounts
        public ActionResult Index()
        {
            ViewData["editAction"] = "Add";
            return View("AccountIndex", this.vm);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id)
        {
            return View("AccountDetails", this.GetOne(id));
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["editAction"] = "Edit";
            vm.CurrentlyEdited = this.GetOne(id);
            return View("AccountIndex", vm);
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account acc, string editAction)
        {
            if (ModelState.IsValid && acc != null)
            {
                TempData["editResult"] = "Successfully edited the selected account.";
                if (editAction == "Add")
                {
                    this.accLogic.AddNewAccount(acc.Name, acc.Email, acc.Address, acc.BirthDate, acc.Minute ?? 0, acc.Monthly ?? 0);
                }
                else
                {
                    bool success = this.accLogic.UpdateAccountData(acc.AccountId, acc.Name, acc.Email, acc.Address, acc.BirthDate, acc.Minute ?? 0, acc.Monthly ?? 0);
                    if (!success)
                    {
                        TempData["editResult"] = "Failed to edit the selected account.";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewData["editAction"] = "Edit";
                vm.CurrentlyEdited = acc;
                return View("AccountIndex", vm);
            }
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id)
        {
            TempData["editResult"] = "delete failed";
            if (this.accLogic.DeleteAccountData(id))
            {
                TempData["editResult"] = "Account successfully deleted.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
