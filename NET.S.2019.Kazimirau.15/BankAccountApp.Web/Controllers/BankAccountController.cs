using BankAccountApp.BLL.DataTransferObjects;
using BankAccountApp.BLL.Interfaces;
using BankAccountApp.CCL.Mappers;
using BankAccountApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankAccountApp.Web.Controllers
{
    public class BankAccountController : Controller
    {
        const int PAGE_SIZE = 5;

        private readonly IBankAccountService _service;

        public BankAccountController(IBankAccountService service)
        {
            _service = service;
        }

        public ActionResult Index(int page = 1)
        {
            IEnumerable<BankAccountViewModel> bankAccounts = CustomMapper<BankAccountDTO, BankAccountViewModel>.Map(_service.GetAll());

            PageViewModel<BankAccountViewModel> pvm = new PageViewModel<BankAccountViewModel>
            {
                Items = bankAccounts.OrderBy(b => b.Id).Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PAGE_SIZE,
                    TotalItems = bankAccounts.Count()
                }
            };

            return View(pvm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var lst = Enum.GetValues(typeof(AccountTypeDTO));
            SelectList accTypes = new SelectList(lst);
            ViewBag.AccountTypes = accTypes;

            return PartialView("CreatePartial");
        }

        [HttpPost]
        public ActionResult Create(BankAccountViewModel bankAccount)
        {
            if (ModelState.IsValid)
            {
                if (bankAccount != null)
                {
                    var bankAccountDTO = CustomMapper<BankAccountViewModel, BankAccountDTO>.Map(bankAccount);
                    _service.CreateNew(bankAccountDTO);

                    return RedirectToAction("Index");
                }
            }

            return HttpNotFound("Can't create bank account");
        }

        [HttpGet]
        public ActionResult Deposit(int id)
        {
            BankAccountViewModel bankAccount = CustomMapper<BankAccountDTO, BankAccountViewModel>.Map(_service.Get(id));
            if (bankAccount?.IsOpened == true)
            {
                return PartialView("DepositPartial", bankAccount);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Deposit(int id, decimal amount)
        {
            _service.Deposit(id, amount);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Withdraw(int id)
        {
            BankAccountViewModel bankAccount = CustomMapper<BankAccountDTO, BankAccountViewModel>.Map(_service.Get(id));
            if (bankAccount?.IsOpened == true)
            {
                return PartialView("WithdrawPartial", bankAccount);
            }

            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Withdraw(int id, decimal amount)
        {
            _service.Withdraw(id, amount);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Transfer()
        {
            return PartialView("TransferPartial");
        }

        [HttpPost]
        public ActionResult Transfer(int firstId, int secondId, decimal amount)
        {
            _service.Withdraw(firstId, amount);
            _service.Deposit(secondId, amount);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Close(int id)
        {
            BankAccountViewModel bankAccount = CustomMapper<BankAccountDTO, BankAccountViewModel>.Map(_service.Get(id));
            if (bankAccount != null)
            {
                _service.Close(id);
                bankAccount.IsOpened = false;

                return PartialView("OpenClosePartial", bankAccount);
            }

            return HttpNotFound("Can't close bank account");
        }

        [HttpGet]
        public ActionResult Open(int id)
        {
            BankAccountViewModel bankAccount = CustomMapper<BankAccountDTO, BankAccountViewModel>.Map(_service.Get(id));
            if (_service.Get(id) != null)
            {
                _service.Open(id);
                bankAccount.IsOpened = true;

                return PartialView("OpenClosePartial", bankAccount);
            }

            return HttpNotFound("Can't open bank account");
        }
    }
}