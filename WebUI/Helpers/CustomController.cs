using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using WebUI.App_Start;
using WebUI.DataAccessLayer;

namespace WebUI.Helpers
{
    public class CustomController: Controller
    {
        private ApplicationDbContext _dbContext;
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public ApplicationDbContext BetDatabase
        {
            get { return _dbContext ?? (_dbContext = new ApplicationDbContext()); }
            set
            {
                _dbContext = value;
            }
        }
    }
}