using Domain.Models.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WebUI.DataAccessLayer;

namespace WebUI.gbl
{
    public partial class UpdateScore : System.Web.UI.Page
    {
        private readonly string[] URL =
        {
  "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/africa",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/argentina",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/asia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/australia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/austria",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/belarus",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/belgium",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/brazil",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/bulgaria",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/chile",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/china",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/colombia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/concacaf",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/costarica",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/croatia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/cyprus",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/czechia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/denmark",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/egypt",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/england",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/equador",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/estonia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/eurocups",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/finland",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/france",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/germany",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/greece",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/holland",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/hungary",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/iceland",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/ireland",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/israel",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/italy",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/japan",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/korea",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/latvia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/lithuania",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/mexico",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/norway",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/paraguay",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/peru",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/poland",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/portugal",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/romania",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/russia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/saudi_arabia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/scotland",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/serbia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/singapore",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/slovakia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/slovenia",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/southafrica",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/southamerica",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/spain",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/sweden",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/switzerland",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/turkey",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/uae",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/ukraine",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/uruguay",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/usa",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/venezuela",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/wales",

"http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/worldcup"
           
        };

        private readonly AdminClass admin = new AdminClass();
        private readonly PhoneCustomer bets = new PhoneCustomer();

        private customers beta = new customers();
        private int count;
        private int countFail;
        private Login log = new Login();
        private string process;
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // setno.Text = admin.gensetno().ToString();
            }
            process = (Request.QueryString["process"]);
            if (process != null)
            {
                //score();
            }
        }

        private void respond(string response)
        {
            try
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Type", "text/plain");
                Response.Write(response);
                Response.Flush();
                Response.End();
            }
            catch (Exception e)
            {
            }
        }
        protected void Loadgames(object sender, EventArgs e)
        {
            score();

        }
        private static bool _alreadyRunningUpdate;

        public static bool AlreadyRunningUpdate
        {
            get
            {
                lock (RunLock)
                {
                    return _alreadyRunningUpdate;
                }
            }
            set
            {
                lock (RunLock)
                {
                    _alreadyRunningUpdate = value;
                }
            }
        }
        public static object RunLock = new object();
        public void score()
        {
            try
            {
                if (!AlreadyRunningUpdate)
                {
                    AlreadyRunningUpdate = true;
                    //        ThreadPool.QueueUserWorkItem((f) =>
                    //            {
                    DateTime start = DateTime.Now;
                    //for (int iURL = 0; iURL < URL.Length; iURL++)
                    for (int iURL = 0; iURL < 1; iURL++)
                    {
                        var req = (HttpWebRequest)WebRequest.Create(URL[iURL]);
                        var res = (HttpWebResponse)req.GetResponse();
                        Stream stream = res.GetResponseStream();
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.Load(stream);               
                        XmlNodeList categoryList = xmldoc.SelectNodes("/scores/category");
                        int loops = 0;
                        string goalServeMatchID = "";
                        foreach (XmlNode node in categoryList)
                        {
                            XmlNodeList matches = node.ChildNodes;
                            foreach (XmlNode matchesNode in matches)
                            {
                                loops += 1;

                                XmlNodeList games = matchesNode.ChildNodes;
                                foreach (XmlNode gameNode in games)
                                {
                                    string status = gameNode.Attributes["status"].InnerText.ToString();
                                    if (status == "FT")//update for only full time games
                                    {
                                        XmlNode home = gameNode.ChildNodes[0];
                                        XmlNode away = gameNode.ChildNodes[1];
                                        XmlNode halftime = gameNode.ChildNodes[3];
                                        string hostTeam = home.Attributes["name"].InnerText;
                                        string awayTeam = away.Attributes["name"].InnerText;
                                        goalServeMatchID = gameNode.Attributes["id"].InnerText;
                                        try
                                        {
                                            int homeGoals = Convert.ToInt16(home.Attributes["goals"].InnerText);
                                            int awayGoals = Convert.ToInt16(away.Attributes["goals"].InnerText);
                                            string half_time = halftime.Attributes["score"].InnerText; //format[3-2]
                                            char[] del2 = { '-' };
                                            string[] hf = half_time.Substring(1, half_time.Length - 2).Split(del2);
                                            int homeGoalsHT = Convert.ToInt16(hf[0]);
                                            int awayGoalsHT = Convert.ToInt16(hf[1]);
                                            bets.goalServeID = goalServeMatchID;
                                            if (bets.goalServeID == "1936363")
                                            {
                                                int matnos = Convert.ToInt32(bets.goalServeID);
                                            }
                                            bets.HomeScore = Convert.ToInt16(homeGoals);
                                            bets.AwayScore = Convert.ToInt16(awayGoals);
                                            bets.hthomescore = homeGoalsHT;
                                            bets.htawayscore = awayGoalsHT;
                                            int mtcno = Convert.ToInt32(goalServeMatchID);
                                            Match mtc = _db.Matches.Where(mt => mt.MatchNo == mtcno).SingleOrDefault();
                                            mtc.HomeScore = Convert.ToInt16(homeGoals);
                                            mtc.AwayScore = Convert.ToInt16(awayGoals);
                                            mtc.HalfTimeAwayScore= Convert.ToInt16(bets.htawayscore);
                                            mtc.HalfTimeHomeScore = Convert.ToInt16(bets.hthomescore);
                                            _db.SaveChanges();
                                            List<Result> resultList = new List<Result>();
                                            /* Match Results*/
                                            if (mtc.HomeScore > mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 1).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "FT1").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                                _db.SaveChanges();

                                            }
                                            else if (mtc.HomeScore < mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId==1).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "FTX").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                                _db.SaveChanges();
                                            }
                                            else if (mtc.HomeScore == mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId==1).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "FT2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            /*End Match Result */

                                            /* HaltTime Results*/
                                            if (mtc.HalfTimeHomeScore > mtc.HalfTimeAwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId ==3).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "HT1").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                                _db.SaveChanges();
                                            }
                                            else if (mtc.HalfTimeHomeScore < mtc.HalfTimeHomeScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 3).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "HT2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                                _db.SaveChanges();
                                            }

                                            else if (mtc.HalfTimeHomeScore == mtc.HalfTimeAwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId==3).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "HTX").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            /*End HalfTime Result */

                                            /*Start Draw No Bet*/
                                            if (mtc.HomeScore > mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId== 9).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "DNB1").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                                _db.SaveChanges();
                                            }
                                            else if (mtc.HomeScore < mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId== 9).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "DNB2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                                _db.SaveChanges();
                                            }
                                            else if (mtc.HomeScore == mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 9).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(h => h.BetCategoryId == result.CategoryId).Where(c => c.Option == "DNB2").FirstOrDefault().BetOptionId;

                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                                _db.SaveChanges();
                                            }
                                            /*End Match Result */

                                            /* Start Double Chance*/
                                            if (mtc.HomeScore > mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId== 9).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "12").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);

                                            }
                                            else if (mtc.HomeScore < mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId==4).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "12").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);

                                            }

                                            else if (mtc.HomeScore == mtc.AwayScore)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId== 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "12").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);

                                            }
                                            /*End Double Chance */

                                            /* Start Unders Over*/
                                            /* Full Time Total Goals or Wire or underover*/
                                            int FullTimeTotalGoals = (int)(mtc.HomeScore + mtc.AwayScore);
                                            if (FullTimeTotalGoals > 0.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "Over 2.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else if (FullTimeTotalGoals < 0.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }
                                            if (FullTimeTotalGoals > 1.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "Over 2.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else if (FullTimeTotalGoals < 1.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }
                                            if (FullTimeTotalGoals > 2.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "Over 2.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else if (FullTimeTotalGoals < 2.5)
                                            {
                                                Result result = new Result();
                                             result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId ==2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option== "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }
                                            if (FullTimeTotalGoals > 3.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "Over 2.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else if (FullTimeTotalGoals < 3.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }
                                            if (FullTimeTotalGoals > 4.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "Over 2.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else if (FullTimeTotalGoals < 4.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }
                                            /*End FullTime U/O/
                                             
                                             * 
                                             /*Start HalfTime Unders Over */
                                            /* 0.5  */
                                            int HalfTimeTotalGoals = (int)(mtc.HalfTimeHomeScore+ mtc.HalfTimeAwayScore);
                                            if (HalfTimeTotalGoals > 0.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 4).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "HTOver0.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else if (FullTimeTotalGoals < 0.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 2).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "x2").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }
                                            /* 0.5*/
                                            if (HalfTimeTotalGoals > 1.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 4).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "HTOver1.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else if (FullTimeTotalGoals < 1.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 4).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "HTUnder1.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }

                                            /*2.5 */
                                            if (HalfTimeTotalGoals > 1.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 4).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "HTOver2.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else if (FullTimeTotalGoals < 2.5)
                                            {
                                                Result result = new Result();
                                                result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 4).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "HTUnder2.5").FirstOrDefault().BetOptionId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }
                                            /* HT2.5*/


                                            /* End 2.5*/

                                            /*End Half Time Unders/Overs
                                            /* Both Teams To Score*/

                                            if ((homeGoals > 0) && (awayGoals > 0))
                                            {
                                                Result result = new Result();
                                             result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId ==7).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "Yes").Where(l => l.BetCategoryId== result.CategoryId).FirstOrDefault().BetCategoryId;
                                                _db.Results.Add(result);
                                                resultList.Add(result);
                                            }
                                            else
                                            {
                                                Result result = new Result();
                                             result.MatchId = mtc.MatchNo;
                                                result.CategoryId = _db.BetCategories.Where(c => c.CategoryId == 7).FirstOrDefault().CategoryId;
                                                result.OptionId = _db.BetOptions.Where(c => c.Option == "No").Where(l => l.BetCategoryId== result.CategoryId).FirstOrDefault().BetCategoryId;
                                                _db.Results.Add(result);
                                                _db.SaveChanges();
                                                resultList.Add(result);
                                            }
                                            /*End unders Both Teams To Score*/

                                            foreach (Result score in resultList)
                                            {
                                                List<Bet> betted = new List<Bet>();
                                                betted = _db.Bets.Where(s => s.MatchId == score.MatchId).Where(j => j.BetOption.BetCategoryId == score.CategoryId).ToList();
                                                foreach (Bet bm in betted)
                                                {
                                                    Receipt rec = _db.Receipts.Where(rc => rc.ReceiptId == bm.RecieptId).Where(rc => rc.ReceiptStatus == 1).SingleOrDefault();
                                                    rec.SubmitedSize = rec.SubmitedSize + 1;
                                                    //if (score.OptionId == 30)
                                                    //{
                                                    //    betted = _db.Bets.Where(s => s.MatchId == score.MatchId).Where(j => j.BetOption.BetCategoryId == score.CategoryId).ToList();
                                                    //    foreach (var bet in betted)
                                                    //    {
                                                    //           Receipt betReciept = _db.Receipts.Where(rc => rc.ReceiptId == bm.RecieptId).Where(rc => rc.ReceiptStatus == 1).SingleOrDefault();
                                                    //           Double Divider =Convert.ToDouble( betReciept.TotalOdds);
                                                    //          // betReciept.TotalOdds =Convert.ToDecimal(betReciept.TotalOdds/(Divider));
                                                            
                                                    //    }
                                                    //}
                                                    if ((bm.BetOptionId == score.OptionId) && (bm.BetOption.BetCategoryId == score.CategoryId))
                                                    {
                                                        rec.WonSize = rec.WonSize + 1;
      
                                                    }
                                                  
                                                    else
                                                    {
                                                        rec.ReceiptStatus = 2;
                                                    }
                                                  
                                                }
                                              
                                               
                                            }
                                            _db.SaveChanges();
                                            List<Receipt> WonReciepts = new List<Receipt>();
                                            WonReciepts = _db.Receipts.Where(w => w.SetSize == w.WonSize).Where(s=>s.ReceiptStatus==1).ToList();
                                            if (WonReciepts.Count > 0)
                                            {
                                                foreach (Receipt wonrec in WonReciepts)
                                                {
                                                    wonrec.ReceiptStatus = 3;

                                                }
                                                _db.SaveChanges();
                                            }


                                        }
                                        catch (Exception e)
                                        {
                                            string msg = e.Message;
                                            countFail++;
                                        }
                                    }

                                } //end game
                            } //end matches
                            //   LbResult.Text = loops.ToString();

                        } //end category, xml parse         

                        try
                        {
                            xmldoc.Load(new MemoryStream());
                        }
                        catch (Exception ex)
                        {


                        }
                        Thread.Sleep(5000);
                    }

                    var totalTime = (DateTime.Now - start);
                    //            });
                    respond("Success score updates: " + count + "<br />Pending/Failed: " + countFail);
                }
                else
                {
                    respond("<b><font color=\"Red\">Update is already running in the background</font></b>");
                }
            }
            catch (Exception exception) { }
            AlreadyRunningUpdate = false;
        }
    }
}