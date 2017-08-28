using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Tourney.DataAccess;
using Tourney.Model;

namespace Tourney.API.Data.Controllers
{
    /// <summary>
    /// API controller for the table of rankings.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class RankingsController : ApiController
    {
        /// <summary>
        /// The database.
        /// </summary>
        private TourneyContext db = new TourneyContext();

        // GET: api/Rankings
        /// <summary>
        /// Gets the rankings.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ranking> GetRankings()
        {
            return db.Rankings;
        }

        // GET: api/Rankings/5
        /// <summary>
        /// Gets the ranking.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(Ranking))]
        public async Task<IHttpActionResult> GetRanking(int id)
        {
            Ranking ranking = await db.Rankings.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }

            return Ok(ranking);
        }

        // PUT: api/Rankings/5
        /// <summary>
        /// Puts the ranking.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ranking">The ranking.</param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRanking(int id, Ranking ranking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ranking.RankingId)
            {
                return BadRequest();
            }

            db.Entry(ranking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankingExists(id))
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

        // POST: api/Rankings
        /// <summary>
        /// Posts the ranking.
        /// </summary>
        /// <param name="ranking">The ranking.</param>
        /// <returns></returns>
        [ResponseType(typeof(Ranking))]
        public async Task<IHttpActionResult> PostRanking(Ranking ranking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rankings.Add(ranking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = ranking.RankingId }, ranking);
        }

        // DELETE: api/Rankings/5
        /// <summary>
        /// Deletes the ranking.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ResponseType(typeof(Ranking))]
        public async Task<IHttpActionResult> DeleteRanking(int id)
        {
            Ranking ranking = await db.Rankings.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }

            db.Rankings.Remove(ranking);
            await db.SaveChangesAsync();

            return Ok(ranking);
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Checks if a ranking exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        private bool RankingExists(int id)
        {
            return db.Rankings.Count(e => e.RankingId == id) > 0;
        }
    }
}