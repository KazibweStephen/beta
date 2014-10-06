using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Domain.Models.Concrete;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class BranchController : CustomController
    {
        //
        // GET: /Branch/

        public ActionResult Index()
        {
            var branch = BetDatabase.Branches.Include(b=>b.Terminals).Include(r=>r.Receipts);
            return View(branch.ToList());
        }

        //
        // GET: /Branch/Details/5

        public ActionResult Details(int id = 0)
        {
            var branch = BetDatabase.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        //
        // GET: /Branch/Create

        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(UserManager.Users, "staffid", "FName");
          
            return View();
        }
        public ActionResult CreateTerminal(int? branchId)
        {
            var terminal = new Terminal();
            if (branchId != null)
            {
                var branch = BetDatabase.Branches.Find(branchId);

                terminal.Branch = branch;
                //terminal.Branch.BranchId = branchId.Value;
                //if (branch != null)
                //{
                  //  terminal.Branch.BranchName = branch.BranchName;
                //}
                 ViewBag.branchId = branchId;
            }
            return View("terminal",terminal);
        }

        //
        // POST: /Branch/Create

        [HttpPost]
        public ActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                branch.BranchTypeId = 1;
                BetDatabase.Branches.Add(branch);
                BetDatabase.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(UserManager.Users, "UserId", "UserName", branch.ManagerId);
           // ViewBag.CompanyId = new SelectList(BetDatabase.Company, "CompanyId", "CompanyName", branch.CompanyId);
            return View(branch);
        }

        //
        // GET: /Branch/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var branch = BetDatabase.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(UserManager.Users, "StaffId", "FName", branch);
        
            return View(branch);
        }

        //
        // POST: /Branch/Edit/5

        [HttpPost]
        public ActionResult Edit(Branch branch)
        {
            if (ModelState.IsValid)
            {
                BetDatabase.Entry(branch).State = EntityState.Modified;
                BetDatabase.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(UserManager.Users, "PersonId", "FirstName", branch.ManagerId);
        
            return View(branch);
        }

        //
        // GET: /Branch/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var branch = BetDatabase.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        //
        // POST: /Branch/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var branch = BetDatabase.Branches.Find(id);
            BetDatabase.Branches.Remove(branch);
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