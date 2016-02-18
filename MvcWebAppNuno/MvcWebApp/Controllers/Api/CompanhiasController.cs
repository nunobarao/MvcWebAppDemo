using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MvcWebApp.Models;

namespace MvcWebApp.Controllers.Api
{
    public class CompanhiasController : ApiController
    {
        private MvcWebAppContext db = new MvcWebAppContext();

        // GET: api/Companhias
        public IQueryable<Companhia> GetCompanhias()
        {
            return db.Companhias;
        }

        // GET: api/Companhias/5
        [ResponseType(typeof(Companhia))]
        public async Task<IHttpActionResult> GetCompanhia(int id)
        {
            Companhia companhia = await db.Companhias.FindAsync(id);
            if (companhia == null)
            {
                return NotFound();
            }

            return Ok(companhia);
        }

        // PUT: api/Companhias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCompanhia(int id, Companhia companhia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companhia.Id)
            {
                return BadRequest();
            }

            db.Entry(companhia).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanhiaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Companhias
        [ResponseType(typeof(Companhia))]
        public async Task<IHttpActionResult> PostCompanhia(Companhia companhia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Companhias.Add(companhia);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = companhia.Id }, companhia);
        }

        // DELETE: api/Companhias/5
        [ResponseType(typeof(Companhia))]
        public async Task<IHttpActionResult> DeleteCompanhia(int id)
        {
            Companhia companhia = await db.Companhias.FindAsync(id);
            if (companhia == null)
            {
                return NotFound();
            }

            db.Companhias.Remove(companhia);
            await db.SaveChangesAsync();

            return Ok(companhia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanhiaExists(int id)
        {
            return db.Companhias.Count(e => e.Id == id) > 0;
        }
    }
}