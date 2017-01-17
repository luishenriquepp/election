using Election.Models;
using System.Linq;

namespace Election.BLL.IServices
{
    public interface IVoteService
    {
        void Create(Vote vote);
        IQueryable<Vote> GetAll();
        void Remove(int id);
        void Edit(Vote vote);
        Vote GetById(int id);
    }
}
