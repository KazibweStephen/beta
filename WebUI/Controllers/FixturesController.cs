using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ClosedXML.Excel;
using WebUI.DataAccessLayer;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace WebUI.Controllers
{
    public class FixturesController : Controller
    {
        ApplicationDbContext db=new ApplicationDbContext();
        // GET: Fixtures
        public ActionResult GenerateFixtures()
        {
            var fullTime = "FULL-TIME";
            var halfTime = "HALF-TIME";
            var doubleChance = "DOUBLE CHANCE";
            var vdrawNoBet = "DRAW NO BET";
            var bothTeams = "BOTH TEAMS";
            var handCap = "HANDCAP";
            var oneExTwo = "1X2";
            var twoPointFive = "2.5";

            var headings0 = new[]
            {
                new {NO="No",TIME="Time",LEAGUE="League",HOME="Home",AWAY="Away"},
            };
         var headings1=new []
            {
                new
                {
                    oneExTwo="1X2"
                    ,twoPointFive="2.5"
                    ,onePointfive="1.5", 
                    oneExTwo2="1X2",
                    onePointfive2="1.5",
                    zeroPointFive="0.5",
                    doubleChance = "DOUBLE CHANCE",
                    vdrawNoBet = "DRAW NO BET",
                    bothTeams = "BOTH TEAMS",
                    handCap = "HANDCAP"
                },
            };



          

            var workBook=new XLWorkbook();
            var workSheet = workBook.Worksheets.Add("BetWayFixture1");
            //Merges
            workSheet.Range("A1:E3").Merge(); 
            workSheet.Range("A4:E4").Merge();
            workSheet.Range("F1:AA1").Merge();
            workSheet.Range("F2:AA2").Merge().Value = "Contact: 0200 - 692 - 014                                      Email: customercare@betway.ug";
            workSheet.Range("F4:L4").Merge();
            workSheet.Range("M4:S4").Merge();
            workSheet.Range("T5:V5").Merge();
            workSheet.Range("W5:X5").Merge();
            //Merge A5 to D5 for geadings
            workSheet.Range("A5:A6").Merge();
            workSheet.Range("B5:B6").Merge();
            workSheet.Range("C5:C6").Merge();
            workSheet.Range("D5:D6").Merge();
            workSheet.Range("E5:E6").Merge();



            //OPTIONS
            workSheet.Cell("F6").Value = "1";
            workSheet.Cell("G6").Value = "X";
            workSheet.Cell("H6").Value = "2";

            workSheet.Cell("I6").Value = "Under";
            workSheet.Cell("J6").Value = "Over";

            workSheet.Cell("K6").Value = "Under";
            workSheet.Cell("L6").Value = "Over";


            workSheet.Cell("M6").Value = "1";
            workSheet.Cell("N6").Value = "X";
            workSheet.Cell("O6").Value = "2";

            workSheet.Cell("P6").Value = "Under";
            workSheet.Cell("Q6").Value = "Over";

            workSheet.Cell("R6").Value = "Under";
            workSheet.Cell("S6").Value = "Over";

            workSheet.Cell("T6").Value = "1X";
            workSheet.Cell("U6").Value = "12";
            workSheet.Cell("V6").Value = "X2";
   

            workSheet.Cell("W6").Value = "HOME";
            workSheet.Cell("X6").Value = "AWAY";

            workSheet.Cell("Y6").Value = "Yes";
            workSheet.Cell("Z6").Value = "No";

            workSheet.Cell("AA6").Value = "Arg";
           

            workSheet.Cell("AB6").Value = "1";
            workSheet.Cell("AC6").Value = "X";
            workSheet.Cell("AD6").Value = "2";


            workSheet.Range("B5:B6").Merge();
            workSheet.Range("C5:C6").Merge();
            workSheet.Range("D5:D6").Merge();
            workSheet.Range("E5:E6").Merge();
           

            //FONTS AND DECORATIONS
            workSheet.Range("A5:E6").Style
                .Font.SetBold(true)
                .Font.SetFontName("Bookman Old Style")
                .Font.SetFontSize(12)
                .Border.SetOutsideBorder(XLBorderStyleValues.Thick)
                .Border.SetInsideBorder(XLBorderStyleValues.Thick);
                
              
            workSheet.Columns(1, 22).AdjustToContents();
            workSheet.Range("F4:AD4").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            workSheet.Range("F4:AD4").Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            workSheet.Range("F5:AD6").Style.Border.InsideBorder = XLBorderStyleValues.Thick;
            workSheet.Range("F5:AD5").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            workSheet.Range("F5:AD5").Style.Border.OutsideBorder=XLBorderStyleValues.Thick;
            workSheet.Cell("A5").Value = headings0;
            workSheet.Range("F5:H5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("F5").Value = "1x2";
            workSheet.Range("I5:J5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("I5").Value = "2.5";
           // workSheet.Range("I5:J5").Merge().Value = "2.5";
            workSheet.Range("K5:L5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("K5").Value = "1.5";
            workSheet.Range("M5:O5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("M5").Value = "1x2";
            workSheet.Range("P5:Q5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("P5").Value = "1.5";
            workSheet.Range("R5:S5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("R5").Value = "0.5";
            workSheet.Range("T5:V5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("T5").Value = "Double Chance";
            workSheet.Range("W5:X5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("W5").Value = "Draw No Bet";
            workSheet.Range("Y5:Z5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("Y5").Value = "Both Team";
            workSheet.Range("AA5:AD5").Merge().Style.Font.SetBold(true);
            workSheet.Cell("AA5").Value = "Handcap";

            workSheet.Range("A1:E3").Merge().Value = "BETWAY FIXTURE";
            workSheet.Range("A1:E3").Style
                .Font.SetFontSize(24)
                .Font.SetFontColor(XLColor.BrickRed)
                .Font.SetBold(true)
                .Font.SetFontName("Bookman Old Style");

            workSheet.Range("F1:Z1").Merge().Value = DateTime.Now.ToString();
            workSheet.Range("A1:E3").Style
                .Font.SetFontSize(20)
                .Font.SetFontColor(XLColor.BrickRed)
                .Font.SetBold(true)
                .Font.SetFontName("Bookman Old Style");

           
            workSheet.Range("F6:O6").Style
               .Font.SetFontName("Bookman Old Style")
               //.Font.SetFontSize(12)
               .Font.SetBold(false);
            workSheet.Cell("F4").Value = "FULL TIME";
           // workSheet.Range("F4:L4").Merge();

            workSheet.Cell("M4").Value = "HALF TIME";
           // workSheet.Range("M4:S4").Merge();

            workSheet.Range("F7:O7").Style
                .Font.SetFontName("Bookman Old Style")
                //.Font.SetFontSize(5)
                .Font.SetBold(false);
            workSheet.Cell("F7").Value = headings1;
           // workSheet.Cell("A7").Style.NumberFormat.SetFormat(IXLNumberFormat);
            List<FixtureViewModel> games = GetGames();
           
            workSheet.Range("AA5:AD5").Merge();
            //ADJUST COLUMN WIDTH
            workSheet.Columns("D:E").Width = 18.86;
           // workSheet.Columns("A:E").Style.Border.InsideBorder = XLBorderStyleValues.Medium;
            var ws = workSheet.Columns("F:AD");
           
            ws.Width = 6.14;
            ws.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
           // ws.Style.Border.InsideBorder=XLBorderStyleValues.Medium;
           // workSheet.RowsUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            int numberOfGames = games.Count()+6;
            string oddsLastCell = "F7:" + "AD" + numberOfGames.ToString();
            string teamsLastCell = "A7:" + "E" + numberOfGames.ToString();
            workSheet.Range(oddsLastCell).Style.NumberFormat.SetNumberFormatId(3);
            workSheet.Range(oddsLastCell).Style.Border.InsideBorder = XLBorderStyleValues.Hair;
            workSheet.Range(teamsLastCell).Style.Border.InsideBorder = XLBorderStyleValues.Hair;
            string fthtlastCell = "F7:" + "S" + numberOfGames.ToString();
            workSheet.Range(fthtlastCell).Style.Border.BottomBorder= XLBorderStyleValues.Thin;
            string ft1x2lastCell = "F7:" + "H" + numberOfGames.ToString();
            workSheet.Range(ft1x2lastCell).Style.Border.OutsideBorder= XLBorderStyleValues.Thin;
            string ftUO25lastCell = "I7:" + "J" + numberOfGames.ToString();
            workSheet.Range(ftUO25lastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string ftUO15lastCell = "K7:" + "L" + numberOfGames.ToString();
            workSheet.Range(ftUO15lastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string ht1x2lastCell = "M7:" + "O" + numberOfGames.ToString();
            workSheet.Range(ht1x2lastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string htUO15lastCell = "P7:" + "Q" + numberOfGames.ToString();
            workSheet.Range(htUO15lastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string htUO05lastCell = "R7:" + "S" + numberOfGames.ToString();
            workSheet.Range(htUO05lastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string doubleChanceLastCell = "T7:" + "V" + numberOfGames.ToString();
            workSheet.Range(doubleChanceLastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string drawNoBetLastCell = "W7:" + "X" + numberOfGames.ToString();
            workSheet.Range(drawNoBetLastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string bothTeamLastCell = "Y7:" + "Z" + numberOfGames.ToString();
            workSheet.Range(bothTeamLastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string handCupLastCell = "AA7:" + "AD" + numberOfGames.ToString();
            workSheet.Range(handCupLastCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            string fixtureCell = "A1:" + "AD" + numberOfGames.ToString();
            workSheet.Range(fixtureCell).Style.Border.OutsideBorder = XLBorderStyleValues.Thick;
            workSheet.Range("F6:AD6").Style.Border.BottomBorder = XLBorderStyleValues.Thick;
            workSheet.Range("F4:L4").Style.Border.RightBorder = XLBorderStyleValues.Thick;
            workSheet.Range("M4:S4").Style.Border.RightBorder = XLBorderStyleValues.Thick;
          
           // workSheet.Range("T4:V4").Style.Border.RightBorder = XLBorderStyleValues.Thick;


            workSheet.Cell("A7").Value = games;;
            return new ExcelResult(workBook, "BetWayFixture"+DateTime.Now.Date.ToString());
    }

        public string convetDateToTime(DateTime date )
        {
            var _date = date.TimeOfDay;
            return _date.ToString();
        }
        public List<FixtureViewModel> GetGames()
        {
           
            var games =  db.Matches.Include(g => g.AwayTeam).Include(g => g.AwayTeam.League).Include(g => g.HomeTeam).Include(g => g.GameOdds.Select(c => c.BetOption)).ToList();

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
                                 "[dbo].[GetHandicapGoals] (M.MatchNo) as Goals," +
                                 "[dbo].[Getodd]('Handicap','HC2',M.MatchNo) as Handicap2," +
                                 "[dbo].[Getodd]('Draw No Bet','DNB1',M.MatchNo) as DNB1," +
                                 "[dbo].[Getodd]('Draw No Bet','DNB2',M.MatchNo) as DNB2 from Matches M inner join dbo.ShortMatchCodes sm on sm.MatchNo=m.MatchNo "
                                 + " where(StartTime>getdate()) and m.MatchNo in (select GameId from MatchOdds) order by sm.shortcode asc ";
            var dt = new DataTable();
            con.Open();
            var da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            con.Close();
            int _rowNo=0;
            var model = new List<FixtureViewModel>();
            for (var i = 0; i < dt.Rows.Count; i++)
            {
               
                model.Add(
                    new FixtureViewModel
                    {
                        ShortCode = (int)(dt.Rows[i]["ShortCode"] ?? "-"),//_no++ ,// Convert.ToInt32(dt.Rows[i]["MatchNo"]),
                        League = (dt.Rows[i]["League"] ?? "-").ToString(),
                        Time =Convert.ToDateTime(dt.Rows[i]["starttime"]).TimeOfDay.ToString(),
                        Home = (dt.Rows[i]["HomeTeam"] ?? "-").ToString(),
                        Away = (dt.Rows[i]["AwayTeam"] ?? "-").ToString(),
                        //FULL TIME
                        FT1X = (dt.Rows[i]["FT1"] ?? "-").ToString(),
                        FTX = (dt.Rows[i]["FTX"] ?? "-").ToString(),
                        FTX2 = (dt.Rows[i]["FT2"] ?? "-").ToString(),
                        //FULLTIME OVER UNDER 2.5
                        FTU25 =( dt.Rows[i]["FTUnder2.5"] ?? "-").ToString(),
                        FTO25 = (dt.Rows[i]["FTOver2.5"] ?? "-").ToString(),
                        //FULLTIME OVER UNDER 1.5
                        FTU15 = (dt.Rows[i]["FTUnder1.5"] ?? "-").ToString(),
                        FTO15 = (dt.Rows[i]["FTOver1.5"] ?? "-").ToString(),


                        //HALF TIME
                        HT1X = (dt.Rows[i]["HT1"] ?? "-").ToString(),
                        HTX = (dt.Rows[i]["HTX"] ?? "-").ToString(),
                        HTX2 = (dt.Rows[i]["HT2"] ?? "-").ToString(),
                        //HALFTIME OVER UNDER 0.5
                        HTU05 = (dt.Rows[i]["HTOver0.5"] ?? "-").ToString(),
                        HTO05 = (dt.Rows[i]["HTUnder0.5"] ?? "-").ToString(),
                       
                        //HALFTIME OVER UNDER 1.5
                        HTU15 = (dt.Rows[i]["HTUnder1.5"] ?? "-").ToString(),
                        HTO15 = (dt.Rows[i]["HTOver1.5"] ?? "-").ToString(),
                    

                        //DOUBLE CHANCE
                        DCX1 = (dt.Rows[i]["1X"] ?? "-").ToString(),
                        DCX = (dt.Rows[i]["12"] ?? "-").ToString(),
                        DCX2 = (dt.Rows[i]["X2"] ?? "-").ToString(),
                       
                        //DRAW NO BET
                        //DNBAway = (dt.Rows[i]["DNB2"] ?? "-").ToString(),
                        //DNBHome = (dt.Rows[i]["DNB1"] ?? "-").ToString(),
                        //BOTH TEAMS TO SCORE
                        BTYes = (dt.Rows[i]["BTYes"] ?? "-").ToString(),
                        BTNo = (dt.Rows[i]["BTNo"] ?? "-").ToString(),
                        //HANDCAP
                        HDC1X = (dt.Rows[i]["Handicap1"] ?? "-").ToString(),
                        HDCX = (dt.Rows[i]["HandicapX"] ?? "-").ToString(),
                        HDCX2 = (dt.Rows[i]["Handicap2"] ?? "-").ToString(),
                        HDCGoals = (dt.Rows[i]["Goals"] ?? "-").ToString(),
                       
                      

                    });
            }
            var gv = new GridView { DataSource = dt };
            gv.DataBind();
            //Session["Doc"] = gv; 

            return model;
            //MatchNo = g.MatchNo.ToString(),

            //var _no = 1;
            //var filteredgames = games.Select(g => new FixtureViewModel
            //{
            //    No = _no++,
            //    Time=g.StartTime.TimeOfDay.ToString(),
            //    League ="",
            //    Home = g.HomeTeam.TeamName,
            //    Away = g.AwayTeam.TeamName,
            //    FT1X =  2.05  ,
            //    FX =2.05,
            //    FTX2 =   2.05                       ,
            //    HT1X =   2.05                       ,
            //    HX =      2.05                    ,
            //    HTX2 =      2.05                    ,
            //     DC1X =      2.05                    ,
            //    DCX =       2.05                   ,
            //    DCX2 =      2.05                    ,
            //    DNBAway =   2.05                       ,
            //    DNBHome =   2.05                       ,
            //    BTYes =      2.05                    ,
            //    BTNo =           2.05               ,
            //     HDCArgs =           2.05               ,
            //    HDCOne =  2.05         ,
            //    HDCX =   2.05   ,
            //    HDC2 =                          2.05,



            //});

            //return filteredgames.ToList();
        }

        public void GenearateExcelFixture(string value, string cellRange, int fontSize, string fontColor, string fontStyle, List<string> headings)
        {
            
            throw new NotImplementedException();


        }

        // GET: Fixtures/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fixtures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fixtures/Create
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

        // GET: Fixtures/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fixtures/Edit/5
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

        // GET: Fixtures/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fixtures/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
