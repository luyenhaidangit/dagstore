using DAGStore.Data.Infrastructure;
using DAGStore.Model.Models;

namespace DAGStore.Data.Repositories
{
    public interface INewsTagRepository : IRepository<NewsTag>
    {
    }

    public class NewsTagRepository : RepositoryBase<NewsTag>, INewsTagRepository
    {
        public NewsTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}