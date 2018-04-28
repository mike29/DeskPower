﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DeskPowerApp.DataAcess;
using DeskPowerApp.Model;

namespace DeskPower.Datat.Api.Controllers
{
    public class DraftsController : ApiController
    {
        private DeskPowerAppContext db = new DeskPowerAppContext();

        // GET: api/Drafts
        public IQueryable<Draft> GetDrafts()
        {
            return db.Drafts;
        }

        // GET: api/Drafts/5
        [ResponseType(typeof(Draft))]
        public async Task<IHttpActionResult> GetDraft(int id)
        {
            Draft draft = await db.Drafts.FindAsync(id);
            if (draft == null)
            {
                return NotFound();
            }

            return Ok(draft);
        }

        // PUT: api/Drafts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDraft(int id, Draft draft)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != draft.DraftId)
            {
                return BadRequest();
            }

            db.Entry(draft).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DraftExists(id))
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

        // POST: api/Drafts
        [ResponseType(typeof(Draft))]
        public async Task<IHttpActionResult> PostDraft(Draft draft)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drafts.Add(draft);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = draft.DraftId }, draft);
        }

        // DELETE: api/Drafts/5
        [ResponseType(typeof(Draft))]
        public async Task<IHttpActionResult> DeleteDraft(int id)
        {
            Draft draft = await db.Drafts.FindAsync(id);
            if (draft == null)
            {
                return NotFound();
            }

            db.Drafts.Remove(draft);
            await db.SaveChangesAsync();

            return Ok(draft);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DraftExists(int id)
        {
            return db.Drafts.Count(e => e.DraftId == id) > 0;
        }
    }
}