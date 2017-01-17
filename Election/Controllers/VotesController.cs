using Election.BLL.IServices;
using Election.BLL.Services;
using Election.DAL;
using Election.DAL.Repository;
using Election.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace Election.Controllers
{
    public class VotesController : ApiController
    {
        private Context db;
        private IVoteService _service;
        private IPollService _pollService;

        public VotesController()
        {
            db = new Context();
            _pollService = new PollServices(new PollRepository(db), new RestaurantRepository(db));
            _service = new VoteServices(_pollService, new VoteRepository(db));
        }

        // GET: api/Votes
        public IQueryable<Vote> GetVote()
        {
            return db.Vote;
        }

        // GET: api/Votes/5
        [ResponseType(typeof(Vote))]
        public IHttpActionResult GetVote(int id)
        {
            Vote vote = db.Vote.Find(id);
            if (vote == null)
            {
                return NotFound();
            }

            return Ok(vote);
        }

        // PUT: api/Votes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVote(int id, Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vote.Id)
            {
                return BadRequest();
            }

            db.Entry(vote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                    throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Votes
        [ResponseType(typeof(Vote))]
        public IHttpActionResult PostVote(Vote vote)
        {
            _service.Create(vote);
            vote.Poll = null;
            return CreatedAtRoute("DefaultApi", new { id = vote.Id }, vote);
        }

        // DELETE: api/Votes/5
        [ResponseType(typeof(Vote))]
        public IHttpActionResult DeleteVote(int id)
        {
            Vote vote = db.Vote.Find(id);
            if (vote == null)
            {
                return NotFound();
            }

            db.Vote.Remove(vote);
            db.SaveChanges();

            return Ok(vote);
        }
    }
}