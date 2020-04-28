using AutoMapper;
using CarRental.Logic;
using CarRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CarRental.Web.Controllers
{
    public class AccountsApiController : ApiController
    {
        public class ApiResult
        {
            public bool OperationResult { get; set; }
        }

        private IAccountLogic accLogic;
        private IMapper mapper;

        public AccountsApiController()
        {
            LogicFactory lf = new LogicFactory();
            this.accLogic = lf.GetAccountLogic();
            this.mapper = Models.MapperFactory.CreateMapper();
        }

        // GET: api/CarsApi
        [ActionName("all")]
        [HttpGet]
        public IEnumerable<Account> GetAll()
        {
            var accounts = this.accLogic.GetAccountData();
            return mapper.Map<IEnumerable<Logic.DTO.Account>, IEnumerable<Web.Models.Account>>(accounts);
        }

        // GET: api/CarsApi/del/id
        [ActionName("del")]
        [HttpGet]
        public ApiResult DeleteAccount(int id)
        {
            bool success = this.accLogic.DeleteAccountData(id);
            return new ApiResult()
            {
                OperationResult = success
            };
        }

        // POST
        [ActionName("add")]
        [HttpPost]
        public ApiResult AddAccount(Account acc)
        {
            try
            {
                this.accLogic.AddNewAccount(acc.Name, acc.Email, acc.Address, acc.BirthDate, acc.Minute ?? 0, acc.Monthly ?? 0);
                return new ApiResult()
                {
                    OperationResult = true
                };
            }
            catch (Exception)
            {
                return new ApiResult()
                {
                    OperationResult = false
                };
            }
            
        }

        // POST
        [ActionName("mod")]
        [HttpPost]
        public ApiResult ModAccount(Account acc)
        {
            bool success = this.accLogic.UpdateAccountData(acc.AccountId, acc.Name, acc.Email, acc.Address, acc.BirthDate, acc.Minute ?? 0, acc.Monthly ?? 0);
            return new ApiResult()
            {
                OperationResult = success
            };
        }

    }
}
