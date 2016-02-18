using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using MvcWebApp.Models;

namespace MvcWebApp.Controllers
{
    public class CompanhiasController : Controller
    {
        private MvcWebAppContext db = new MvcWebAppContext();

        // GET: Companhias
        public async Task<ActionResult> Index()
        {
            return View(await db.Companhias.ToListAsync());
        }

        // GET: Companhias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = await db.Companhias.FindAsync(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // GET: Companhias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companhias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NomeCompanhia")] Companhia companhia)
        {
            if (ModelState.IsValid)
            {
                db.Companhias.Add(companhia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(companhia);
        }

        // GET: Companhias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = await db.Companhias.FindAsync(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // POST: Companhias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NomeCompanhia")] Companhia companhia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companhia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(companhia);
        }

        // GET: Companhias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Companhia companhia = await db.Companhias.FindAsync(id);
            if (companhia == null)
            {
                return HttpNotFound();
            }
            return View(companhia);
        }

        // POST: Companhias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Companhia companhia = await db.Companhias.FindAsync(id);
            db.Companhias.Remove(companhia);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
