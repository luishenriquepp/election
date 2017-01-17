using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Election.DAL;
using Election.Models;
using Election.BLL.Services;
using Election.DAL.Repository;
using Election.BLL.Utils;
using Election.BLL;
using Election.BLL.IServices;

namespace Election.Controllers
{
    public class PollsController : ApiController
    {
        private Context db;
        private IPollService _service;

        public PollsController()
        {
             db = new Context();
            _service = new PollServices(new PollRepository(db), new RestaurantRepository(db));
        }

        // GET: api/Polls/5
        [ResponseType(typeof(CreatePollViewModel))]
        public IHttpActionResult GetPoll()
        {
            _service.SelectWinner(DateTime.Now);

            CreateElectionDateOfWeek create = new CreateElectionDateOfWeek(DateTime.Now);
            var key = create.Get();
            var poll = _service.GetByDayOfWeak(DateTime.Now);
            var availableRestaurants = _service.GetAvailableRestaurants(DateTime.Now);
            CreatePollViewModel createVM = new CreatePollViewModel(availableRestaurants.ToList(), poll);
            ElectionViewModel vm = new ElectionViewModel();
            vm.ElectionVotes = createVM.Get();
            
            return Ok(vm);
        }

        // PUT: api/Polls/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPoll(int id, Poll poll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != poll.Id)
            {
                return BadRequest();
            }

            db.Entry(poll).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollExists(id))
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

        // POST: api/Polls
        [ResponseType(typeof(Poll))]
        public IHttpActionResult PostPoll(Poll poll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Election.Add(poll);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = poll.Id }, poll);
        }

        // DELETE: api/Polls/5
        [ResponseType(typeof(Poll))]
        public IHttpActionResult DeletePoll(int id)
        {
            Poll poll = db.Election.Find(id);
            if (poll == null)
            {
                return NotFound();
            }

            db.Election.Remove(poll);
            db.SaveChanges();

            return Ok(poll);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PollExists(int id)
        {
            return db.Election.Count(e => e.Id == id) > 0;
        }
    }
}