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
        private IVoteService _service;
        private IPollService _pollService;

        public VotesController(IVoteService vService, IPollService pService)
        {
            _service = vService;
            _pollService = pService;
        }

        // POST: api/Votes
        [ResponseType(typeof(Vote))]
        public IHttpActionResult PostVote(Vote vote)
        {
            _service.Create(vote);
            vote.Poll = null;
            return CreatedAtRoute("DefaultApi", new { id = vote.Id }, vote);
        }
    }
}