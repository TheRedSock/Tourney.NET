﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Tourney.DataAccess;
using Tourney.Model;

namespace Tourney.Api.Data.Controllers
{
    public class TournamentsController : ApiController
    {
        private TourneyContext db = new TourneyContext();

        // GET: api/Tournaments
        public IQueryable<Tournament> GetTournaments()
        {
            return db.Tournaments;
        }

        // GET: api/Tournaments/5
        [ResponseType(typeof(Tournament))]
        public async Task<IHttpActionResult> GetTournament(int id)
        {
            Tournament tournament = await db.Tournaments.FindAsync(id);

            db.Entry(tournament).Collection(r => r.Rankings).Load();
            db.Entry(tournament).Collection(r => r.Phases).Load();
            db.Entry(tournament).Collection(r => r.Participants).Load();

            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(tournament);
        }

        // PUT: api/Tournaments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTournament(int id, Tournament tournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tournament.TournamentId)
            {
                return BadRequest();
            }

            db.Entry(tournament).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(id))
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

        // POST: api/Tournaments
        [ResponseType(typeof(Tournament))]
        public async Task<IHttpActionResult> PostTournament(Tournament tournament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Debug.WriteLine(tournament.TournamentId + ", " + tournament.Name + ", " + tournament.GameId);
            db.Tournaments.Add(tournament);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tournament.TournamentId }, tournament);
        }

        // DELETE: api/Tournaments/5
        [ResponseType(typeof(Tournament))]
        public async Task<IHttpActionResult> DeleteTournament(int id)
        {
            Tournament tournament = await db.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            db.Tournaments.Remove(tournament);
            await db.SaveChangesAsync();

            return Ok(tournament);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TournamentExists(int id)
        {
            return db.Tournaments.Count(e => e.TournamentId == id) > 0;
        }
    }
}