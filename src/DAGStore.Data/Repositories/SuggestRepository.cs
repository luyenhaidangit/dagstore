using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface ISuggestRepository : IRepository<Suggest>
    {
    }

    public class SuggestRepository : RepositoryBase<Suggest>, ISuggestRepository
    {
        public SuggestRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
