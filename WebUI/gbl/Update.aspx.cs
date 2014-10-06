using System;
using System.Globalization;
using WebUI.DataAccessLayer;

namespace WebUI.gbl
{
    public partial class Update : System.Web.UI.Page
    {
        private readonly string[] _url =
        {
           "http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/england_shedule?odds=bet365"
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/africa_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/argentina_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/asia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/australia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/austria_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/belarus_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/belgium_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/brazil_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/bulgaria_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/chile_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/china_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/colombia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/concacaf_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/costarica_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/croatia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/cyprus_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/czechia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/denmark_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/egypt_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/england_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/equador_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/estonia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/eurocups_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/finland_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/france_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/germany_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/greece_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/holland_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/hungary_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/iceland_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/ireland_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/israel_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/italy_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/japan_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/korea_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/latvia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/lithuania_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/mexico_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/norway_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/paraguay_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/peru_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/poland_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/portugal_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/romania_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/russia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/saudi_arabia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/scotland_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/serbia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/singapore_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/slovakia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/slovenia_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/southafrica_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/southamerica_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/spain_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/sweden_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/switzerland_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/turkey_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/uae_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/ukraine_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/uruguay_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/usa_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/venezuela_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/wales_shedule?odds=bet365",
            //"http://www.goalserve.com/getfeed/25e832444f8f42b7b494b55d9c3ed305/soccernew/worldcup_shedule?odds=bet365"
        };
            private readonly ApplicationDbContext _db = new ApplicationDbContext();
            private readonly AdminClass _admin = new AdminClass();
            private int _count;
            private int _countFail;
            private int _leaguesAdded;
            private string _process;

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    setno.Text = _admin.gensetno().ToString(CultureInfo.InvariantCulture);
                }
                _process = (Request.QueryString["process"]);
               
                    
                    if (_process != null)
                    {
                        //AutoUpdate();
                    }
                
            }

            private void Respond(string response)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.AddHeader("Content-Type", "text/plain");
                Response.Write(response);
                Response.Flush();
                Response.End();
            }

        public static bool AlreadyRunningUpdate
            {
                get
                {
                    lock (RunLock)
                    {
                        return false;
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


        //    protected void AutoUpdate()
        //    {

        //        if (!AlreadyRunningUpdate)
        //        {
        //            AlreadyRunningUpdate = true;

        //            //        ThreadPool.QueueUserWorkItem((f) =>
        //            //            {
        //            var start = DateTime.Now;

        //            foreach (var t in _url)
        //            {
        //                var req = (HttpWebRequest)WebRequest.Create(t);
        //                var res = (HttpWebResponse)req.GetResponse();
        //                var stream = res.GetResponseStream();
        //                var xmldoc = new XmlDocument();
        //                {

        //                    xmldoc.Load(stream);
        //                    var categoryList = xmldoc.SelectNodes("/scores/category");

        //                    foreach (XmlNode node in categoryList)
        //                    {
        //                        var matches = node.ChildNodes;
        //                        foreach (XmlNode matchesNode in matches)
        //                        {
        //                            var games = matchesNode.ChildNodes;
        //                            foreach (XmlNode gameNode in games)
        //                            {
        //                                var home = gameNode.ChildNodes[0];
        //                                var away = gameNode.ChildNodes[1];
        //                                var odd = gameNode.ChildNodes[4];
        //                                var gameOdds = odd.ChildNodes;
        //                                var avail = "";
        //                                try
        //                                {
        //                                    avail = odd.Attributes["notfound"].Value;
        //                                }
        //                                catch (NullReferenceException)
        //                                {
        //                                    avail = "true";
        //                                }
        //                                if (avail.Equals("true"))
        //                                {
        //                                    //match has no odd details
        //                                    continue;
        //                                }

        //                                var league = node.Attributes["name"].InnerText;
        //                                var country = node.Attributes["file_group"].InnerText;
        //                                string hostTeam = null, awayTeam = null;
        //                                var lg = new League();
        //                                lg.Country = country;
        //                                lg.LeagueName = league;
        //                                _db.Leagues.Add(lg);
                                        
        //                                var teams = new Team();
        //                                var team = new MatchFeed();
        //                                if (home.Name == "localteam")
        //                                {
        //                                    hostTeam = home.Attributes["name"].InnerText;
                                        
        //                                    teams.TeamName = hostTeam;
        //                                    team.Team.Add(teams);
        //                                    _db.Teams.Add(teams);
        //                                }
        //                                if (away.Name == "visitorteam")
        //                                {
        //                                    awayTeam = away.Attributes["name"].InnerText;
        //                                    teams.TeamName = awayTeam;
        //                                    team.Team.Add(teams);
        //                                    _db.Teams.Add(teams);

        //                                }

        //                                char[] del = { '.' };
        //                                var stdate = gameNode.Attributes["formatted_date"].InnerText.Split(del);
        //                                var stDateTime = stdate[1] + "-" + stdate[0] + "-" + stdate[2]
        //                                                    + " " + gameNode.Attributes["time"].InnerText + ":00";
        //                                //format date to "10-14-2013 15:09:44"
        //                                var goalServeMatchID = gameNode.Attributes["id"].InnerText;
        //                                //DataSet data = admin.getGoalServeGame(goalServeMatchID);
        //                                //if(data != null){
        //                                //    if(data.Tables.Count > 0){
        //                                //       continue;
        //                                //  }
        //                                //}
        //                                foreach (XmlNode oddType in gameOdds)
        //                                {
        //                                    var bettype = oddType.Attributes["name"].InnerText;
        //                                    var cat = new BetCategory();
        //                                    _db.BetCategories.Add(cat);
        //                                    if (bettype.Equals("Double Chance"))
        //                                    {
        //                                        _admin.dchdodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value);
        //                                        _admin.dcdaodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                                        _admin.dchaodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                                    }
        //                                    else if (bettype.Equals("Full Time Result"))
        //                                    {
        //                                        var NormalOdds = oddType.ChildNodes;
        //                                        foreach (XmlNode normalodd in NormalOdds)
        //                                        {
        //                                            var choice = normalodd.Attributes.GetNamedItem("name").Value.ToString();
        //                                            if (choice == "Draw")
        //                                            {
        //                                                _admin.odddraw = Convert.ToDouble(normalodd.Attributes.GetNamedItem("odd").Value);
        //                                            }
        //                                            else if (choice == hostTeam + " Win")
        //                                            {
        //                                                _admin.oddhome = Convert.ToDouble(normalodd.Attributes.GetNamedItem("odd").Value);
        //                                            }
        //                                            else if (choice == awayTeam + " Win")
        //                                            {
        //                                                _admin.oddaway = Convert.ToDouble(normalodd.Attributes.GetNamedItem("odd").Value);
        //                                            }

        //                                        }
        //                                    }
        //                                    else if (bettype.Equals("Half-Time"))
        //                                    {
        //                                        _admin.hfawayodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value);
        //                                        _admin.hfdrawodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                                        _admin.hfhomeodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                                    }
        //                                    else if (bettype.Equals("Handicap Result"))
        //                                    {
        //                                        _admin.hchomeodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                                        _admin.hcdrawodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                                        _admin.hcawayodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value);
        //                                        int hhome =
        //                                            Convert.ToInt16(oddType.ChildNodes[0].Attributes["extravalue"].Value);
        //                                        int haway =
        //                                            Convert.ToInt16(oddType.ChildNodes[2].Attributes["extravalue"].Value);
        //                                        _admin.handhome = hhome < 0 ? (hhome - hhome) : hhome;
        //                                        _admin.handaway = haway < 0 ? (haway - haway) : haway;
        //                                        ;
        //                                    }
        //                                    else if (bettype.Equals("Total Goals Odd/Even"))
        //                                    {
        //                                        _admin.oddodd =
        //                                            Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                                        _admin.oddeven =
        //                                            Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                                    }
        //                                    else if (bettype.Equals("Total Goals"))
        //                                    {
        //                                        _admin.underodd = Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                                        _admin.overodd = Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                                    }

        //                                    _admin.host = hostTeam;
        //                                    _admin.setno = Convert.ToInt32(setno.Text);
        //                                    _admin.league = league;
        //                                    _admin.MatchNo = Convert.ToInt64(goalServeMatchID);
        //                                    _admin.visitors = awayTeam;
        //                                    _admin.stime = Convert.ToDateTime(stDateTime);
        //                                    _admin.stime = _admin.stime.ToLocalTime();
        //                                    var feed = new MatchFeed
        //                                    {
        //                                        Game =
        //                                        {
        //                                            MatchNo = Convert.ToInt32(_admin.MatchNo),
        //                                            StartTime = _admin.stime,
        //                                            ResultStatus = 1
        //                                        }
        //                                    };
        //                                } //end odd type

        //                                if (!avail.Equals("false")) continue;
        //                                var result = 0;

        //                                try
        //                                {
        //                                    result = _admin.InsertMatch(goalServeMatchID);
        //                                }
        //                                catch (Exception exp)
        //                                {
        //                                    _countFail++;
        //                                }


        //                                var exec = 0;
        //                                if (result > 0)
        //                                {
        //                                    _count++;

        //                                }
        //                            } //end game
        //                            try
        //                            {
        //                                var l = _admin.InsertLeague(node.Attributes["name"].InnerText,
        //                                    node.Attributes["file_group"].InnerText);
        //                                if (l > 0)
        //                                {
        //                                    _leaguesAdded++;
        //                                }
        //                            }
        //                            catch (Exception exp)
        //                            {
        //                                _leaguesAdded = -10;
        //                            }
        //                        } //end matches
        //                    } //end category, xml parse

        //                }
        //                try
        //                {
        //                    xmldoc.Load(new MemoryStream());
        //                }
        //                catch (Exception ex)
        //                {


        //                }
        //                Thread.Sleep(5000);
        //            }
        //            var totalTime = (DateTime.Now - start);

        //            Respond("Number of games added: " + _count + "<br />" + "Games already added: " + _countFail + "<br />" +
        //                    "Number of leagues registered: " + _leaguesAdded + " time taken " + totalTime.TotalMilliseconds +
        //                    " ms");
        //        }
        //        else
        //        {
        //            Respond("<b><font color=\"Red\">Update is already running in the background</font></b>");
        //        }
        //        //            });
            
        //}
    }
}