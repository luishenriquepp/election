using Election.BLL.IServices;
using Election.Models;
using System;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;

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
            if(!User.Identity.IsAuthenticated)
            {
                return InternalServerError(new Exception("Usuário não autenticado."));
            }
            vote.UserToken = User.Identity.GetUserId();

            _service.Create(vote);
            vote.Poll = null;
            return CreatedAtRoute("DefaultApi", new { id = vote.Id }, vote);
        }
    }
}