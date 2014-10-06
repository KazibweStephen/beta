using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Models.Concrete;
using Microsoft.AspNet.Identity;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class TerminalController : CustomController
    {
        //
        // GET: /Terminal/

        public async Task<ActionResult> Index()
        {
            var terminal = BetDatabase.Terminals;
            var account = await BetDatabase.Accounts.Select(a => new
            {
                a.UserId,
                a.AmountE
            }).SingleOrDefaultAsync(t => t.UserId == User.Identity.GetUserId());
            ViewBag.Balance = account.AmountE;
            return View("Index",terminal.ToList());
        }

        //
        // GET: /Terminal/Details/5

        public ActionResult Details(int id = 0)
        {
            var terminal = BetDatabase.Terminals.Find(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            return View(terminal);
        }

        //
        // GET: /Terminal/Create

        public ActionResult Create(int? branchId)
        {
            var terminal = new Terminal();
            if (branchId != null)
            {
                var branch = BetDatabase.Branches.Find(branchId);
                
                terminal.Branch = new Branch {BranchId = branchId.Value};
                if (branch != null)
                {
                    terminal.Branch.BranchName = branch.BranchName;
                }
                ViewBag.branchId = branchId;
            }
            return View(terminal);
        }

        //
        // POST: /Terminal/Create

        [HttpPost]
        public ActionResult Create(Terminal terminal)
        {
            if (!ModelState.IsValid) return View(terminal);
            {
                var branch = BetDatabase.Branches.Find(terminal.Branch.BranchId);
                if (branch != null)
                {
                    terminal.Branch = branch;

                }
            }
            BetDatabase.Terminals.Add(terminal);
            BetDatabase.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Terminal/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var terminal = BetDatabase.Terminals.Find(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            return View(terminal);
        }

        //
        // POST: /Terminal/Edit/5

        [HttpPost]
        public ActionResult Edit(Terminal terminal)
        {
            //var _terminal = new Terminal()
            //{
            //    TerminalId = terminal.TerminalId,
            //    IpAddress = terminal.IpAddress,
            //    DateCreated = DateTime.Parse("terminal.DateCreated"),
            //    isActive = false
            //};
           if (ModelState.IsValid)
            {
                BetDatabase.Entry(terminal).State = EntityState.Modified;
                BetDatabase.SaveChanges();
                return RedirectToAction("Index");
           }
            return View(terminal);
        }

        //
        // GET: /Terminal/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var terminal = BetDatabase.Terminals.Find(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            return View(terminal);
        }

        //
        // POST: /Terminal/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var terminal = BetDatabase.Terminals.Find(id);
            BetDatabase.Terminals.Remove(terminal);
            BetDatabase.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            BetDatabase.Dispose();
            base.Dispose(disposing);
        }
    }
}