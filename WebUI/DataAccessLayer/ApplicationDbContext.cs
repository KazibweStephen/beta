using System.Data.Entity;
using Domain.Models.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebUI.DataAccessLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BetConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<BetCategory> BetCategories { get; set; }
        public DbSet<BetOption> BetOptions { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchType> BranchTypes { get; set; }
        public DbSet<CancelReciept> CancelReciepts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdd> MatchOdds { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptStatus> ReceiptStatuses { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShortMatchCode> ShortMatchCodes { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
    }
}