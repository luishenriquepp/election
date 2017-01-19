using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Election.Models;
using Election.BLL.Utils;
using Election.BLL;
using Election.BLL.IServices;
using Microsoft.AspNet.Identity;

namespace Election.Controllers
{
    public class PollsController : ApiController
    {
        private IPollService _service;

        public PollsController(IPollService service)
        {
            _service = service;
        }

        // GET: api/Polls/5
        [ResponseType(typeof(GeneratePollResultFilterAndOrder))]
        public IHttpActionResult GetPoll()
        {
            _service.SelectWinner(DateTime.Now);

            CreateWeekOfYearElection create = new CreateWeekOfYearElection(DateTime.Now);
            var key = create.Get();
            var poll = _service.GetByWeekOfYear(DateTime.Now);
            var availableRestaurants = _service.GetAvailableRestaurants(DateTime.Now);
            GeneratePollResultFilterAndOrder createVM = new GeneratePollResultFilterAndOrder(availableRestaurants.ToList(), poll);
            ElectionViewModel vm = new ElectionViewModel();
            vm.ElectionVotes = createVM.Get();

            if(poll != null)
            {
                var voted = poll.Votes.Where(v => v.UserToken.Equals(User.Identity.GetUserId()));
                vm.Voted = voted.Any();
                if(poll.WinnerId != null)
                {
                    vm.WinnerId = (int)poll.WinnerId;
                }
            }
            
            return Ok(vm);
        }
    }
}