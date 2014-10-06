using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Models.Concrete;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class TransfersController : CustomController
    {
        // GET: Transfers

        public async Task<ActionResult> Index()
        {
            var singleOrDefault = await BetDatabase.Accounts.SingleOrDefaultAsync(t => t.UserId == User.Identity.Name);
            if (singleOrDefault != null)
                ViewBag.Balance = singleOrDefault.AmountE;
            return View();
        }

        // GET: Transfers/Details/5 
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Transfers/Create
        public ActionResult Create()
        {
            return View();
        }
        public async Task<JsonResult> GetUsers()
        {
            var branch = await BetDatabase.Accounts.SingleOrDefaultAsync(m => m.UserId == User.Identity.Name);
            var accounts = await BetDatabase.Accounts.Where(m => m.AdminE==branch.AdminE).Select(a => new
            {
               UserId= a.UserId
            }).ToListAsync();
            int ct = accounts.Count();
            return Json(accounts, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> CashTransfer()
        {
            var account = await BetDatabase.Accounts.Select(a => new
            {
                a.UserId,
                a.AmountE
            }).SingleOrDefaultAsync(a => a.UserId == User.Identity.Name);
            ViewBag.Balance = account.AmountE ?? 0;
            return View();
        }
        public ActionResult AddPayment(Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
            var acc = BetDatabase.Accounts.SingleOrDefault(m => m.UserId == payment.UserId);
            if (acc == null) return Json(new Notification()
            {
                Successful = false,
                Message = "An error occured, this teller account does not exist. Contact the systems administrator for help."
            }, JsonRequestBehavior.AllowGet);

            if (payment.TransType == "From Account")
            {
                acc.AmountE = acc.AmountE - payment.AmountPaid;
                var statement = new Statement
                {
                    BalBefore = acc.AmountE,
                    Amount = payment.AmountPaid,
                    Transcation = "Money Transfer",
                    StatetmentDate = DateTime.Now,
                    Account = acc.UserId,
                    Comment = "Teller Deposit",
                    BalAfter = acc.AmountE
                };
                BetDatabase.Accounts.AddOrUpdate(acc);
                BetDatabase.Statements.Add(statement);
                BetDatabase.SaveChanges();
                var managerAcc = BetDatabase.Accounts.SingleOrDefault(m => m.UserId == User.Identity.Name);
                if (managerAcc == null) return Json(new Notification()
                {
                    Successful = false,
                    Message = "An error occured, this manager account does not exist. Contact the systems administrator for help."
                }, JsonRequestBehavior.AllowGet); ;
                managerAcc.AmountE = managerAcc.AmountE + payment.AmountPaid;
                var managerStatement = new Statement
                {
                    BalBefore = acc.AmountE,
                    Amount = payment.AmountPaid,
                    Transcation = "Money Transfer",
                    StatetmentDate = DateTime.Now,
                    Account = managerAcc.UserId,
                    Comment = "Teller Transfer From " + acc.UserId + " To " + managerAcc.UserId,
                    BalAfter = acc.AmountE
                };

                BetDatabase.Accounts.AddOrUpdate(managerAcc);
                BetDatabase.Statements.Add(managerStatement);
                BetDatabase.SaveChanges();
                return Json(new Notification()
                {
                    Successful = true,
                    Message = "Payment from account was made successfully."
                }, JsonRequestBehavior.AllowGet);
            }
            else if (payment.TransType == "To Account")
            {
                acc.AmountE = acc.AmountE + payment.AmountPaid;

                var statement = new Statement
                {
                    BalBefore = acc.AmountE,
                    Amount = payment.AmountPaid,
                    Transcation = "Transfer  ",
                    StatetmentDate = DateTime.Now,
                    Account = acc.UserId,
                    Comment = "Manager Transfer To Teller",
                    BalAfter = acc.AmountE
                };

                BetDatabase.Accounts.AddOrUpdate(acc);
                BetDatabase.Statements.Add(statement);
                BetDatabase.SaveChanges();
                var managerAcc = BetDatabase.Accounts.SingleOrDefault(m => m.UserId == User.Identity.Name);

                if (managerAcc == null) return Json(new Notification
                {
                    Successful = false,
                    Message = "An error occured, this manager account does not exist. Contact the systems administrator for help."
                }, JsonRequestBehavior.AllowGet);
                managerAcc.AmountE = managerAcc.AmountE + payment.AmountPaid;
                var managerStatement = new Statement
                {
                    BalBefore = acc.AmountE,
                    Amount = payment.AmountPaid,
                    Transcation = "Money Transfer",
                    StatetmentDate = DateTime.Now,
                    Account = managerAcc.UserId,
                    Comment = "Teller Transfer From " + acc.UserId + " To " + managerAcc.UserId,
                    BalAfter = acc.AmountE
                };

                BetDatabase.Accounts.AddOrUpdate(managerAcc);
                BetDatabase.Statements.Add(managerStatement);
                BetDatabase.SaveChanges();
                return Json(new Notification()
                {
                    Successful = true,
                    Message = "Payment to account was made successfully."
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new Notification
            {
                Successful = false,
                Message = "An error occured while saving entries to the database. Contact the systems administrator for help."
            }, JsonRequestBehavior.AllowGet);
        }


        // POST: Transfers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
               // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        } 

        // GET: Transfers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transfers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Transfers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transfers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
