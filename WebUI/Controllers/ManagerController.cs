using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Models.ViewModels;
using SRN.DAL;
using WebUI.Helpers;

namespace Web.Controllers
{
    public class ManagerController : CustomController
    {
        // GET: Manager
        public ActionResult Index()
        {
            var singleOrDefault = BetDatabase.Accounts.SingleOrDefault(t => t.UserId == User.Identity.Name);
            if (singleOrDefault != null)
                ViewBag.Balance = singleOrDefault.AmountE;
            return View();
        }

        public ActionResult UserAccount(string id)
        {
            ViewBag.User = id;
            return View();
        }
        public async Task<JsonResult> UserStatement(string id)
        {
          var statements = await BetDatabase.Statements.Select(s => new
          {
              s.Account,
              s.Amount,
              s.StatetmentDate,
              stmtDate = s.StatetmentDate.ToString(),
              s.Comment,
              s.Transcation
          }).Where(s => s.Account == id).OrderByDescending(s=>s.StatetmentDate).ToListAsync();
            int ct = statements.Count;
          return Json(statements, JsonRequestBehavior.AllowGet);  
        }
        public JsonResult BranchSummary()
        {
            var branchManager = BetDatabase.Accounts.SingleOrDefault(t => t.UserId == User.Identity.Name);
            if (branchManager == null) return Json(new {}, JsonRequestBehavior.AllowGet);
            var branchId = Convert.ToInt32(branchManager.AdminE);
            var branchObject = BetDatabase.Branches.SingleOrDefault(x => x.BranchId == branchId);
            var totalStakes = BetDatabase.Receipts.Where(h => h.BranchId == branchId).Sum(x => x.Stake);
            var managerBalance = branchManager.AmountE;
            var TellerBalance = BetDatabase.Accounts.Where(a => a.AdminE == branchId.ToString()).Sum(c => c.AmountE) - managerBalance;
            if (branchObject != null)
                return Json(
                    new
                    {
                        BranchName = branchObject.BranchName,
                        TotalStake = totalStakes,
                        Managerbalance = managerBalance,
                       TotalTellerBalance=TellerBalance,
                        BranchMaximum = 2300000,     // to check this with you
                    },
                    JsonRequestBehavior.AllowGet
                    );
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BranchTeller()
        {
            var branchManager = BetDatabase.Accounts.SingleOrDefault(t => t.UserId == User.Identity.Name);
            var branch = (branchManager.AdminE);
            string query =
                "select  A.userid,AmountE as Balance,[dbo].[TellerBets](getdate(),A.UserId) As Sales,[dbo].[TellerBetsCount](getdate(),A.UserId) As TotalReciepts,[dbo].[TellerCashOut](getdate(),A.UserId) As CashOut from Accounts A   where AdminE=" + branch;
            var report = new List<ManagerSummaryVM>();
            try
            {
                var bridge = new DBBridge();
                var reader = bridge.ExecuteReaderSQL(query);
                while (reader.Read())
                {
                    var dayreport = new ManagerSummaryVM
                    {
                        TellerName = reader.GetString(0),
                         TellerBalance = Convert.ToDecimal(reader.GetDouble(1)),
                        TotalSales = Convert.ToDecimal(reader.GetDecimal(2)),
                        CashOut = Convert.ToDecimal(reader.GetDecimal(4)),
                       // ReceiptCount = reader.GetInt16(3)

                    };
                    report.Add(dayreport);
                }
            }
            catch (Exception er)
            {
            }
            var reports = report.Select(x => new
            {
                Balance=x.TellerBalance,
               TotalReceipt= x.ReceiptCount,
                UserId=x.TellerName,
                Sales=x.TotalSales,
                CashOut=x.CashOut
            }).ToList();
            return Json(reports, JsonRequestBehavior.AllowGet);  
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                BetDatabase.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}