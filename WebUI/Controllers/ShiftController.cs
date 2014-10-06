using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Models.Concrete;
using WebUI.Helpers;

namespace WebUI.Controllers
{
    public class ShiftController : CustomController
    {
        // GET: Shift
        public async Task<ActionResult> Index()
        {
            var shifts = BetDatabase.Shifts.Include(s => s.Terminal);
            return View(await shifts.ToListAsync());
        }

        // GET: Shift/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shift = await BetDatabase.Shifts.FindAsync(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // GET: Shift/Create
        public ActionResult Create()
        {
            ViewBag.TerminalId = new SelectList(BetDatabase.Terminals, "Terminalid", "TerminalName");
            return View();
        }

        // POST: Shift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "shiftid,startdate,startcash,endcash,assignedto,AssigneBetDatabasey,TerminalId")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                BetDatabase.Shifts.Add(shift);
                await BetDatabase.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TerminalId = new SelectList(BetDatabase.Terminals, "Terminalid", "TerminalName", shift.TerminalId);
            return View(shift);
        }

        // GET: Shift/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shift = await BetDatabase.Shifts.FindAsync(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            ViewBag.TerminalId = new SelectList(BetDatabase.Terminals, "Terminalid", "TerminalName", shift.TerminalId);
            return View(shift);
        }

        // POST: Shift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "shiftid,startdate,startcash,endcash,assignedto,AssigneBetDatabasey,TerminalId")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                BetDatabase.Entry(shift).State = EntityState.Modified;
                await BetDatabase.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TerminalId = new SelectList(BetDatabase.Terminals, "Terminalid", "TerminalName", shift.TerminalId);
            return View(shift);
        }

        // GET: Shift/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var shift = await BetDatabase.Shifts.FindAsync(id);
            if (shift == null)
            {
                return HttpNotFound();
            }
            return View(shift);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var shift = await BetDatabase.Shifts.FindAsync(id);
            BetDatabase.Shifts.Remove(shift);
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
