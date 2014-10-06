using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using System.Xml;
using DocumentFormat.OpenXml.Drawing;
using Domain.Models.Concrete;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;
using WebUI.Helpers;
using Domain.Models.ViewModels;
using System.Web;
using System.ComponentModel;


namespace WebUI.Controllers
{ 
    public class FixtureController : CustomController
    {
        private Team _awayTeam, _homeTeam;
        // GET: Fixture
        private readonly string[] _urls =
        {
             "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/eurocups_shedule?odds=bet365",
            " http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/qatar_shedule?odds=bet365",
            " http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/malta_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/iran_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/africa_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/argentina_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/asia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/australia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/austria_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/belarus_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/belgium_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/brazil_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/bulgaria_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/chile_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/china_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/colombia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/concacaf_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/costarica_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/croatia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/cyprus_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/czechia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/denmark_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/egypt_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/england_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/equador_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/estonia_shedule?odds=bet365",   
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/finland_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/france_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/germany_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/greece_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/holland_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/hungary_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/iceland_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/ireland_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/israel_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/italy_shedule?odds=bet365",     
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/japan_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/korea_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/latvia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/lithuania_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/malta_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/mexico_shedule?odds=bet365",
              "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/moldova_shedule?odds=bet365",
              "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/Iran_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/norway_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/paraguay_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/peru_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/poland_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/portugal_shedule?odds=bet365",
         
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/romania_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/russia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/saudi_arabia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/scotland_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/serbia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/singapore_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/slovakia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/slovenia_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/southafrica_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/southamerica_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/spain_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/sweden_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/switzerland_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/turkey_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/uae_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/ukraine_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/uruguay_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/usa_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/venezuela_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/wales_shedule?odds=bet365",
            "http://www.goalserve.com/getfeed/d1aa4f5599064db8b343090338221a49/soccernew/worldcup_shedule?odds=bet365"
       };
        public ActionResult Index()
        {
            return View();
        }
     
             
        public ActionResult AddOdds(int ? id=0)
        {
            ViewBag.MatchId = id;
            return View();
        }
        public ActionResult AddMatchOdds()
        {

            return View(new MatchOdd());
        }
    
        public async Task<ActionResult> LoadFixture()
        {
           int count= await UploadGames();
            ViewBag.Message = count + "games loaded";
            return View();
        }

      
        private async Task<int> UploadGames()
        {
            foreach (var url in _urls)
            {
                var req = (HttpWebRequest)WebRequest.Create(url);
                var res = (HttpWebResponse)req.GetResponse();
                var stream = res.GetResponseStream();
                var xmldoc = new XmlDocument();
                {
                    xmldoc.Load(stream);
                    var categoryList = xmldoc.SelectNodes("/scores/category");

                    if (categoryList == null) return 0;
                    foreach (XmlNode node in categoryList)
                    {
                        var matches = node.ChildNodes;
                        foreach (XmlNode matchesNode in matches)
                        {
                            var games = matchesNode.ChildNodes;
                            foreach (XmlNode gameNode in games)
                            {
                                var home = gameNode.ChildNodes[0];
                                var away = gameNode.ChildNodes[1];
                                var odd = gameNode.ChildNodes[4];
                                var gameOdds = odd.ChildNodes;
                                var league = node.Attributes["name"] != null
                                    ? node.Attributes["name"].InnerText
                                    : "FailedLeague";
                                var countryName = node.Attributes["file_group"].InnerText;
                                char[] del = { '.' };
                                var stdate = gameNode.Attributes["formatted_date"].InnerText.Split(del);
                                var stDateTime = stdate[1] + "-" + stdate[0] + "-" + stdate[2]
                                                 + " " + gameNode.Attributes["time"].InnerText + ":00";
                               
                                if (Convert.ToDateTime(stDateTime) > DateTime.Now.AddDays(3))
                                {
                                    continue;
                                }
                                var country = BetDatabase.Countries.SingleOrDefault(c => c.CountryName == countryName);
                                if (country == null)
                                {
                                    country = new Country
                                    {
                                        CountryName = countryName
                                    };
                                    BetDatabase.Countries.AddOrUpdate(c => c.CountryName, country);
                                    await BetDatabase.SaveChangesAsync();
                                }

                                // save the league
                                BetDatabase.Leagues.AddOrUpdate(l => l.LeagueName, new League
                                {
                                    LeagueName = league,
                                    Country = country

                                });
                                await BetDatabase.SaveChangesAsync();

                                var game = new Match();
                                var gameodds = new List<MatchOdd>();
                                game.Champ = league;
                                game.StartTime = Convert.ToDateTime(stDateTime).ToLocalTime();
                               
                                if (home.Name == "localteam")
                                {
                                    _homeTeam = new Team
                                    {
                                        TeamName = home.Attributes["name"].InnerText,
                                        CountryId = country.CountryId
                                    };
                                    BetDatabase.Teams.AddOrUpdate(t => t.TeamName, _homeTeam);
                                    await BetDatabase.SaveChangesAsync();
                                    game.HomeTeamId = _homeTeam.TeamId;
                                }
                                if (away.Name == "visitorteam")
                                {
                                    _awayTeam = new Team
                                    {
                                        TeamName = away.Attributes["name"].InnerText,
                                        CountryId = country.CountryId
                                    };
                                    BetDatabase.Teams.AddOrUpdate(t => t.TeamName, _awayTeam);
                                    await BetDatabase.SaveChangesAsync();
                                    game.AwayTeamId = _awayTeam.TeamId;

                                }

                              
                              
                                var goalServeMatchId = gameNode.Attributes["id"].InnerText;

                                foreach (XmlNode oddType in gameOdds) 
                                {
                                    var bettype = oddType.Attributes["name"].InnerText;
                                    switch (bettype)
                                    {
                                        case "Full Time Result":
                                            var normalOdds = oddType.ChildNodes;
                                            foreach (XmlNode normalodd in normalOdds)
                                            {
                                                try
                                                {
                                                    var choice = normalodd.Attributes.GetNamedItem("name").Value;
                                                    if (choice == _homeTeam.TeamName + " Win")
                                                    {
                                                        gameodds.Add(new MatchOdd
                                                        {
                                                            //1
                                                            BetOptionId = 1,
                                                            Odd =
                                                                Convert.ToDecimal(
                                                                    normalodd.Attributes.GetNamedItem("odd").Value)
                                                        });
                                                    }
                                                    else if (choice == "Draw")
                                                    {
                                                        gameodds.Add(new MatchOdd
                                                        {
                                                            // X
                                                            BetOptionId = 2,
                                                            Odd =
                                                                Convert.ToDecimal(
                                                                    normalodd.Attributes.GetNamedItem("odd").Value)
                                                        });
                                                    }
                                                    else if (choice == _awayTeam.TeamName + " Win")
                                                    {
                                                        gameodds.Add(new MatchOdd
                                                        {
                                                            // 2
                                                            BetOptionId = 3,
                                                            Odd =
                                                                Convert.ToDecimal(
                                                                    normalodd.Attributes.GetNamedItem("odd").Value)
                                                        });
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                }

                                            }
                                            break;
                                        case "Double Chance":
                                            try
                                            {
                                                gameodds.AddRange(new[]
                                                {
                                                    new MatchOdd
                                                    {
                                                        //1X
                                                        BetOptionId = 21,
                                                        Odd =
                                                            oddType.ChildNodes[2].Attributes != null
                                                                ? Convert.ToDecimal(
                                                                    oddType.ChildNodes[2].Attributes["odd"].Value)
                                                                : 0
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //12
                                                        BetOptionId = 22,
                                                        Odd =
                                                            oddType.ChildNodes[1].Attributes != null
                                                                ? Convert.ToDecimal(
                                                                    oddType.ChildNodes[1].Attributes["odd"].Value)
                                                                : 0
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //X2
                                                        BetOptionId = 23,
                                                        Odd =
                                                            oddType.ChildNodes[0].Attributes != null
                                                                ? Convert.ToDecimal(
                                                                    oddType.ChildNodes[0].Attributes["odd"].Value)
                                                                : 0
                                                    }
                                                });
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                            break;
                                        case "Half-Time":
                                            try
                                            {
                                                gameodds.AddRange(new[]
                                                {
                                                    new MatchOdd
                                                    {
                                                        //1X
                                                        BetOptionId = 12,
                                                        Odd =
                                                            oddType.ChildNodes[0].Attributes != null
                                                                ? Convert.ToDecimal(
                                                                    oddType.ChildNodes[0].Attributes["odd"].Value)
                                                                : 0
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //12
                                                        BetOptionId = 13,
                                                        Odd =
                                                            oddType.ChildNodes[1].Attributes != null
                                                                ? Convert.ToDecimal(
                                                                    oddType.ChildNodes[1].Attributes["odd"].Value)
                                                                : 0
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //X2
                                                        BetOptionId = 14,
                                                        Odd =
                                                            oddType.ChildNodes[2].Attributes != null
                                                                ? Convert.ToDecimal(
                                                                    oddType.ChildNodes[2].Attributes["odd"].Value)
                                                                : 0
                                                    }
                                                });
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                            break;
                                        case "Handicap Result":
                                            try
                                            {
                                                var hhome =
                                                    Convert.ToInt16(oddType.ChildNodes[0].Attributes["extravalue"].Value);
                                                var haway =
                                                    Convert.ToInt16(oddType.ChildNodes[2].Attributes["extravalue"].Value);
                                                gameodds.AddRange(new[]
                                                {
                                                    new MatchOdd
                                                    {
                                                        // Handicap Home HC1
                                                        BetOptionId = 24,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[0].Attributes["odd"].Value),
                                                        HandicapGoals = hhome < 0 ? hhome - hhome : hhome
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // HAndicap Away HC2
                                                        BetOptionId = 31,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[1].Attributes["odd"].Value),
                                                        HandicapGoals = haway < 0 ? (haway - haway) : haway
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // HAndicap Away HC2
                                                        BetOptionId = 25,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[2].Attributes["odd"].Value),
                                                        HandicapGoals = haway < 0 ? (haway - haway) : haway
                                                    }

                                                });
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                            break;

                                        case "Draw No Bet":
                                            try
                                            {
                                                gameodds.AddRange(new[]
                                                {
                                                    new MatchOdd
                                                    {
                                                        //DNB1
                                                        BetOptionId = 28,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[0].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //DNB2
                                                        BetOptionId = 29,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[1].Attributes["odd"].Value)
                                                    }
                                                });
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                            break;

                                        case "Both Teams to Score":
                                            try
                                            {
                                                gameodds.AddRange(new[]
                                                {
                                                    new MatchOdd
                                                    {
                                                        // GG
                                                        BetOptionId = 26,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[0].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // NG
                                                        BetOptionId = 27,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[1].Attributes["odd"].Value)
                                                    }
                                                });
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                            break;

                                        case "Total Goals":
                                            try
                                            {
                                                gameodds.AddRange(new[]
                                                {
                                                    new MatchOdd
                                                    {
                                                        // FTUnder2.5
                                                        BetOptionId = 6,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[1].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // FTOver2.5
                                                        BetOptionId = 7,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[0].Attributes["odd"].Value)
                                                    }
                                                });
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                            break;

                                        case "Alternative Total Goals":
                                            try
                                            {
                                                gameodds.AddRange(new[]
                                                {
                                                    new MatchOdd
                                                    {
                                                        // FTUnder0.5
                                                        BetOptionId = 32,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[1].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // FTOver0.5
                                                        BetOptionId = 33,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[0].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // FTUnder1.5
                                                        BetOptionId = 4,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[3].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // FTOver1.5
                                                        BetOptionId = 5,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[2].Attributes["odd"].Value)
                                                    },
                                                
                                                    new MatchOdd
                                                    {
                                                        // FTOver3.5
                                                        BetOptionId = 9,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[4].Attributes["odd"].Value)
                                                    },
                                                        new MatchOdd
                                                    {
                                                        // FTUnder3.5
                                                        BetOptionId = 8,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[5].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // FTUnder4.5
                                                        BetOptionId = 10,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[7].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // FTOver4.5
                                                        BetOptionId = 11,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[6].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // FTUnder5.5
                                                        BetOptionId = 34,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[7].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        // FTOver5.5
                                                        BetOptionId = 35,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[6].Attributes["odd"].Value)
                                                    }
                                                });
                                            }
                                            catch (Exception ex)
                                            {
                                            }
                                            break;
                                        case "First Half Goals":
                                            try
                                            {
                                                gameodds.AddRange(new[]
                                                {
                                                    new MatchOdd
                                                    {
                                                        //HTUnder0.5
                                                        BetOptionId = 15,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[1].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //HTOver0.5
                                                        BetOptionId = 16,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[0].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //HTUnder1.5
                                                        BetOptionId = 17,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[3].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //HTOver1.5
                                                        BetOptionId = 18,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[2].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //HTUnder2.5
                                                        BetOptionId = 19,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[5].Attributes["odd"].Value)
                                                    },
                                                    new MatchOdd
                                                    {
                                                        //HTOver2.5
                                                        BetOptionId = 20,
                                                        Odd =
                                                            Convert.ToDecimal(
                                                                oddType.ChildNodes[4].Attributes["odd"].Value)
                                                    }
                                                });
                                            }
                                            catch (Exception)
                                            {
                                                
                                            }
                                            break;
                                    }
                                } 
                                game.GameOdds = gameodds;
                                game.MatchNo = Convert.ToInt32(goalServeMatchId);
                                game.StartTime = Convert.ToDateTime(stDateTime).ToLocalTime();
                                game.ResultStatus = 1;
                                game.GameOdds.ForEach(g => g.GameId = game.MatchNo);
                                BetDatabase.Matches.AddOrUpdate(game);
                                await BetDatabase.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
            return 1;
        }

        public void AddPayments(MatchTest match)
        {
          
            string user = match.Mat;
        }
        public void AddOdd(MatchOddsVm odds)
        {
         
            Match match = BetDatabase.Matches.Find(odds.Mat);
            MatchOdd matchOdd = null;
            int Matno = Convert.ToInt32(odds.Mat);
            try {
                if (match != null)
                {
                    if (odds.OddFt1 != 0)
                    {

                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 1;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.OddFt1);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                        BetDatabase.SaveChanges();
                    }
                    if (odds.OddFTX != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 2;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.OddFTX);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                        BetDatabase.SaveChanges();
                    }
                    if (odds.OddFT2 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 3;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.OddFT2);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    
                        BetDatabase.SaveChanges();
                    }

                    if (odds.oddFtUnder15 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 4;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtUnder15);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddFtOver15 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 5;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtOver15);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddFtUnder25 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 6;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtUnder25);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddFtOver25 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 7;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtOver25);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddFtUnder35 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 8;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtUnder35);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                        BetDatabase.SaveChanges();
                    }

                    if (odds.oddFtOver35 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 9;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtOver35);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                
                    }
                    if (odds.oddFtUnder45 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 10;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtUnder45);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                      
                    }

                    if (odds.oddFtOver45 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 11;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtOver45);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.OddHt1 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 12;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.OddHt1);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.OddHtx != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 13;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.OddHtx);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.OddHt2 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 14;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.OddHt2);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                        BetDatabase.SaveChanges();

                    }
                    if (odds.oddHtUnder05 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 15;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHtUnder05);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddHtOver05 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 16;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHtOver05);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);

                    }
                    if (odds.oddHtUnder15 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 17;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHtUnder15);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddHtOver15 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 18;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHtOver15);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                        BetDatabase.SaveChanges();
                    }
                    if (odds.oddHtUnder25 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 19;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHtUnder25);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddHtOver25 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 20;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHtOver25);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.odd1X != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 21;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.odd1X);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    /*double chance*/
                    if (odds.odd12 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 22;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.odd12);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddX2 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 23;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddX2);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }

                    if (odds.oddHC1 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 24;
                        matchOdd.GameId = Matno;
                        matchOdd.HandicapGoals = odds.HomeGoal;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHC1);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                        BetDatabase.SaveChanges();
                    }
                    if (odds.oddHC2!= 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 25;
                        matchOdd.GameId = Matno;
                        matchOdd.HandicapGoals = odds.AwayGoal;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHC2);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.OddFT2 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 26;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddGG);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddGG != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 27;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddNG);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);

                    }
                    if (odds.oddHCX != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 31;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddHCX);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddFtUnder05 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 32;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtUnder05);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                        BetDatabase.SaveChanges();
                    }
                    if (odds.oddFtOver05 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 33;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtOver05);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddFtUnder55 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 34;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtUnder55);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    if (odds.oddFtOver55 != 0)
                    {
                        matchOdd = new MatchOdd();
                        matchOdd.BetOptionId = 35;
                        matchOdd.GameId = Matno;
                        matchOdd.Odd = Convert.ToDecimal(odds.oddFtOver55);
                        BetDatabase.MatchOdds.AddOrUpdate(matchOdd);
                    }
                    BetDatabase.SaveChanges();

                }
        


            }
            catch (Exception) { }
        

        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension =
                                     System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/Files/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {

                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                            fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                                                fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/Files/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    // DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }
                List<Match> excelmatches = new List<Match>();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        var countryName = (ds.Tables[0].Rows[i][3]).ToString();
                        var country = BetDatabase.Countries.SingleOrDefault(c => c.CountryName == countryName);
                        if (country == null)
                        {
                            country = new Country
                            {
                                CountryName = countryName
                            };
                            BetDatabase.Countries.AddOrUpdate(c => c.CountryName, country);
                            BetDatabase.SaveChanges();
                        }

                        // save the league
                        BetDatabase.Leagues.AddOrUpdate(l => l.LeagueName, new League
                        {
                            LeagueName = countryName,
                            Country = country

                        });

                        string st = ds.Tables[0].Rows[i][0].ToString();

                        try
                        {
                            _homeTeam = new Team
                            {
                                TeamName = ds.Tables[0].Rows[i][4].ToString(),
                                CountryId = country.CountryId
                            };
                            BetDatabase.Teams.AddOrUpdate(t => t.TeamName, _homeTeam);
                            BetDatabase.SaveChanges();
                            _awayTeam = new Team
                            {
                                TeamName = ds.Tables[0].Rows[i][5].ToString(),
                                CountryId = country.CountryId
                            };
                            BetDatabase.Teams.AddOrUpdate(t => t.TeamName, _awayTeam);
                            BetDatabase.SaveChanges();



                            if (st != "")
                            {
                                int Matno = Convert.ToInt32(ds.Tables[0].Rows[i][0] ?? 0);
                              
                                int index = (ds.Tables[0].Rows[i][1]).ToString().IndexOf(" ");
                                var stDate = (ds.Tables[0].Rows[i][1]).ToString().Substring(0,index);
                                var stTime =  (ds.Tables[0].Rows[i][2]).ToString() + ":00";
                                DateTime MatchTime = Convert.ToDateTime(stDate+" "+stTime);
                                var match = new Match()
                                {
                                    MatchNo = Matno,
                                    StartTime = MatchTime,
                                    Champ = (ds.Tables[0].Rows[i][3]).ToString(),
                                    GameOdds = new List<MatchOdd>()
                                    {
                                        new MatchOdd// Full Time Results
                                        {
                                            BetOptionId = 1,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][6] ?? 0),
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 2,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][7] ?? 0),
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 3,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][8] ?? 0),
                                        },


                                        new MatchOdd  //Under 2.5
                                        {
                                            BetOptionId = 6,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][9] ?? 0),
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 7,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][10] ?? 0),
                                        },

                                        new MatchOdd  // Full Time1.5
                                        {
                                            BetOptionId = 4,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][11] ?? 0),
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 5,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][12] ?? 0),
                                        },


                                    
                                        new MatchOdd//HalfTime
                                        {
                                            BetOptionId = 12,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][13] ?? 0),
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 13,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][14] ?? 0),
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 14,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][15] ?? 0),
                                        },

                                        new MatchOdd   //HalfTime Under
                                        {//1.5
                                            BetOptionId = 17,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][16] ?? 0),
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 18,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][17] ?? 0),
                                        },

                                        new MatchOdd //Ht 0.5
                                        {
                                            BetOptionId = 15,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][18] ?? 0),
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 16,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][19] ?? 0),
                                        },
                                        new MatchOdd  //double chance 1x
                                        {
                                            BetOptionId = 21,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][20] ?? 0),
                                        },
                                        //Double Chance
                                        new MatchOdd //x2
                                        {
                                            BetOptionId = 23,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][21] ?? 0),
                                        },
                                        new MatchOdd  //Double Chance x2
                                        {
                                            BetOptionId = 22,
                                            GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][22] ?? 0),
                                        },

                                               //HandCap home
                                        new MatchOdd // hc1
                                        {
                                            BetOptionId = 24,
                                              GameId = Matno,
                                            LastUpdateTime = DateTime.Now,                 
                                            HandicapGoals = Convert.ToInt16(ds.Tables[0].Rows[i][26] ?? 0),
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][23] ?? 0),

                                        },



                                        //HandCap X
                                        new MatchOdd
                                        {
                                            BetOptionId = 31,
                                               GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][24] ?? 0),
                                        },
                                       
                                               //HandCap Away
                                        new MatchOdd
                                        {
                                            BetOptionId = 25,
                                              GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                             HandicapGoals = Convert.ToInt16(ds.Tables[0].Rows[i][27] ?? 0),
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][25] ?? 0),
                                        },



                                        // Both Teams To Score  Yes
                                        new MatchOdd
                                        {
                                            BetOptionId = 26,
                                               GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][28] ?? 0),
                                        },
                                        
                                                // Both Teams To Score  No
                                        new MatchOdd
                                        {
                                            BetOptionId = 27,
                                              GameId = Matno,
                                            LastUpdateTime = DateTime.Now,
                                            Odd = Convert.ToDecimal(ds.Tables[0].Rows[i][29] ?? 0),
                                        },                                

                                    },
                                    AwayTeamId = _awayTeam.TeamId,
                                    HomeTeamId = _homeTeam.TeamId,
                                    RegistrationDate = DateTime.Now,
                                    ResultStatus = 1,
                                };
                                excelmatches.Add(match);
                                match.GameOdds.ForEach(g => g.GameId = match.MatchNo);
                                BetDatabase.Matches.AddOrUpdate(match);
                                BetDatabase.SaveChanges();
                            }


                        }
                        catch (Exception er)
                        {

                            continue;
                        }


                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
               // BetDatabase.SaveChanges();
                
            }

            return View();
        }

        public decimal getodd(string num)
        {

            double odd = 1;
            if (Double.TryParse(num, out odd))
            {
               odd=Convert.ToDouble(num);
            }
            else
            {
                odd = 1;
            }
            return Convert.ToDecimal(odd);

        }
        public static DataTable ConvertToDatatable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }
                


    }
}