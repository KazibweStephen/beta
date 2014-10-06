using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Math;
using Domain.Models.Concrete;
using Domain.Models.ViewModels;
using Microsoft.AspNet.SignalR.Messaging;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    
    public class MatchController : CustomController
    {
        // GET: Match
        public async Task<ActionResult> Index()
        {

            if (!Request.IsAjaxRequest())
            {
                var account = await BetDatabase.Accounts.Select(a => new
                {
                    a.UserId,
                    a.AmountE
                }).SingleOrDefaultAsync(t => t.UserId == User.Identity.Name);
                ViewBag.Balance = account.AmountE;
                return View();
            }
        
            var currentSetNo = SetNumberGenerator.GetCurrentSetNumber;
            var games = await BetDatabase.ShortMatchCodes.Include(s => s.Match).OrderBy(x=>x.ShortCode).ToListAsync();
            var startTime = DateTime.Now;
            
            var filteredgames = games.Select(g => new GameViewModel
            {
                AwayScore = g.Match.AwayScore,
                AwayTeamId = g.Match.AwayTeamId,
                AwayTeamName = g.Match.AwayTeam.TeamName,
                Champ = g.Match.Champ,
                GameOdds = g.Match.GameOdds.Select(go => new GameOddViewModel
                {
                    BetCategory = go.BetOption.BetCategory.Name,
                    BetOptionId = go.BetOptionId,
                    BetOption = go.BetOption.Option,
                    LastUpdateTime = go.LastUpdateTime,
                    Odd = go.Odd,
                    HandicapGoals = go.HandicapGoals
                }).ToList(),
                GameStatus = g.Match.GameStatus,
                HalfTimeAwayScore = g.Match.HalfTimeAwayScore,
                HalfTimeHomeScore = g.Match.HalfTimeHomeScore,
                HomeScore = g.Match.HomeScore,
                HomeTeamName = g.Match.HomeTeam.TeamName,
                HomeTeamId = g.Match.HomeTeamId,
                MatchNo = g.ShortCode,
                RegistrationDate = g.Match.RegistrationDate,
                ResultStatus = g.Match.ResultStatus,
                SetNo = g.SetNo,
                OldDateTime = g.Match.StartTime,
                StartTime = String.Format("{0:dd/M/yyyy}", g.Match.StartTime)
            }).Where(x => x.OldDateTime>startTime).OrderBy(s => s.StartTime); 
            return Json(filteredgames, JsonRequestBehavior.AllowGet);
         }


        public ViewResult Fixtures()
        {
             var constring = ConfigurationManager.ConnectionStrings["BetConnection"].ConnectionString;
         var con = new SqlConnection(constring);
         const string query = "select M.MatchNo as MatchNo,sm.shortcode as ShortCode,[dbo].[ReturnTeamName](HomeTeamId) as HomeTeam,M.Champ as League, " +
                                   "[dbo].[ReturnTeamName](AwayTeamId) as AwayTeam," +
                                   "convert(varchar(10),(DATEPART(HH,M.starttime)))+':'+Convert(varchar(10),DATEPART(mi,M.starttime)) as starttime ," +
                                   "[dbo].[Getodd]('FT 1x2','FT1',M.MatchNo) as FT1," +
                                   "[dbo].[Getodd]('FT 1x2','FTX',M.MatchNo) as FTX," +
                                   "[dbo].[Getodd]('FT 1x2','FT2',M.MatchNo) as FT2," +
                                   "[dbo].[Getodd]('Double Chance','1X',M.MatchNo) as [1X]," +
                                   "[dbo].[Getodd]('Double Chance','12',M.MatchNo) as [12]," +
                                   "[dbo].[Getodd]('Double Chance','X2',M.MatchNo) as [X2]," +
                                   "[dbo].[Getodd]('FT U/O','FTOver2.5',M.MatchNo) as [FTOver2.5]," +
                                   "[dbo].[Getodd]('FT U/O','FTUnder2.5',M.MatchNo) as [FTUnder2.5]," +
                                   "[dbo].[Getodd]('FT U/O','FTOver1.5',M.MatchNo) as [FTOver1.5]," +
                                   "[dbo].[Getodd]('FT U/O','FTUnder1.5',M.MatchNo) as [FTUnder1.5]," +
                                   "[dbo].[Getodd]('HT 1x2','HT1',M.MatchNo) as HT1," +
                                   "[dbo].[Getodd]('HT 1x2','HTX',M.MatchNo) as HTX," +
                                   "[dbo].[Getodd]('HT 1x2','HT2',M.MatchNo) as HT2," +
                                   "[dbo].[Getodd]('HT U/O','HTOver0.5',M.MatchNo) as [HTOver0.5]," +
                                   "[dbo].[Getodd]('HT U/O','HTUnder0.5',M.MatchNo) as [HTUnder0.5]," +
                                   "[dbo].[Getodd]('HT U/O','HTOver1.5',M.MatchNo) as [HTOver1.5]," +
                                   "[dbo].[Getodd]('HT U/O','HTUnder1.5',M.MatchNo) as [HTUnder1.5]," +
                                    "[dbo].[Getodd]('HT U/O','HTOver2.5',M.MatchNo) as [HTOver2.5]," +
                                   "[dbo].[Getodd]('HT U/O','HTUnder2.5',M.MatchNo) as [HTUnder2.5]," +
                                   "[dbo].[Getodd]('Both Teams To Score','GG',M.MatchNo) as BTYes," +
                                   "[dbo].[Getodd]('Both Teams To Score','NG',M.MatchNo) as BTNo," +
                                   "[dbo].[Getodd]('Handicap','HC1',M.MatchNo) as Handicap1," +
                                   "[dbo].[Getodd]('Handicap','HCX',M.MatchNo) as HandicapX," +
                                     "[dbo].[Getodd]('Handicap','HC2',M.MatchNo) as Handicap2," +
                                     "[dbo].[GetHandicapGoals] (M.MatchNo) as Goals," +                                
                                   "[dbo].[Getodd]('Draw No Bet','DNB1',M.MatchNo) as DNB1," +
                                   "[dbo].[Getodd]('Draw No Bet','DNB2',M.MatchNo) as DNB2 from Matches M inner join dbo.ShortMatchCodes sm on sm.MatchNo=m.MatchNo "
                                   + "where starttime>getdate()  order by sm.shortcode asc";
                 var dt = new DataTable();
                 con.Open();
                  var da = new SqlDataAdapter(query, con);
                  da.Fill(dt);
                  con.Close();
            var model = new List<FixtureVm>();
            for (var i = 0; i <dt.Rows.Count; i++)
                    {
            model.Add(
                new FixtureVm
                {
                    MatchNo = Convert.ToInt32(dt.Rows[i]["MatchNo"]),
                    HomeTeam = dt.Rows[i]["HomeTeam"].ToString(),
                    AwayTeam = dt.Rows[i]["AwayTeam"].ToString(),
                
                });
            }
            var gv = new GridView {DataSource = dt};
            gv.DataBind();
            Session["Doc"] = gv; 

            return View(model);
        }
     
        
        public ActionResult Download()
        {
            if (Session["Doc"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["Doc"], "Doc.xls");
            }
            return new JavaScriptResult();
        }

        public ActionResult BetCategories()
        {
            var betcategories = BetDatabase.BetCategories.Take(100).Include(m => m.BetOptions);
            return View(betcategories.ToList());
        }
        // GET: Match/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var match = await BetDatabase.Matches.FindAsync(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }
        public ActionResult AddOdds(int ?id=0)
        {
            ViewBag.MatId = id;
            return View();
        }
        // GET: Match/Create
        public ActionResult Create()
        {
            ViewBag.HomeTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName");
            ViewBag.AwayTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: Match/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MatchNo,setno,champ,HomeTeamId,AwayTeamId,stime,status,date_reg,HomeScore,AwayScore,Hthomescore,HtAwayScore,resultstatus")] Match match)
        {
            if (!ModelState.IsValid) return View(match);
            BetDatabase.Matches.Add(match);
            await BetDatabase.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Match/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var match = await BetDatabase.Matches.FindAsync(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            ViewBag.HomeTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", match.HomeTeamId);
            ViewBag.AwayTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", match.AwayTeamId);
            return View(match);
        }

        // POST: Match/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MatchNo,setno,champ,HomeTeamId,AwayTeamId,stime,status,date_reg,HomeScore,AwayScore,Hthomescore,HtAwayScore,resultstatus")] Match match)
        {
            if (ModelState.IsValid)
            {
                BetDatabase.Entry(match).State = EntityState.Modified;
                await BetDatabase.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.HomeTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", match.HomeTeamId);
            ViewBag.AwayTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", match.AwayTeamId);
            return View(match);
        }

        // GET: Match/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var match = await BetDatabase.Matches.FindAsync(id);
            if (match == null)
            {
                return HttpNotFound();
            }
            return View(match);
        }

        // POST: Match/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var match = await BetDatabase.Matches.FindAsync(id);
            BetDatabase.Matches.Remove(match);
            await BetDatabase.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public  async Task<JsonResult> ReceiveReceipt(Receipt1 receipts)
        {  
            var bcg = new BarCodeGenerator();
            var account = await BetDatabase.Accounts.SingleOrDefaultAsync(x => x.UserId == User.Identity.Name);
            var branchId = Convert.ToInt32(account.AdminE);
            var branch = await BetDatabase.Branches.SingleOrDefaultAsync(x => x.BranchId == branchId);
            var receiptid = bcg.GenerateRandomString(16);
            var receipt = new Receipt
            {
                UserId = User.Identity.Name,
                BranchId =Convert.ToInt16(account.AdminE),
                ReceiptStatus = 0,
                SetNo = 2014927,
               // ReceiptId = Convert.ToInt32(receiptid)
            }; //Start New Reciept

            var betStake = receipts.TotalStake.ToString(CultureInfo.InvariantCulture);
            string response;        
            BetDatabase.Receipts.Add(receipt);
            await BetDatabase.SaveChangesAsync();

            var ttodd = receipts.TotalOdd;
            const float bettingLimit = 8000000;
            var cost = Convert.ToDouble(betStake);
            if ((cost >= 1000) && (cost <= bettingLimit))//betting limit
            {

            foreach(var betData in receipts.BetData)
                {            
                    try
                    {
                        var tempMatchId = Convert.ToInt32(betData.MatchId);
                        var _matchid = BetDatabase.ShortMatchCodes.Single(x => x.ShortCode == tempMatchId).MatchNo;
                        Match _match = BetDatabase.Matches.Single(h => h.MatchNo == _matchid);
                        DateTime  _matchTime = _match.StartTime;
                        DateTime timenow = DateTime.Now;
                        if (_matchTime < timenow)
                        {
                            response = ("The Match " + tempMatchId + " Has Started");
                            return new JsonResult { Data = new { message = response } };
                        }
                        var bm = new Bet
                        {
                            BetOptionId = Int32.Parse(betData.OptionId),
                            RecieptId = receipt.ReceiptId,
                            MatchId = BetDatabase.ShortMatchCodes.Single(x => x.ShortCode == tempMatchId).MatchNo,  
                            BetOdd = Convert.ToDecimal(betData.Odd),
                        };
                        BetDatabase.Bets.Add(bm);
                        BetDatabase.SaveChanges();
                    }
                    catch (Exception er)
                    {
                        response = (" An error  has occured:"+er.Message);
                        return new JsonResult { Data = new { message = response } };
                        var msg = er.Message;
                    }
                }
                // Requires Quick Attention
              
                receipt.TotalOdds= Convert.ToDouble(ttodd);
                receipt.ReceiptStatus = 1;
                receipt.SetSize = receipts.ReceiptSize;
                receipt.Stake = cost;
                receipt.WonSize = 0;
                receipt.SubmitedSize = 0;
                receipt.ReceiptDate = DateTime.Now;
                receipt.Serial = Int2Guid(receiptid);    
                account.DateE  = DateTime.Now;
                // receipt.RecieptID = 34;                    
                BetDatabase.Entry(receipt).State = EntityState.Modified;
                var statement = new Statement
                {
                    Account = receipt.UserId,
                    Amount = receipt.Stake,
                    Controller = receipt.UserId,
                    StatetmentDate = DateTime.Now,
                    BalBefore = account.AmountE,
                    BalAfter = account.AmountE + receipt.Stake,
                    Comment ="Bet Transaction for Ticket No"+receiptid
                };
                account.AmountE = account.AmountE + receipt.Stake;
                statement.Transcation = "Teller Bet";
                statement.Method = "Online";
                statement.Serial = receiptid;
            
                branch.Balance = branch.Balance +Convert.ToDecimal( receipt.Stake);
                BetDatabase.Entry(branch).State = EntityState.Modified;
                BetDatabase.Accounts.AddOrUpdate(account);
                BetDatabase.Statements.Add(statement);
                BetDatabase.SaveChanges();
                var barcodeImage = bcg.CreateBarCode(receiptid);
                var tempPath = Server.MapPath("~/Content/BarCodes/" + receiptid.Trim() + ".png");
                try
                {
                    barcodeImage.Save(tempPath, ImageFormat.Png);
                }
                catch (Exception)
                {
                }
                response = ("Success");
            }
            else if (cost < 1000)
            {
                receipt.ReceiptId = 0;
                response = ("Minimum betting stake is UGX 1000. Please enter amount more than UGX 1000.");
            }
            else
            {
                receipt.ReceiptId = 0;
                response = ("Maximum stake is UGX " + bettingLimit + ". Please enter amount less than UGX " + bettingLimit + ".");
            }

            return new JsonResult { Data = new { message = response, ReceiptNumber = receipt.ReceiptId, ReceiptTime = String.Format("{0:dd/MM/yyyy}", DateTime.Now) + " - " + toJavaScriptDate(DateTime.Now), TellerName = account.UserId, BranchName = branch.BranchName, Balance = account.AmountE, Serial = receiptid, FormatedSerial = GetSerialNumber(receiptid) } };
        }

  
          public  string toJavaScriptDate(DateTime value)
          {
              var time = value.ToLongTimeString();
             var ReceiptTime = (value.ToString("HH:mm"));
             return ReceiptTime;
          }

        public string BarcodeFormart(string barcode)
        {
            string[] arr=null;
            string code = "";
            for (int i = 0; i < 12; i++)
            {
                if (i%3 == 0)
                {
                    arr[i] = barcode.Substring(i + 4);
                }
            }
            for (int x = 0; x < arr.Length; x++)
            {
                code += "-";

            }
            return code;
        }



        public static Guid Int2Guid(string  serial)
        {
            long value = Convert.ToInt64(serial);
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

          public string GetSerialNumber(  string serialGuid)
          {

              var serialArray = serialGuid.ToCharArray();
              var finalSerialNumber = "";
              var j = 0;
              for (var i = 0; i < 16; i++)
              {
                  for (j = i; j < 4 + i; j++)
                  {
                      finalSerialNumber += serialArray[j];
                  }
                  if (j == 16)
                  {
                      break;
                  }
                  else
                  {
                      i = (j) - 1;
                      finalSerialNumber += "-";
                  }
              }

              return finalSerialNumber;
          }
          public Guid GetSerialGuid()
          {
              var serialGuid = Guid.NewGuid();
              return serialGuid;
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
    public class Receipt1
    {
        private List<BetData> _betData;
        public int ReceiptSize { get; set; }
        public double TotalOdd { get; set; }
        public int TotalStake { get; set; }
        public List<BetData> BetData
        {
            get { return _betData ?? (new List<BetData>()); }
            set { _betData = value; }
        }
        public long MultipleBetAmount { get; set; }


    }
    public class BetData
    {
        public string MatchId { get; set; }
        public string BetCategory { get; set; }
        public string OptionId { get; set; }
        public double Odd { get; set; }
        public long BetAmount { get; set; }
    }
}
 