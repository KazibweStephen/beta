using System;
using WebUI.DataAccessLayer;

namespace WebUI.gbl
{
    public partial class Uploadxml : System.Web.UI.Page
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly AdminClass _admin = new AdminClass();

        public int CountFail { get; set; }

        public int LeaguesAdded { get; set; }

        public int Count { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Loadgames(object sender, EventArgs e) {
            //AutoUpdate();
        
        }
    
        // protected void AutoUpdate()
        // {
        //     var xmldoc = new XmlDocument();
        //{
        //    xmldoc.Load(Server.MapPath("~/gbl/england_shedule.xml"));
        //    var categoryList = xmldoc.SelectNodes("/scores/category");

        //    if (categoryList != null)
        //        foreach (XmlNode node in categoryList)
        //        {
        //            var matches = node.ChildNodes;
        //            foreach (XmlNode matchesNode in matches)
        //            {
        //                var games = matchesNode.ChildNodes;
        //                foreach (XmlNode gameNode in games)
        //                {
        //                    var home = gameNode.ChildNodes[0];
        //                    var away = gameNode.ChildNodes[1];
        //                    var odd = gameNode.ChildNodes[4];
        //                    var gameOdds = odd.ChildNodes;
        //                    string avail;
        //                    try
        //                    {
        //                        avail = odd.Attributes["notfound"].Value;
        //                    }
        //                    catch (NullReferenceException)
        //                    {
        //                        avail = "true";
        //                    }
        //                    if (avail.Equals("true"))
        //                    {
        //                        //match has no odd details
        //                        continue;
        //                    }

        //                    var league = node.Attributes["name"].InnerText;
        //                    var country = node.Attributes["file_group"].InnerText;
        //                    var counts = new Country {CountryName = country};
        //                    string hostTeam = null, awayTeam = null;
        //                    var lg = new League { Country = country, LeagueName = league};
        //                    _db.Leagues.Add(lg);
                                
        //                    var teamfeed = new Game();
        //                    var teams = new Team();
        //                    var tm = new List<Team>();
        //                    if (home.Name == "localteam")
        //                    {
        //                        hostTeam = home.Attributes["name"].InnerText;

        //                        teams.TeamName = hostTeam;
                                      
        //                        if (teams != null)
        //                        {
        //                            tm.Add(teams);
        //                        }
        //                        teams.Country = counts;
        //                        _db.Teams.Add(teams);
        //                        _db.SaveChanges();
        //                        teamfeed.HomeTeam.TeamId = teams.TeamId;
        //                    }
        //                    if (away.Name == "visitorteam")
        //                    {
        //                        awayTeam = away.Attributes["name"].InnerText;
        //                        teams.TeamName = awayTeam;
        //                        tm.Add(teams);
        //                        _db.Teams.Add(teams);
        //                        _db.SaveChanges();
        //                        teamfeed.AwayTeam.TeamId = teams.TeamId;

        //                    }

        //                    char[] del = { '.' };
        //                    var stdate = gameNode.Attributes["formatted_date"].InnerText.Split(del);
        //                    var stDateTime = stdate[1] + "-" + stdate[0] + "-" + stdate[2]
        //                                    + " " + gameNode.Attributes["time"].InnerText + ":00";
        //                    var goalServeMatchId = gameNode.Attributes["id"].InnerText;
                                 
        //                    foreach (XmlNode oddType in gameOdds)
        //                    {
        //                        var bettype = oddType.Attributes["name"].InnerText;
        //                        var cat = new BetCategory();
        //                        _db.BetCategories.Add(cat);
        //                        if (bettype.Equals("Double Chance"))
        //                        {
        //                            _admin.dchdodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value);
        //                            _admin.dcdaodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                            _admin.dchaodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                        }
        //                        else if (bettype.Equals("Full Time Result"))
        //                        {
        //                            var normalOdds = oddType.ChildNodes;
        //                            foreach (XmlNode normalodd in normalOdds)
        //                            {
        //                                var choice = normalodd.Attributes.GetNamedItem("name").Value;
        //                                if (choice == "Draw")
        //                                {
        //                                    _admin.odddraw = Convert.ToDouble(normalodd.Attributes.GetNamedItem("odd").Value);
        //                                }
        //                                else if (choice == hostTeam + " Win")
        //                                {
        //                                    _admin.oddhome = Convert.ToDouble(normalodd.Attributes.GetNamedItem("odd").Value);
        //                                }
        //                                else if (choice == awayTeam + " Win")
        //                                {
        //                                    _admin.oddaway = Convert.ToDouble(normalodd.Attributes.GetNamedItem("odd").Value);
        //                                }

        //                            }
        //                        }
        //                        else if (bettype.Equals("Half-Time"))
        //                        {
        //                            _admin.hfawayodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value);
        //                            _admin.hfdrawodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                            _admin.hfhomeodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                        }
        //                        else if (bettype.Equals("Handicap Result"))
        //                        {
        //                            _admin.hchomeodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                            _admin.hcdrawodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                            _admin.hcawayodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value);
        //                            int hhome =
        //                                Convert.ToInt16(oddType.ChildNodes[0].Attributes["extravalue"].Value);
        //                            int haway =
        //                                Convert.ToInt16(oddType.ChildNodes[2].Attributes["extravalue"].Value);
        //                            _admin.handhome = hhome < 0 ? (hhome - hhome) : hhome;
        //                            _admin.handaway = haway < 0 ? (haway - haway) : haway;
        //                        }
        //                        else if (bettype.Equals("Total Goals Odd/Even"))
        //                        {
        //                            _admin.oddodd =
        //                                Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                            _admin.oddeven =
        //                                Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                        }
        //                        else if (bettype.Equals("Total Goals"))
        //                        {
        //                            _admin.underodd = Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value);
        //                            _admin.overodd = Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value);
        //                        }

        //                        _admin.host = hostTeam;
        //                        _admin.setno = 789;
        //                        _admin.league = league;
        //                        _admin.MatchNo = Convert.ToInt64(goalServeMatchId);
        //                        _admin.visitors = awayTeam;
        //                        _admin.stime = Convert.ToDateTime(stDateTime);
        //                        _admin.stime = _admin.stime.ToLocalTime();                                  
        //                        //teamfeed.MatchNo = Convert.ToInt32(goalServeMatchID);
        //                        teamfeed.StartTime = _admin.stime;
        //                        teamfeed.ResultStatus = 1;
        //                        _db.Games.Add(teamfeed);
        //                        _db.SaveChanges();


        //                    } //end odd type

        //                    if (!avail.Equals("false")) continue;
        //                    var result = 0;

        //                    try
        //                    {
        //                        result = _admin.InsertMatch(goalServeMatchId);
        //                    }
        //                    catch (Exception)
        //                    {
        //                        CountFail++;
        //                    }


        //                    if (result > 0)
        //                    {
        //                        Count++;

        //                    }
        //                } //end game
        //                try
        //                {
        //                    var l = _admin.InsertLeague(node.Attributes["name"].InnerText,
        //                        node.Attributes["file_group"].InnerText);
        //                    if (l > 0)
        //                    {
        //                        LeaguesAdded++;
        //                    }
        //                }
        //                catch (Exception)
        //                {
        //                    LeaguesAdded = -10;
        //                }
        //            } //end matches
        //        } //end category, xml parse
        //}
        //try
        //{
        //    xmldoc.Load(new MemoryStream());
        //}
        //catch
        //{
        //}
        //Thread.Sleep(5000);
        //}       
    }
}