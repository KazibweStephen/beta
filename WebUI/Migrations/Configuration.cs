using System.Data.Entity.Migrations;
using System.Linq;
using Domain.Models.Concrete;
using WebUI.DataAccessLayer;
using WebUI.Infrastructure;

namespace WebUI.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            #region Countries Seed
            //var countries = Lists.Countries.Select(country => new Country
            //{
            //    CountryName = country
            //}).ToList();
            //context.Countries.AddOrUpdate(c => c.CountryName, countries.ToArray());
            #endregion

            #region Bet Categories Seed
            var betcategories = Lists.BetCategories.Select(bc => new BetCategory
            {
                Name = bc,
                MinimumSize = 2,
                Status = true
            }).ToList();
            context.BetCategories.AddOrUpdate(b => b.Name, betcategories.ToArray());
            #endregion

            #region Bet Options Seed
            context.BetOptions.AddOrUpdate(bo => bo.Option,
                new BetOption
                {
                    BetCategoryId = 1,
                    Option = "FT1"
                },
                new BetOption
                {
                    BetCategoryId = 1,
                    Option = "FTX"
                },
                new BetOption
                {
                    BetCategoryId = 1,
                    Option = "FT2"
                },
                new BetOption
                {
                    BetCategoryId = 2,
                    Option = "FTUnder1.5"
                },
                new BetOption
                {
                    BetCategoryId = 2,
                    Option = "FTOver1.5"
                },
                new BetOption
                {
                    BetCategoryId = 2,
                    Option = "FTUnder2.5"
                },
                new BetOption
                {
                    BetCategoryId = 2,
                    Option = "FTOver2.5"
                },
                new BetOption
                {
                    BetCategoryId = 2,
                    Option = "FTUnder3.5"
                },
                new BetOption
                {
                    BetCategoryId = 2,
                    Option = "FTOver3.5"
                },
                new BetOption
                {
                    BetCategoryId = 2,
                    Option = "FTUnder4.5"
                },
                new BetOption
                {
                    BetCategoryId = 2,
                    Option = "FTOver4.5"
                },
                new BetOption
                {
                    BetCategoryId = 3,
                    Option = "HT1"
                },
                new BetOption
                {
                    BetCategoryId = 3,
                    Option = "HTX"
                },
                new BetOption
                {
                    BetCategoryId = 3,
                    Option = "HT2"
                },
                new BetOption
                {
                    BetCategoryId = 4,
                    Option = "HTUnder0.5"
                },
                new BetOption
                {
                    BetCategoryId = 4,
                    Option = "HTOver0.5"
                },
                new BetOption
                {
                    BetCategoryId = 4,
                    Option = "HTUnder1.5"
                },
                new BetOption
                {
                    BetCategoryId = 4,
                    Option = "HTOver1.5"
                },
                new BetOption
                {
                    BetCategoryId = 4,
                    Option = "HTUnder2.5"
                },
                new BetOption
                {
                    BetCategoryId = 4,
                    Option = "HTOver2.5"
                },
                new BetOption
                {
                    BetCategoryId = 5,
                    Option = "1X"
                },
                new BetOption
                {
                    BetCategoryId = 5,
                    Option = "12"
                },
                new BetOption
                {
                    BetCategoryId = 5,
                    Option = "X2"
                },
                new BetOption
                {
                    BetCategoryId = 6,
                    Option = "HC1"
                },
                new BetOption
                {
                    BetCategoryId = 6,
                    Option = "HC2"
                },
                new BetOption
                {
                    BetCategoryId = 7,
                    Option = "GG"
                },
                new BetOption
                {
                    BetCategoryId = 7,
                    Option = "NG"
                },
                new BetOption
                {
                    BetCategoryId = 8,
                    Option = "DNB1"
                },
                new BetOption
                {
                    BetCategoryId = 8,
                    Option = "DNB2"
                });
            #endregion

            //#region Teams Seed
            //context.Teams.AddOrUpdate(t => t.TeamName,
            //    new Team
            //    {
            //        CountryId = 231,
            //        DateRegistered = DateTime.Now,
            //        TeamName = "Arsenal"
            //    },
            //    new Team
            //    {
            //        CountryId = 231,
            //        DateRegistered = DateTime.Now,
            //        TeamName = "Chelsea"
            //    },
            //    new Team
            //    {
            //        CountryId = 231,
            //        DateRegistered = DateTime.Now,
            //        TeamName = "Everton"
            //    },
            //    new Team
            //    {
            //        CountryId = 231,
            //        DateRegistered = DateTime.Now,
            //        TeamName = "Swansea"
            //    },
            //    new Team
            //    {
            //        CountryId = 231,
            //        DateRegistered = DateTime.Now,
            //        TeamName = "Manchester City"
            //    },
            //    new Team
            //    {
            //        CountryId = 231,
            //        DateRegistered = DateTime.Now,
            //        TeamName = "Totenham Hotspurs"
            //    });
            //#endregion

            //#region Games Seed
            //context.Games.AddOrUpdate(
            //    g => g.MatchNo,
            //    new Game
            //    {
            //        AwayTeam = context.Teams.SingleOrDefault(t => t.TeamId == 1),
            //        Champ = "Yes",
            //        GameOdds = new List<GameOdd>
            //        {
            //            #region GameOdds
            //            new GameOdd
            //            {
            //                BetOptionId = 1,
            //                MatchId = 100,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(3.20),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 2,
            //                MatchId = 100,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(3.10),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 3,
            //                MatchId = 100,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.85),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 4,
            //                MatchId = 100,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.60),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 5,
            //                MatchId = 100,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(2.15),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 6,
            //                MatchId = 100,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.17),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 7,
            //                MatchId = 100,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.25),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 8,
            //                MatchId = 100,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.85),
            //                SetNo = 1758
            //            }
            //            #endregion
            //        },
            //        GameStatus = "Live",
            //        HomeTeam = context.Teams.SingleOrDefault(t => t.TeamId == 2),
            //        MatchNo = 100,
            //        RegistrationDate = DateTime.Now,
            //        SetNo = 1758,
            //        StartTime = DateTime.Now.AddDays(5)
            //    },
            //    new Game
            //    {
            //        AwayTeam = context.Teams.SingleOrDefault(t => t.TeamId == 3),
            //        Champ = "Yes",
            //        GameOdds = new List<GameOdd>
            //        {
            //            #region GameOdds
            //            new GameOdd
            //            {
            //                BetOptionId = 1,
            //                MatchId = 101,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(2.95),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 2,
            //                MatchId = 101,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(3.10),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 3,
            //                MatchId = 101,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.95),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 4,
            //                MatchId = 101,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.65),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 5,
            //                MatchId = 101,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.95),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 6,
            //                MatchId = 101,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.14),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 7,
            //                MatchId = 101,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.23),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 8,
            //                MatchId = 101,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.95),
            //                SetNo = 1758
            //            }
            //            #endregion
            //        },
            //        GameStatus = "Live",
            //        HomeTeam = context.Teams.SingleOrDefault(t => t.TeamId == 4),
            //        MatchNo = 101,
            //        RegistrationDate = DateTime.Now,
            //        SetNo = 1758,
            //        StartTime = DateTime.Now.AddDays(5)
            //    },
            //    new Game
            //    {
            //        AwayTeam = context.Teams.SingleOrDefault(t => t.TeamId == 5),
            //        Champ = "Yes",
            //        GameOdds = new List<GameOdd>
            //        {
            //            #region GameOdds
            //            new GameOdd
            //            {
            //                BetOptionId = 1,
            //                MatchId = 102,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(3.00),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 2,
            //                MatchId = 102,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.95),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 3,
            //                MatchId = 102,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(3.60),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 4,
            //                MatchId = 102,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.60),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 5,
            //                MatchId = 102,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(2.25),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 6,
            //                MatchId = 102,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.37),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 7,
            //                MatchId = 102,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.34),
            //                SetNo = 1758
            //            },
            //            new GameOdd
            //            {
            //                BetOptionId = 8,
            //                MatchId = 102,
            //                LastUpdateTime = DateTime.Now,
            //                Odd = new decimal(1.50),
            //                SetNo = 1758
            //            }
            //            #endregion
            //        },
            //        GameStatus = "Live",
            //        HomeTeam = context.Teams.SingleOrDefault(t => t.TeamId == 6),
            //        MatchNo = 102,
            //        RegistrationDate = DateTime.Now,
            //        SetNo = 1758,
            //        StartTime = DateTime.Now.AddDays(5)
            //    });
            //#endregion
        }
    }
}
