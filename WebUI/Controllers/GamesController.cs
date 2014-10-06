using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using System.Xml;
using Domain.Models.Concrete;
using Domain.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.Extensions;
using WebUI.Helpers;

namespace WebUI.Controllers
{

    public class GamesController : CustomController
    {
        private Team _awayTeam, _homeTeam;

        private async Task<int> UploadGames()
        {
            var xmldoc = new XmlDocument();
            {
                xmldoc.Load(Server.MapPath("~/england_shedule.xml"));
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
                            var league = node.Attributes["name"]!=null? node.Attributes["name"].InnerText: "FailedLeague";
                            var countryName = node.Attributes["file_group"].InnerText;

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

                            char[] del = {'.'};
                            var stdate = gameNode.Attributes["formatted_date"].InnerText.Split(del);
                            var stDateTime = stdate[1] + "-" + stdate[0] + "-" + stdate[2]
                                             + " " + gameNode.Attributes["time"].InnerText + ":00";
                            var goalServeMatchId = gameNode.Attributes["id"].InnerText;

                            foreach (XmlNode oddType in gameOdds)
                            {
                                var bettype = oddType.Attributes["name"].InnerText;
                                if (bettype.Equals("Full Time Result"))
                                {
                                    var normalOdds = oddType.ChildNodes;
                                    foreach (XmlNode normalodd in normalOdds)
                                    {
                                        var choice = normalodd.Attributes.GetNamedItem("name").Value;
                                        if (choice == _homeTeam.TeamName + " Win")
                                        {
                                            gameodds.Add(new MatchOdd
                                            {
                                                BetOptionId = 1,
                                                Odd = Convert.ToDecimal(normalodd.Attributes.GetNamedItem("odd").Value)
                                            });
                                        }
                                        else if (choice == "Draw")
                                        {
                                            gameodds.Add(new MatchOdd
                                            {
                                                BetOptionId = 2,
                                                Odd = Convert.ToDecimal(normalodd.Attributes.GetNamedItem("odd").Value)
                                            });
                                        }
                                        else if (choice == _awayTeam.TeamName + " Win")
                                        {
                                            gameodds.Add(new MatchOdd
                                            {
                                                BetOptionId = 3,
                                                Odd = Convert.ToDecimal(normalodd.Attributes.GetNamedItem("odd").Value)
                                            });
                                        }

                                    }
                                }
                                if (bettype.Equals("Double Chance"))
                                {
                                    gameodds.AddRange(new[]
                                    {
                                        new MatchOdd
                                        {
                                            //1X
                                            BetOptionId = 21,
                                            Odd =
                                                oddType.ChildNodes[2].Attributes != null
                                                    ? Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value)
                                                    : 0
                                        },
                                        new MatchOdd
                                        {
                                            //12
                                            BetOptionId = 22,
                                            Odd =
                                                oddType.ChildNodes[1].Attributes != null
                                                    ? Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value)
                                                    : 0
                                        },
                                        new MatchOdd
                                        {
                                            //X2
                                            BetOptionId = 23,
                                            Odd =
                                                oddType.ChildNodes[0].Attributes != null
                                                    ? Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value)
                                                    : 0
                                        }
                                    });
                                }
                                else if (bettype.Equals("Half-Time"))
                                {
                                    gameodds.AddRange(new[]
                                    {
                                        new MatchOdd
                                        {
                                            //1X
                                            BetOptionId = 12,
                                            Odd =
                                                oddType.ChildNodes[0].Attributes != null
                                                    ? Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value)
                                                    : 0
                                        },
                                        new MatchOdd
                                        {
                                            //12
                                            BetOptionId = 13,
                                            Odd =
                                                oddType.ChildNodes[1].Attributes != null
                                                    ? Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value)
                                                    : 0
                                        },
                                        new MatchOdd
                                        {
                                            //X2
                                            BetOptionId = 14,
                                            Odd =
                                                oddType.ChildNodes[2].Attributes != null
                                                    ? Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value)
                                                    : 0
                                        }
                                    });
                                }
                                else if (bettype.Equals("Handicap Result"))
                                {
                                    gameodds.AddRange(new[]
                                    {
                                        new MatchOdd
                                        {
                                            BetOptionId = 24,
                                            Odd = Convert.ToDecimal(oddType.ChildNodes[0].Attributes["odd"].Value)
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 25,
                                            Odd = Convert.ToDecimal(oddType.ChildNodes[1].Attributes["odd"].Value)
                                        },
                                        new MatchOdd
                                        {
                                            BetOptionId = 26,
                                            Odd = Convert.ToDecimal(oddType.ChildNodes[2].Attributes["odd"].Value)
                                        }
                                    });
                                    /*int hhome =
                                            Convert.ToInt16(oddType.ChildNodes[0].Attributes["extravalue"].Value);
                                        int haway =
                                            Convert.ToInt16(oddType.ChildNodes[2].Attributes["extravalue"].Value);
                                        _admin.handhome = hhome < 0 ? (hhome - hhome) : hhome;
                                        _admin.handaway = haway < 0 ? (haway - haway) : haway;*/
                                }

                            }
                            game.GameOdds = gameodds;
                            game.MatchNo = Convert.ToInt32(goalServeMatchId);
                            game.StartTime = Convert.ToDateTime(stDateTime).ToLocalTime();
                            game.ResultStatus = 1;
                            game.GameOdds.ForEach(g => g.GameId = game.MatchNo);
                            BetDatabase.Matches.Add(game);
                            await BetDatabase.SaveChangesAsync();
                        }
                    }
                }
            }
            return 1;
        }

    // GET: Games
        public async Task<ActionResult> Index()
        {
            if (!Request.IsAjaxRequest())
            {
               var result = await UploadGames();  
                return View();
            }
        
           // var games = await BetDatabase.Matches.Include(g => g.AwayTeam).Include(g => g.HomeTeam).Include(g => g.GameOdds.Select(c=>c.BetOption)).ToListAsync();
            var games = await BetDatabase.ShortMatchCodes.Include(s => s.Match).OrderBy(x => x.ShortCode).ToListAsync();
;            var filteredgames = games.Select(g => new GameViewModel
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
                    Odd = go.Odd
                }).ToList(),
                GameStatus = g.Match.GameStatus,
                HalfTimeAwayScore = g.Match.HalfTimeAwayScore,
                HalfTimeHomeScore = g.Match.HalfTimeHomeScore,
                HomeScore = g.Match.HomeScore,
                HomeTeamName = g.Match.HomeTeam.TeamName,
                HomeTeamId = g.Match.HomeTeamId,
                MatchNo = g.MatchNo,
                RegistrationDate = g.Match.RegistrationDate,
                ResultStatus = g.Match.ResultStatus,
                SetNo = g.SetNo,
                OldDateTime = g.Match.StartTime,
                StartTime = String.Format("{0:d}", g.Match.StartTime)
            });
            return Json(filteredgames, JsonRequestBehavior.AllowGet);
        }

        // GET: Games/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = await BetDatabase.Matches.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.AwayTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName");
            ViewBag.HomeTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MatchNo,SetNo,Champ,StartTime,GameStatus,AwayTeamId,HomeTeamId,RegistrationDate,HomeScore,AwayScore,HalfTimeHomeScore,HalfTimeAwayScore,ResultStatus")] Match game)
        {
            if (ModelState.IsValid)
            {
                BetDatabase.Matches.Add(game);
                await BetDatabase.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AwayTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", game.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", game.HomeTeamId);
            return View(game);
        }

        // GET: Games/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = await BetDatabase.Matches.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            ViewBag.AwayTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", game.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", game.HomeTeamId);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MatchNo,SetNo,Champ,StartTime,GameStatus,AwayTeamId,HomeTeamId,RegistrationDate,HomeScore,AwayScore,HalfTimeHomeScore,HalfTimeAwayScore,ResultStatus")] Match game)
        {
            if (ModelState.IsValid)
            {
                BetDatabase.Entry(game).State = EntityState.Modified;
                await BetDatabase.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AwayTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", game.AwayTeamId);
            ViewBag.HomeTeamId = new SelectList(BetDatabase.Teams, "TeamId", "TeamName", game.HomeTeamId);
            return View(game);
        }

        // GET: Games/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var game = await BetDatabase.Matches.FindAsync(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var game = await BetDatabase.Matches.FindAsync(id);
            BetDatabase.Matches.Remove(game);
            await BetDatabase.SaveChangesAsync();
            return RedirectToAction("Index");
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
