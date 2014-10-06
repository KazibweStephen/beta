using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Models.Concrete;
using Domain.Models.ViewModels;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class ReceptController : CustomController
    {
        //
        // GET: /Recept/
        public ActionResult Index()
        {
            // var receipts = BetDatabase.Receipts.Include(r => r.Branch).OrderByDescending(x => x.betdate).Where(h=>h.status !=5);
            var singleOrDefault = BetDatabase.Accounts.SingleOrDefault(t => t.UserId == User.Identity.Name);
            if (singleOrDefault != null)
                ViewBag.Balance = singleOrDefault.AmountE;
            return View();
        }

        //

        // GET: /Recept/
        public JsonResult GetReciepts()
        {
            var date1 = DateTime.Today;
            var date2 = DateTime.Today.AddDays(1);
            var receipts = BetDatabase.Receipts.Include(r => r.Branch).OrderByDescending(x => x.ReceiptDate).Where(h => h.ReceiptStatus != -1 && h.ReceiptDate > date1 && h.ReceiptDate<date2).Select(r => new
            {
                ReceiptId = r.ReceiptId,
                r.ReceiptStatus,
                r.Branch.BranchName,
               ReceiptDate=r.ReceiptDate.ToString(),
                r.Stake,
                r.TotalOdds,
                r.UserId
            }).ToList();
            return Json(receipts, JsonRequestBehavior.AllowGet);
        }
        //
        // GET: /Recept/Details/5
        public async Task<JsonResult> GetDailyReciepts(string date)
        {
            var date1 = Convert.ToDateTime(date);
            var date2 =  Convert.ToDateTime(date).AddDays(1);
            var receipts = await BetDatabase.Receipts
                .Include(r => r.Branch)
                .OrderByDescending(r => r.ReceiptDate)
                .Where(r => r.ReceiptStatus != -1 && r.ReceiptDate > date1 && r.ReceiptDate < date2).Select(receipt => new
                {
                    RecieptId = receipt.ReceiptId,
                    receipt.Stake,
                    receipt.ReceiptDate,
                    receipt.ReceiptStatus,
                    receipt.Branch.BranchName,
                    receipt.TotalOdds,
                    receipt.UserId
                })
                .ToListAsync();
            return Json(receipts, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Statement()
        {
            var user = await BetDatabase.Accounts
                .OrderByDescending(a => a.DateE)
                .Select(u => new
                {
                    u.UserId,
                    u.AmountE
                })
                .SingleOrDefaultAsync(u => u.UserId == User.Identity.Name);

            ViewBag.Balance = user.AmountE;
            var statements = await BetDatabase.Statements.ToListAsync();
            return View(statements);
        }

        public ActionResult Betmatch()
        {
            return View(new Bet());
        }
        public async Task<ActionResult> Details(int id = 0)
        {
            ViewBag.RecieptId = id;
            var receipt = await BetDatabase.Receipts.Include(r => r.GameBets).SingleOrDefaultAsync(r => r.ReceiptId == id);
            if (Request.IsAjaxRequest()) return Json(receipt, JsonRequestBehavior.AllowGet);
            return View(receipt);       
        }
        //public JsonResult RecieptDetails(int id = 0)
        //{  
        //   // var receiptsdetails = BetDatabase.BettedMatches.Where(x => x.ReceiptId== id);
        //    List<BettedMatch> receiptsmatches = BetDatabase.BettedMatches.Where(x => x.ReceiptId == id).ToList();
        //    var receipt = receiptsmatches.Select(x => new {id=x.MatchID ,choice=x.BetOption.OptionName,x.odd,type=x.BetOption.BetCategory.Bet_type}).ToList();
        //    return Json(receipt, JsonRequestBehavior.AllowGet);
        //}
        public JsonResult RecieptData(string  id = "")
        {
            int serial = Convert.ToInt32(id);
            var constring = ConfigurationManager.ConnectionStrings["BetConnection"].ConnectionString;
            var con = new SqlConnection(constring);               
            var query = "SELECT  MatchNo,[dbo].[ReturnTeamName](HomeTeamId) as HomeTeam,[dbo].[ReturnTeamName](AwayTeamId) as AwayTeam,"+
    "[dbo].[ReturnOptionName](BetOptionId) as choice, [dbo].[ReturnCategoryName](BetOptionId) as category,HomeScore,AwayScore,stake,userid,m.starttime,r.TotalOdds , rs.statusName,r.receiptdate, convert(varchar(5) ,HomeScore)+':'+convert(varchar(5) ,AwayScore) as FT,convert(varchar(5) ,HalfTimeHomeScore)+':'+convert(varchar(5) ,HalfTimeAwayScore) as HT " +
" FROM [dbo].[Bets] bm inner join [dbo].[Matches] m on bm.MatchID=m.MatchNo inner join Receipts r on r.ReceiptID=bm.RecieptId  inner join ReceiptStatus rs on r.ReceiptStatus=rs.StatusId    where bm.RecieptId="+id;
            var model = new List<RecieptDetailsVm>();
            var dt = new DataTable();
            con.Open();
            var da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            con.Close();
       
            for (var i = 0; i <dt.Rows.Count; i++)
                {
                    model.Add(new RecieptDetailsVm
                    {
                        MatchNo = Convert.ToInt32(dt.Rows[i]["MatchNo"]),
                        HomeTeam = dt.Rows[i]["HomeTeam"].ToString(),
                        AwayTeam = dt.Rows[i]["AwayTeam"].ToString(),
                        CategoryName = dt.Rows[i]["category"].ToString(),
                        OptionName = dt.Rows[i]["choice"].ToString(),
                        UserId = dt.Rows[i]["userid"].ToString(),
                        SetOdd=Convert.ToDouble(dt.Rows[i]["totalodds"]),
                        BetMoney = Convert.ToDouble(dt.Rows[i]["stake"]),
                        Stime = Convert.ToDateTime(dt.Rows[i]["starttime"]),
                        Status = dt.Rows[i]["StatusName"].ToString(),
                        BetDate = Convert.ToDateTime(dt.Rows[i]["receiptdate"]),
                        FT = dt.Rows[i]["FT"].ToString(),
                        HT = (dt.Rows[i]["HT"]).ToString(),
                        WinAmount = Convert.ToDouble(dt.Rows[i]["totalodds"]) * Convert.ToDouble(dt.Rows[i]["stake"]),
                    });
                }
           var recieptmatches=model.Select(x=>new {id=x.MatchNo,choice=x.OptionName,type=x.CategoryName,x.AwayTeam,x.HomeTeam,x.BetMoney,x.SetOdd,Teller=x.UserId,team=(x.HomeTeam+" vs "+x.AwayTeam),status=x.Status,Scores="(FT"+x.FT+" HT"+x.HT+")",time=x.Stime.ToString(CultureInfo.InvariantCulture),Cancel=CancelStatus(x.BetDate),WonAmount=x.WinAmount}).ToList();
           return Json(recieptmatches, JsonRequestBehavior.AllowGet);    
        
        }
        //
        // GET: /Recept/Create
        public ActionResult Create()
        {          
            ViewBag.BranchId = new SelectList(BetDatabase.Branches, "BranchId", "BranchName");
            return View();
        }
        public bool CancelStatus(DateTime dt) {
            var rt = DateTime.Now.Subtract(dt);
            var totalmin = Convert.ToInt32(rt.TotalMinutes);
            return totalmin < 10;
        }
        //
        public ActionResult Payments()
        {
            var account = BetDatabase.Accounts.SingleOrDefault(t => t.UserId == User.Identity.Name);
            if (account != null)
                ViewBag.Balance = account.AmountE;
            return View();
        }

        // POST: /Recept/Create
        [HttpPost]
        public ActionResult Create(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                BetDatabase.Receipts.Add(receipt);
                BetDatabase.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(BetDatabase.Branches, "BranchId", "BranchName", receipt.BranchId);
            return View(receipt);
        }
        //
        // GET: /Recept/Edit/5
        public ActionResult Edit(int id = 0)
        {
            var receipt = BetDatabase.Receipts.Find(id);
            if (receipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(BetDatabase.Branches, "BranchId", "BranchName", receipt.BranchId);
            return View(receipt);
        }
        //
        // POST: /Recept/Edit/5
        [HttpPost]
        public ActionResult Edit(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                BetDatabase.Entry(receipt).State = EntityState.Modified;
                BetDatabase.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(BetDatabase.Branches, "BranchId", "BranchName", receipt.BranchId);
            return View(receipt);
        }
        //
        // GET: /Recept/Delete/5
        public async Task<ActionResult> Delete(int id = 0)
        {
            var receipt = await BetDatabase.Receipts.FindAsync(id);
            receipt.ReceiptStatus = -1;
            BetDatabase.Receipts.AddOrUpdate();
            BetDatabase.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<JsonResult> CancelReciept(int id = 0)
        {
            var receipt = BetDatabase.Receipts.Find(id);
            var tellerAccount = await BetDatabase.Accounts.SingleOrDefaultAsync(x => x.UserId == receipt.UserId);
            
            if (receipt == null)
            {
                return Json("Receipt Not Found", JsonRequestBehavior.AllowGet);
            }
            tellerAccount.AmountE = tellerAccount.AmountE - receipt.Stake;
            receipt.ReceiptStatus = -1;
            var tellerStatement = new Statement
            {
                BalBefore = tellerAccount.AmountE,
                BalAfter = tellerAccount.AmountE,
                Comment = "Ticket " + receipt.ReceiptId + " Canceling",
                Transcation = "Reciept Canceling",
                Account = User.Identity.Name
            };

            BetDatabase.Statements.Add(tellerStatement);
            BetDatabase.Receipts.AddOrUpdate();
            BetDatabase.Accounts.AddOrUpdate();
            BetDatabase.SaveChanges();
            return Json("Receipt Was Canceled", JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> PayReciept(int id = 0)
        {
            var msg = "";
            var receipt = await  BetDatabase.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return Json("Reciept Not Found", JsonRequestBehavior.AllowGet);
            }
            if (receipt.ReceiptStatus != 3) return Json(msg, JsonRequestBehavior.AllowGet);
            receipt.ReceiptStatus = 4;
            var cashierAccount = await BetDatabase.Accounts.SingleOrDefaultAsync(t => t.UserId == User.Identity.Name);
            var balance = cashierAccount.AmountE;
            var winAmount = receipt.TotalOdds * receipt.Stake;
            if (balance > winAmount)//Make Payments
            {
                cashierAccount.DateE = DateTime.Now;
                cashierAccount.AmountE = balance - winAmount;
                var statement = new Statement
                {
                    Account = cashierAccount.UserId,
                    BalBefore = cashierAccount.AmountE,
                    Amount = winAmount,
                    BalAfter = cashierAccount.AmountE,
                    Comment = "Payment of Win Ticket Number" + receipt.ReceiptId,
                    Controller = cashierAccount.UserId,
                    Error = false,
                    Transcation = "Ticket Payment",
                    Serial = Convert.ToString(receipt.ReceiptId)
                };
                BetDatabase.Receipts.AddOrUpdate(receipt);
                BetDatabase.Statements.AddOrUpdate(statement);
                BetDatabase.Accounts.AddOrUpdate(cashierAccount);
                BetDatabase.SaveChanges();
                return Json("Reciept Sucessfull", JsonRequestBehavior.AllowGet);
            }
            msg = "You have less money.please contact admin .";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
   
          //public JsonResult AjaxUpload(Bet model)
          //{
          //       // here you can save your file to the database...      
          //        Receipt receipt = new Receipt(); //Start New Reciept
          //        BarCodeGenerator bcg = new BarCodeGenerator();// Generate Reciept
          //        string receiptid = bcg.GenerateRandomString(7);
          //        //receipt.userid = "davidagent";
          //        receipt.userid = User.Identity.Name;
          //        Account acc = BetDatabase.Accounts.Single(x => x.userID == receipt.userid);
          //        int id = Convert.ToInt32(model.RecieptSize);
          //        String betStake = model.Stake.ToString();
          //        String betWin = (model.Stake * model.TotalOdd).ToString();
          //        int games = model.RecieptSize;
          //        string response = "";           
          //        receipt.BranchId = 1;
          //        receipt.status = 0;
          //        receipt.setno = "890";
          //        receipt.RecieptID = Convert.ToInt32(receiptid);
          //        BetDatabase.Receipts.Add(receipt);
          //        BetDatabase.SaveChanges();    
          //        BetCategory betcat = new BetCategory();              
          //        double cost = 0, ttodd = 1;
          //        float bettingLimit = 800000;
          //        cost = Convert.ToDouble(betStake);
          //            if ((cost >= 1000) && (cost <= bettingLimit))//betting limit
          //            {
          //                string bets = model.BetData[0];
          //                string []bet=bets.Split('_');
          //                for (int i = 0; i < bet.Length; i++)
          //                {                    
          //                    string matchno = bet[i];
          //                    string[] _matchoptions =matchno.Split('.');                             
          //                    try
          //                    {             
          //                        BettedMatch bm = new BettedMatch();
          //                        bm.MatchID =Convert.ToInt32 (_matchoptions[0]);                            
          //                        bm.optionid = Convert.ToInt32 (_matchoptions[1]);
          //                        bm.betcategory = Convert.ToInt32 (_matchoptions[2]);
          //                        bm.odd  = Convert.ToDouble (_matchoptions[3]);
          //                        bm.ReceiptId = receipt.RecieptID;
          //                        bm.matchstatus = "";
          //                        bm.setno = receipt.setno;
          //                        BetDatabase.BettedMatches.Add(bm);
          //                        BetDatabase.SaveChanges();
          //                    }
          //                    catch (Exception er)
          //                    {
          //                        string msg = er.Message;
          //                    }
          //                }
                       
          //               // receipt.RecieptID = Convert.ToInt32(receiptid);
          //                receipt.setodd = Convert.ToDouble(ttodd);
          //                receipt.status = 1;
          //                receipt.setsize = bet.Length;
          //                receipt.betmoney = cost;
          //                receipt.betdate = DateTime.Now;
          //                receipt.status = 1;
          //                receipt.submitedsize = 0;
          //                receipt.wonsize = 0;            
          //                acc.date_e = DateTime.Now;
          //               // receipt.RecieptID = 34;                    
          //                BetDatabase.Entry(receipt).State = EntityState.Modified;                 
          //                stmt statement = new stmt();
          //                statement.account = receipt.userid;
          //                statement.ammount = receipt.betmoney;
          //                statement.controller = receipt.userid;
          //                statement.dat_e = DateTime.Now;
          //                statement.balbefore = acc.ammount_e;
          //                statement.balafter = acc.ammount_e + receipt.betmoney;
          //                acc.ammount_e = acc.ammount_e + receipt.betmoney;
          //                statement.transcation = "Teller Bet";
          //                statement.method = "Online";
          //                statement.serial = receiptid;
          //                BetDatabase.Accounts.AddOrUpdate(acc);
          //                BetDatabase.stmts.Add(statement);
          //                BetDatabase.SaveChanges();
          //                response=("Success");
          //            }
          //            else if (cost < 1000)
          //            {
          //                receipt.RecieptID = 0;
          //                response = ("Minimum betting stake is UGX 1000. Please enter amount more than UGX 1000.");
          //            }
          //            else
          //            {
          //                receipt.RecieptID = 0;
          //                response = ("Maximum stake is UGX " + bettingLimit + ". Please enter amount less than UGX " + bettingLimit + ".");
          //            }
                
          //         return new JsonResult { Data = new { message = response, RecieptNumber = receipt.RecieptID, RecieptTime = DateTime.Now.ToString() } };
          //}

        [HttpPost]
        public async Task<JsonResult> SaveLists(List<String> id)
        {
            // Deserialize it to a dictionary
            // var dic =  Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<String, dynamic>>(jsonString);
            var result = String.Format("Fist item in list: '{0}'", id[0]);
            var betStake = id[0];
            var userBalance = id[0];
            int games = Convert.ToInt16(id[0]);
            var receipt = new Receipt();
            var bcg = new BarCodeGenerator();
            var betcat = new BetCategory();
            const double ttodd = 1;
            const float bettingLimit = 800000;
            if (Convert.ToDecimal(betStake) >= Convert.ToDecimal(userBalance))
                return Json(new
                {
                    Result = result,
                    RecieptTime = DateTime.Now,
                    RecieptNumber = receipt.ReceiptId
                },
                    JsonRequestBehavior.AllowGet);
            var cost = Convert.ToDouble(betStake);
            if ((cost >= 1000) && (cost <= bettingLimit))//betting limit
            {
                var all = (ArrayList)(Session["Current_bets"]);
                var gameNumbers = new int[games];
                for (var i = 0; i < games; i++)
                {
                    var bet = (string[])all[i];
                    gameNumbers[i] = Convert.ToInt32(bet[0]);
                }
                var receiptid = bcg.GenerateRandomString(7);
                if (receiptid != "")
                {
                }
                for (var i = 0; i < games; i++)
                {
                    var bet = (string[])all[i];
                    var matchno = bet[0];
                    var choice = bet[4];
                    try
                    {
                        //Straight bet
                        if (choice.Equals("H") || choice.Equals("A") || choice.Equals("X"))
                        {
                            choice = bet[4].Equals("H") ? "Home" : (bet[4].Equals("A") ? "Away" : "Draw");
                            betcat.Name = "Straight";
                        }

                            //wire bet
                        else if (choice.Equals("U") || choice.Equals("O"))
                        {
                            choice = bet[4].Equals("U") ? "Under" : "Over";
                            betcat.Name = "wire";
                        }

                            //double chance bet
                        else if (choice.Equals("1X") || choice.Equals("2X") || choice.Equals("12"))
                        {
                            betcat.Name = "dc";
                        }

                            //halftime bet
                        else if (choice.Equals("H1") || choice.Equals("HX") || choice.Equals("H2"))
                        {
                            choice = bet[4].Equals("H1") ? "Home" : (bet[4].Equals("H2") ? "Away" : "Draw");
                            betcat.Name = "halftime";
                        }

                            //handicap bet
                        else if (choice.Equals("HC1") || choice.Equals("HCX") || choice.Equals("HC2"))
                        {
                            choice = bet[4].Equals("HC1") ? "Home" : (bet[4].Equals("HC2") ? "Away" : "Draw");
                            betcat.Name = "hc";
                        }
                            //wire bet
                        else if (choice.Equals("OD") || choice.Equals("EV"))
                        {
                            choice = bet[4].Equals("OD") ? "Odd" : "Even";
                            betcat.Name = "oddeven";
                        }
                        var bm = new Bet
                        {
                            MatchId = Convert.ToInt32(matchno),
                            RecieptId = Convert.ToInt32(receiptid)
                            //bm.odd = 3;
                            //bm.betcategory = 1;
                            //bm.matchstatus = "";
                        };
                            
                    }
                    catch (Exception er)
                    {
                        var msg = er.Message;
                    }

                }
                receipt.ReceiptDate = DateTime.Now;
                receipt.TotalOdds = Convert.ToDouble(ttodd);
                receipt.ReceiptStatus = 1;
                //receipt.submitedsize = 0;
                //receipt.wonsize = 0;
                //receipt.setsize = games;
                receipt.Stake = cost;
                receipt.UserId = Session["username"].ToString();
                BetDatabase.Receipts.Add(receipt);
                var account = await BetDatabase.Accounts.SingleOrDefaultAsync(x => x.UserId == receipt.UserId);
                account.AmountE += receipt.Stake;
                account.DateE = DateTime.Now;
                BetDatabase.Accounts.AddOrUpdate(account);
                BetDatabase.SaveChanges();
            }
            else if (cost < 1000)
            {
            }
            return Json(new 
                { 
                    Result = result,
                    RecieptTime=DateTime.Now,
                    RecieptNumber=receipt.ReceiptId 
                },
                JsonRequestBehavior.AllowGet);
        }
        //
        // POST: /Recept/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var receipt = BetDatabase.Receipts.Find(id);
            BetDatabase.Receipts.Remove(receipt);
            BetDatabase.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            BetDatabase.Dispose();
            base.Dispose(disposing);
          }
    }
}