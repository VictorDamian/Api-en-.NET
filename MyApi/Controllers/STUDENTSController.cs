using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MyApi.Models;

namespace MyApi.Controllers
{
    public class STUDENTSController : ApiController
    {
        private List<Domain.Models.StudentsModel> lst = new List<Domain.Models.StudentsModel>();
        private SCHOOLEntities db = new SCHOOLEntities();

        // GET: api/STUDENTS
        public IHttpActionResult GetSTUDENTS()
        {
            lst = (from i in db.STUDENTS
                   select new Domain.Models.StudentsModel
                   {
                       _Id = i.ID,
                       _Name = i.NAME,
                       _Lastname = i.LASTNAME,
                       _Cellphone = i.CELLPHONE
                   }).ToList();

            return Ok(lst);
        }

        // GET: api/STUDENTS/5
        [ResponseType(typeof(STUDENTS))]
        public IHttpActionResult GetSTUDENTS(int id)
        {
            STUDENTS sTUDENTS = db.STUDENTS.Find(id);
            if (sTUDENTS == null)
            {
                return NotFound();
            }

            return Ok(sTUDENTS);
        }

        // PUT: api/STUDENTS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSTUDENTS(int id, STUDENTS sTUDENTS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sTUDENTS.ID)
            {
                return BadRequest();
            }

            db.Entry(sTUDENTS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!STUDENTSExists(id))
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

        // POST: api/STUDENTS
        [ResponseType(typeof(STUDENTS))]
        public IHttpActionResult PostSTUDENTS(STUDENTS sTUDENTS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.STUDENTS.Add(sTUDENTS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (STUDENTSExists(sTUDENTS.ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sTUDENTS.ID }, sTUDENTS);
        }

        // DELETE: api/STUDENTS/5
        [ResponseType(typeof(STUDENTS))]
        public IHttpActionResult DeleteSTUDENTS(int id)
        {
            STUDENTS sTUDENTS = db.STUDENTS.Find(id);
            if (sTUDENTS == null)
            {
                return NotFound();
            }

            db.STUDENTS.Remove(sTUDENTS);
            db.SaveChanges();

            return Ok(sTUDENTS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool STUDENTSExists(int id)
        {
            return db.STUDENTS.Count(e => e.ID == id) > 0;
        }
    }
}